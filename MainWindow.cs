using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace MessBatch
{
    public partial class MainWindow : Form
    {
        // This list contains the lines for the batch file
        List<string> BatchLines = new List<string>();
        // Encoding for the batch file
        Encoding encoding = Encoding.ASCII;
        // Convert strength value to number of lines
        int rawstrength;
        string ctype = "";
        int strength;
        bool finished = false;
        Thread corruptThread;
        public MainWindow()
        {
            InitializeComponent();
        }

        // File browser
        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openBatchfile.ShowDialog() == DialogResult.OK)
            {
                batchfilePath.Text = openBatchfile.FileName;
            }
        }

        private void openBatchfileButton_Click(object sender, EventArgs e)
        {
            // Close the file first
            closeButton.PerformClick();

            // Import codepages
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // find the encoding of the file
            using (var reader = new StreamReader(batchfilePath.Text, Encoding.GetEncoding(1252), true))
            {
                reader.Peek(); // you need this!
                encoding = reader.CurrentEncoding;
            }
            System.Threading.Thread.Sleep(1);
            // load the file with this encoding, but make sure to the file after loading to avoid it being locked
            // from other programs
            using (FileStream fs = new FileStream(batchfilePath.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, encoding))
                {
                    while (!sr.EndOfStream)
                    {
                        BatchLines.Add(sr.ReadLine());
                    }
                }
            }
            // Update the preview and enable certain controls
            UpdateText();
            previewGroup.Enabled = true;
            closeButton.Enabled = true;
            corruptionsGroup.Enabled = true;
        }

        // Updates the preview text box
        void UpdateText()
        {
            previewBox.Text = string.Join("\r\n", BatchLines);
        }

        // Enable the open button if the file on the text field exists
        private void batchfilePath_TextChanged(object sender, EventArgs e)
        {
            openBatchfileButton.Enabled = File.Exists(batchfilePath.Text);
        }

        // For closing the batch file
        private void closeButton_Click(object sender, EventArgs e)
        {
            BatchLines.Clear();
            closeButton.Enabled = false;
            previewGroup.Enabled = false;
            corruptionsGroup.Enabled = false;
            previewBox.Text = "Please open a batch file";
        }


        // Set default values when the window is initially loaded
        private void MainWindow_Load(object sender, EventArgs e)
        {
            strengthLabel.Text = string.Format("Strength: {0}%", (double)strengthBar.Value / 100.0);
            ctype = "lineswap";
        }

        void corrupt_str()
        {
            Random r = new Random();
            string[] tokens = {
                    "echo",
                    "echo.",
                    "echo,",
                    "echo:",
                    "echo;"
                };
            List<int> stringlines = new List<int>();
            for (int i = 0; i < BatchLines.Count; i++)
            {
                if ((!CheckTokens(tokens, BatchLines[i])) && (!BatchLines[i].Contains("&")) && (!BatchLines[i].Contains(">")) && (!BatchLines[i].Contains("<")) && (!BatchLines[i].Contains("|")))
                {
                    stringlines.Add(i);
                }
            }
            for (int j = 0; j < rawstrength; j++)
            {
                int id = r.Next(0, BatchLines.Count);
                string line = BatchLines[id];
                List<string> newtokens = new List<string>();
                bool enablecorruptions = false;
                if ((line.ToLower().Contains("echo")))
                {
                    foreach (string word in line.Split(' '))
                    {
                        string rwword = word;
                        bool cont = false;
                        foreach (string token in tokens)
                        {
                            if (rwword.ToLower().Contains(token))
                            {
                                cont = true;
                                newtokens.Add(word);
                                enablecorruptions = true;
                                break;
                            }
                        }
                        if (!enablecorruptions)
                        {
                            cont = true;
                            newtokens.Add(word);
                        }
                        if (cont) { continue; }
                        if (stringCorruptorRadio.Checked)
                        {
                            for (int k = 0; k < rawstrength; k++)
                            {
                                List<char> chararray = rwword.ToCharArray().ToList<char>();
                                if (rwword.Length < 3)
                                {
                                    break;
                                }
                                int a = r.Next(0, rwword.Length - 1);
                                int b = r.Next(0, rwword.Length - 1);
                                while (a == b)
                                {
                                    b = r.Next(0, rwword.Length - 1);
                                }
                                char backup = chararray[a];
                                chararray[a] = chararray[b];
                                chararray[b] = backup;
                                rwword = new string(chararray.ToArray());
                            }
                        }
                        else
                        {
                            string newstr = "";
                            for (int k = rwword.Length - 1; k >= 0; k--)
                            {
                                newstr = newstr + rwword[k].ToString();
                            }
                            rwword = newstr;
                        }
                        newtokens.Add(rwword);
                    }
                    BatchLines[id] = string.Join(" ", newtokens);
                }
            }
        }

        void corrupt_background()
        {
            Random r = new Random();
            string[] blacklist = {
                "echo off",
                "setlocal",
                "endlocal",
                ":",
            };
            switch (ctype)
            {
                case "lineswap":
                    List<int> previousLines = new List<int>();
                    for (int i = 0; i < rawstrength; i++)
                    {
                        int a = r.Next(0, BatchLines.Count - 1);
                        int attempts = 0;
                        while ((!CheckTokens(blacklist, BatchLines[a])) || (previousLines.Contains(a)))
                        {
                            a = r.Next(0, BatchLines.Count - 1);
                            attempts++;
                            if (attempts > 10000)
                            {
                                break;
                            }
                        }
                        previousLines.Add(a);
                        int b = r.Next(0, BatchLines.Count - 1);
                        while ((a == b) || !CheckTokens(blacklist, BatchLines[b]) || (previousLines.Contains(b)))
                        {
                            b = r.Next(0, BatchLines.Count - 1);
                            attempts++;
                            if (attempts > 10000)
                            {
                                break;
                            }
                        }
                        previousLines.Add(b);
                        string temp = BatchLines[a];
                        BatchLines[a] = BatchLines[b];
                        BatchLines[b] = temp;
                    }
                    break;
                case "substring":

                    // failsafe to avoid infinite loops
                    if (!string.Join("\r\n", BatchLines).Contains(":~"))
                    {
                        MessageBox.Show("This batch file does not contain substring references.", "Cannot apply this corruption", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    for (int i = 0; i < rawstrength; i++)
                    {
                        int lineid = r.Next(0, BatchLines.Count - 1);
                        while (!BatchLines[lineid].Contains(":~"))
                        {
                            lineid = r.Next(0, BatchLines.Count - 1);
                        }
                        string line = BatchLines[lineid];
                        // determine variable separator
                        char variable_sep = '%';
                        if (!line.Contains(variable_sep))
                        {
                            variable_sep = '!';
                        }
                        if (line.Contains("!") && line.Contains("%"))
                        {
                            variable_sep = '!';
                        }
                        string original_substring = "";
                        string variable_name = "";
                        bool is_range = false;
                        int range_A = r.Next(-10, 10);
                        int range_B = r.Next(-10, 20);
                        while (range_A > range_B)
                        {
                            range_A = r.Next(-10, 10);
                            range_B = r.Next(-10, 20);
                        }
                        foreach (string token in line.Split(variable_sep))
                        {
                            if (token.Contains(":~"))
                            {
                                original_substring = variable_sep.ToString() + token + variable_sep.ToString();
                                is_range = token.Contains(",");
                                variable_name = token.Split(':')[0];
                                break;
                            }
                        }
                        string new_substring = variable_sep.ToString() + variable_name + ":~";
                        if (is_range)
                        {
                            new_substring = string.Format("{0}{1},{2}{3}", new_substring, range_A, range_B, variable_sep);
                        }
                        else
                        {
                            new_substring = string.Format("{0}{1}{2}", new_substring, range_A, variable_sep);
                        }
                        BatchLines[lineid] = BatchLines[lineid].Replace(original_substring, new_substring);
                    }
                    break;
                case "stringcorrupt":
                    corrupt_str();
                    break;
                case "stringreverse":
                    corrupt_str();
                    break;
                case "functionswap":
                    List<string> functions = new List<string>();
                    foreach (string line in BatchLines)
                    {
                        if ((line.Trim().StartsWith(":")) && (!(line.Trim().StartsWith("::"))))
                        {
                            functions.Add(line.Trim()[1..].Split(' ')[0]);
                        }
                    }
                    string[] tokens = { "goto", "call" };
                    List<int> function_lines = new List<int>();
                    for (int i = 0; i < BatchLines.Count; i++)
                    {
                        if ((!CheckTokens(tokens, BatchLines[i])) && (!BatchLines[i].Contains("&")))
                        {
                            function_lines.Add(i);
                        }
                    }
                    rawstrength = (int)(((double)strength / 10000.0) * (double)function_lines.Count);
                    for (int x = 0; x < rawstrength; x++)
                    {
                        int line = function_lines[r.Next(0, function_lines.Count)];
                        string replacement_function = functions[r.Next(0, functions.Count)];
                        string line_str = BatchLines[line];
                        string cmd_prefix = "";
                        string cmd_suffix = "";
                        bool set_prefix = true;
                        string command = "";
                        foreach (string token in line_str.Split(' '))
                        {
                            if (CheckTokens(tokens, token))
                            {
                                if (set_prefix)
                                {
                                    cmd_prefix = cmd_prefix + token + " ";
                                }
                                else
                                {
                                    cmd_suffix = cmd_suffix + " ";
                                }
                            }
                            else
                            {
                                command = token;
                                set_prefix = false;
                            }
                        }
                        try
                        {
                            line_str = cmd_prefix + command + " :" + replacement_function + " " + cmd_suffix[..1];
                            BatchLines[line] = line_str;
                        }
                        catch
                        {

                        }
                    }
                    break;
                case "colorswap":
                    // create a list of all possible color values (00-FF in hex to string)
                    List<string> color_values = new List<string>();
                    for (int i = 0; i < 256; i++)
                    {
                        color_values.Add(i.ToString("X2").ToLower());
                    }
                    // list of lines, which contain color references
                    List<int> color_lines = new List<int>();
                    foreach (string color_value in color_values)
                    {
                        if (string.Join("", BatchLines).ToLower().Contains(color_value))
                        {
                            for (int j = 0; j < BatchLines.Count; j++)
                            {
                                if ((BatchLines[j].ToLower().Contains(color_value)) && (BatchLines[j].ToLower().Contains("color")))
                                {
                                    color_lines.Add(j);
                                }
                            }
                        }
                    }
                    rawstrength = (int)(((double)strength / 10000.0) * (double)color_lines.Count);
                    for (int k = 0; k < rawstrength; k++)
                    {
                        int color_line = color_lines[r.Next(0, color_lines.Count)];
                        string replaced_line = BatchLines[color_line];
                        foreach (string s in color_values)
                        {
                            if (BatchLines[color_line].ToLower().Contains(s))
                            {
                                replaced_line = replaced_line.ToLower().Replace(s, color_values[r.Next(0, 255)]);
                            }
                        }
                        BatchLines[color_line] = replaced_line;
                    }
                    break;
            }
            finished = true;
        }

        // Corruptor function
        private void corruptButton_Click(object sender, EventArgs e)
        {
            // calculate the amount of lines to change/swap depending on the strength value
            rawstrength = (int)(((double)strengthBar.Value / 10000.0) * (double)BatchLines.Count);
            ThreadStart ts = new ThreadStart(corrupt_background);
            Thread t = new Thread(ts);
            finished = false;
            t.Start();
            waitForThread.Enabled = true;
            previewGroup.Enabled = false;
            corruptionsGroup.Enabled = false;
            closeButton.Enabled = false;
            openBatchfileButton.Enabled = false;
            browseButton.Enabled = false;
            batchfilePath.Enabled = false;
            this.UseWaitCursor = true;
        }

        // Check if a line contains disallowed tokens for line swap corruptions
        bool CheckTokens(string[] blacklist, string a)
        {
            foreach (string blacktoken in blacklist)
            {
                if (a.ToLower().Contains(blacktoken))
                {
                    return false;
                }
            }
            return true;
        }

        // Update label text while scrolling the trackbar
        private void strengthBar_Scroll(object sender, EventArgs e)
        {
            strengthLabel.Text = string.Format("Strength: {0}%", (double)strengthBar.Value/100.0);
            strength = strengthBar.Value;
        }

        // To save corrupted batch file
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveCorruptedFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveCorruptedFile.FileName, BatchLines.ToArray(), encoding);
                MessageBox.Show(string.Format("The file was saved as \"{0}\"", saveCorruptedFile.FileName), "MessBatch batch file corruptor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                justSaveButton.Enabled = true;
            } else
            {
                MessageBox.Show("The file was not saved.", "MessBatch batch file corruptor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(saveCorruptedFile.FileName, BatchLines.ToArray(), encoding);
            MessageBox.Show(string.Format("The file was saved as \"{0}\"", saveCorruptedFile.FileName), "MessBatch batch file corruptor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void previewBox_KeyDown(object sender, KeyEventArgs e)
        {
            BatchLines.Clear();
            BatchLines.AddRange(previewBox.Text.Split("\r\n"));
        }

        private void waitForThread_Tick(object sender, EventArgs e)
        {
            if (finished)
            {
                this.UseWaitCursor = false;
                finished = false;
                previewGroup.Enabled = true;
                corruptionsGroup.Enabled = true;
                closeButton.Enabled = true;
                openBatchfileButton.Enabled = true;
                browseButton.Enabled = true;
                batchfilePath.Enabled = true;
                waitForThread.Enabled = false;
                UpdateText();
                //MessageBox.Show("Corruption finished", "MessBatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CorruptionTypeSet(object sender, EventArgs e)
        {
            if (lineSwapperRadio.Checked)
            {
                ctype = "lineswap";
            }
            else if (functionSwapRadio.Checked)
            {
                ctype = "functionswap";
            }
            else if (stringCorruptorRadio.Checked)
            {
                ctype = "stringcorrupt";
            }
            else if (substringCorruptorRadio.Checked)
            {
                ctype = "substring";
            }
            else if (stringReverserRadio.Checked)
            {
                ctype = "stringreverse";
            }
            else if (colorSwapperRadio.Checked)
            {
                ctype = "colorswap";
            }
        }
    }
}
