using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MessBatch
{
    public partial class MainWindow : Form
    {
        string[] descriptions =
        {
            "Line swapper randomly swaps batch file lines, causing weird things to happen. This is also a more destructive option.",
            "Function swap changes which functions/labels the goto and call commands refer to, while making sure each reference is valid.",
            "String corruptor changes individual characters on strings.",
            "Substring corruptor changes the indexes on substrings (e.g. if the substring is %variable:~0,4% it may get changed to %variable:~1,5%).",
            "String reverser reverses strings randomly.",
            "Color swapper randomizes colors (e.g. if the color is white on black, it may get changed to green on yellow)."
        };
        List<string> BatchLines = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openBatchfile.ShowDialog() == DialogResult.OK)
            {
                batchfilePath.Text = openBatchfile.FileName;
            }
        }

        private void openBatchfileButton_Click(object sender, EventArgs e)
        {
            closeButton.PerformClick();
            /*Encoding encoding;
            using (var reader = new StreamReader(batchfilePath.Text, Encoding.ASCII, true))
            {
                reader.Peek(); // you need this!
                encoding = reader.CurrentEncoding;
            }*/
            using (FileStream fs = new FileStream(batchfilePath.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, true))
                {
                    while (!sr.EndOfStream)
                    {
                        BatchLines.Add(sr.ReadLine());
                    }
                }
            }
            //BatchLines.AddRange(File.ReadAllLines(batchfilePath.Text, encoding));
            previewBox.Text = string.Join("\r\n", BatchLines);
            previewGroup.Enabled = true;
            closeButton.Enabled = true;
            corruptionsGroup.Enabled = true;
        }

        private void batchfilePath_TextChanged(object sender, EventArgs e)
        {
            openBatchfileButton.Enabled = File.Exists(batchfilePath.Text);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            BatchLines.Clear();
            closeButton.Enabled = false;
            previewGroup.Enabled = false;
            corruptionsGroup.Enabled = false;
        }

        private void SwapDescription(object sender, EventArgs e)
        {
            if (lineSwapperRadio.Checked)
            {
                corruptionDescription.Text = descriptions[0];
            }
            else if (functionSwapRadio.Checked)
            {
                corruptionDescription.Text = descriptions[1];
            }
            else if (stringCorruptorRadio.Checked)
            {
                corruptionDescription.Text = descriptions[2];
            }
            else if (substringCorruptorRadio.Checked)
            {
                corruptionDescription.Text = descriptions[3];
            }
            else if (stringReverserRadio.Checked)
            {
                corruptionDescription.Text = descriptions[4];
            }
            else if (colorSwapperRadio.Checked)
            {
                corruptionDescription.Text = descriptions[5];
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            corruptionDescription.Text = descriptions[0];
        }
    }
}
