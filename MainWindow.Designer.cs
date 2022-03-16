
namespace MessBatch
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.batchfilePath = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.openBatchfile = new System.Windows.Forms.OpenFileDialog();
            this.openBatchfileButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.previewBox = new System.Windows.Forms.TextBox();
            this.previewGroup = new System.Windows.Forms.GroupBox();
            this.corruptionsGroup = new System.Windows.Forms.GroupBox();
            this.justSaveButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.corruptButton = new System.Windows.Forms.Button();
            this.strengthBar = new System.Windows.Forms.TrackBar();
            this.strengthLabel = new System.Windows.Forms.Label();
            this.corruptionSelectorPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lineSwapperRadio = new System.Windows.Forms.RadioButton();
            this.functionSwapRadio = new System.Windows.Forms.RadioButton();
            this.stringCorruptorRadio = new System.Windows.Forms.RadioButton();
            this.substringCorruptorRadio = new System.Windows.Forms.RadioButton();
            this.stringReverserRadio = new System.Windows.Forms.RadioButton();
            this.colorSwapperRadio = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveCorruptedFile = new System.Windows.Forms.SaveFileDialog();
            this.waitForThread = new System.Windows.Forms.Timer(this.components);
            this.previewGroup.SuspendLayout();
            this.corruptionsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.strengthBar)).BeginInit();
            this.corruptionSelectorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // batchfilePath
            // 
            this.batchfilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchfilePath.Location = new System.Drawing.Point(12, 12);
            this.batchfilePath.Name = "batchfilePath";
            this.batchfilePath.Size = new System.Drawing.Size(399, 23);
            this.batchfilePath.TabIndex = 0;
            this.batchfilePath.TextChanged += new System.EventHandler(this.batchfilePath_TextChanged);
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(579, 12);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "&Browse..";
            this.toolTip1.SetToolTip(this.browseButton, "Browse for the file. This will not open it.");
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // openBatchfile
            // 
            this.openBatchfile.DefaultExt = "bat";
            this.openBatchfile.Filter = "Batch files or Windows NT command scripts|*.bat;*.cmd|All files|*.*";
            // 
            // openBatchfileButton
            // 
            this.openBatchfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openBatchfileButton.Enabled = false;
            this.openBatchfileButton.Location = new System.Drawing.Point(498, 12);
            this.openBatchfileButton.Name = "openBatchfileButton";
            this.openBatchfileButton.Size = new System.Drawing.Size(75, 23);
            this.openBatchfileButton.TabIndex = 2;
            this.openBatchfileButton.Text = "(Re)&open";
            this.toolTip1.SetToolTip(this.openBatchfileButton, "Open this file. This will lock the file, while it\'s being loaded.");
            this.openBatchfileButton.UseVisualStyleBackColor = true;
            this.openBatchfileButton.Click += new System.EventHandler(this.openBatchfileButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Enabled = false;
            this.closeButton.Location = new System.Drawing.Point(417, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "&Close";
            this.toolTip1.SetToolTip(this.closeButton, "Closes the file.");
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.Black;
            this.previewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewBox.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.previewBox.ForeColor = System.Drawing.Color.Lime;
            this.previewBox.Location = new System.Drawing.Point(3, 19);
            this.previewBox.Multiline = true;
            this.previewBox.Name = "previewBox";
            this.previewBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.previewBox.Size = new System.Drawing.Size(355, 258);
            this.previewBox.TabIndex = 5;
            this.previewBox.Text = "Please open a batch file";
            this.previewBox.WordWrap = false;
            this.previewBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.previewBox_KeyDown);
            // 
            // previewGroup
            // 
            this.previewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewGroup.Controls.Add(this.previewBox);
            this.previewGroup.Enabled = false;
            this.previewGroup.Location = new System.Drawing.Point(12, 41);
            this.previewGroup.Name = "previewGroup";
            this.previewGroup.Size = new System.Drawing.Size(361, 280);
            this.previewGroup.TabIndex = 6;
            this.previewGroup.TabStop = false;
            this.previewGroup.Text = "Preview";
            // 
            // corruptionsGroup
            // 
            this.corruptionsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.corruptionsGroup.Controls.Add(this.justSaveButton);
            this.corruptionsGroup.Controls.Add(this.saveButton);
            this.corruptionsGroup.Controls.Add(this.corruptButton);
            this.corruptionsGroup.Controls.Add(this.strengthBar);
            this.corruptionsGroup.Controls.Add(this.strengthLabel);
            this.corruptionsGroup.Controls.Add(this.corruptionSelectorPanel);
            this.corruptionsGroup.Enabled = false;
            this.corruptionsGroup.Location = new System.Drawing.Point(379, 41);
            this.corruptionsGroup.Name = "corruptionsGroup";
            this.corruptionsGroup.Size = new System.Drawing.Size(275, 277);
            this.corruptionsGroup.TabIndex = 7;
            this.corruptionsGroup.TabStop = false;
            this.corruptionsGroup.Text = "Corruptions";
            // 
            // justSaveButton
            // 
            this.justSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.justSaveButton.Enabled = false;
            this.justSaveButton.Location = new System.Drawing.Point(32, 248);
            this.justSaveButton.Name = "justSaveButton";
            this.justSaveButton.Size = new System.Drawing.Size(75, 23);
            this.justSaveButton.TabIndex = 3;
            this.justSaveButton.Text = "&Save";
            this.justSaveButton.UseVisualStyleBackColor = true;
            this.justSaveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(113, 248);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save &as";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // corruptButton
            // 
            this.corruptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.corruptButton.Location = new System.Drawing.Point(194, 248);
            this.corruptButton.Name = "corruptButton";
            this.corruptButton.Size = new System.Drawing.Size(75, 23);
            this.corruptButton.TabIndex = 5;
            this.corruptButton.Text = "Co&rrupt!";
            this.corruptButton.UseVisualStyleBackColor = true;
            this.corruptButton.Click += new System.EventHandler(this.corruptButton_Click);
            // 
            // strengthBar
            // 
            this.strengthBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.strengthBar.Location = new System.Drawing.Point(6, 124);
            this.strengthBar.Maximum = 10000;
            this.strengthBar.Minimum = 1;
            this.strengthBar.Name = "strengthBar";
            this.strengthBar.Size = new System.Drawing.Size(266, 45);
            this.strengthBar.TabIndex = 2;
            this.strengthBar.TickFrequency = 1000;
            this.strengthBar.Value = 1;
            this.strengthBar.Scroll += new System.EventHandler(this.strengthBar_Scroll);
            // 
            // strengthLabel
            // 
            this.strengthLabel.AutoSize = true;
            this.strengthLabel.Location = new System.Drawing.Point(6, 106);
            this.strengthLabel.Name = "strengthLabel";
            this.strengthLabel.Size = new System.Drawing.Size(89, 15);
            this.strengthLabel.TabIndex = 1;
            this.strengthLabel.Text = "Strength: 0,01%";
            // 
            // corruptionSelectorPanel
            // 
            this.corruptionSelectorPanel.Controls.Add(this.lineSwapperRadio);
            this.corruptionSelectorPanel.Controls.Add(this.functionSwapRadio);
            this.corruptionSelectorPanel.Controls.Add(this.stringCorruptorRadio);
            this.corruptionSelectorPanel.Controls.Add(this.substringCorruptorRadio);
            this.corruptionSelectorPanel.Controls.Add(this.stringReverserRadio);
            this.corruptionSelectorPanel.Controls.Add(this.colorSwapperRadio);
            this.corruptionSelectorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.corruptionSelectorPanel.Location = new System.Drawing.Point(3, 19);
            this.corruptionSelectorPanel.Name = "corruptionSelectorPanel";
            this.corruptionSelectorPanel.Size = new System.Drawing.Size(269, 84);
            this.corruptionSelectorPanel.TabIndex = 0;
            // 
            // lineSwapperRadio
            // 
            this.lineSwapperRadio.AutoSize = true;
            this.lineSwapperRadio.Checked = true;
            this.lineSwapperRadio.Location = new System.Drawing.Point(3, 3);
            this.lineSwapperRadio.Name = "lineSwapperRadio";
            this.lineSwapperRadio.Size = new System.Drawing.Size(94, 19);
            this.lineSwapperRadio.TabIndex = 0;
            this.lineSwapperRadio.TabStop = true;
            this.lineSwapperRadio.Text = "Line swapper";
            this.toolTip1.SetToolTip(this.lineSwapperRadio, "Line swapper randomly swaps batch file lines, causing weird things to happen. Thi" +
        "s is also a more destructive option.");
            this.lineSwapperRadio.UseVisualStyleBackColor = true;
            this.lineSwapperRadio.CheckedChanged += new System.EventHandler(this.CorruptionTypeSet);
            // 
            // functionSwapRadio
            // 
            this.functionSwapRadio.AutoSize = true;
            this.functionSwapRadio.Location = new System.Drawing.Point(103, 3);
            this.functionSwapRadio.Name = "functionSwapRadio";
            this.functionSwapRadio.Size = new System.Drawing.Size(102, 19);
            this.functionSwapRadio.TabIndex = 1;
            this.functionSwapRadio.Text = "Function swap";
            this.toolTip1.SetToolTip(this.functionSwapRadio, "Function swap changes which functions/labels the goto and call commands refer to," +
        " while making sure each reference is valid.");
            this.functionSwapRadio.UseVisualStyleBackColor = true;
            this.functionSwapRadio.CheckedChanged += new System.EventHandler(this.CorruptionTypeSet);
            // 
            // stringCorruptorRadio
            // 
            this.stringCorruptorRadio.AutoSize = true;
            this.stringCorruptorRadio.Location = new System.Drawing.Point(3, 28);
            this.stringCorruptorRadio.Name = "stringCorruptorRadio";
            this.stringCorruptorRadio.Size = new System.Drawing.Size(109, 19);
            this.stringCorruptorRadio.TabIndex = 2;
            this.stringCorruptorRadio.Text = "String corruptor";
            this.toolTip1.SetToolTip(this.stringCorruptorRadio, "String corruptor changes individual characters on strings.");
            this.stringCorruptorRadio.UseVisualStyleBackColor = true;
            this.stringCorruptorRadio.CheckedChanged += new System.EventHandler(this.CorruptionTypeSet);
            // 
            // substringCorruptorRadio
            // 
            this.substringCorruptorRadio.AutoSize = true;
            this.substringCorruptorRadio.Location = new System.Drawing.Point(118, 28);
            this.substringCorruptorRadio.Name = "substringCorruptorRadio";
            this.substringCorruptorRadio.Size = new System.Drawing.Size(128, 19);
            this.substringCorruptorRadio.TabIndex = 3;
            this.substringCorruptorRadio.Text = "Substring corruptor";
            this.toolTip1.SetToolTip(this.substringCorruptorRadio, "Substring corruptor changes the indexes on substrings (e.g. if the substring is %" +
        "variable:~0,4% it may get changed to %variable:~1,5%).");
            this.substringCorruptorRadio.UseVisualStyleBackColor = true;
            this.substringCorruptorRadio.CheckedChanged += new System.EventHandler(this.CorruptionTypeSet);
            // 
            // stringReverserRadio
            // 
            this.stringReverserRadio.AutoSize = true;
            this.stringReverserRadio.Location = new System.Drawing.Point(3, 53);
            this.stringReverserRadio.Name = "stringReverserRadio";
            this.stringReverserRadio.Size = new System.Drawing.Size(100, 19);
            this.stringReverserRadio.TabIndex = 4;
            this.stringReverserRadio.Text = "String reverser";
            this.toolTip1.SetToolTip(this.stringReverserRadio, "String reverser reverses strings randomly.");
            this.stringReverserRadio.UseVisualStyleBackColor = true;
            this.stringReverserRadio.CheckedChanged += new System.EventHandler(this.CorruptionTypeSet);
            // 
            // colorSwapperRadio
            // 
            this.colorSwapperRadio.AutoSize = true;
            this.colorSwapperRadio.Location = new System.Drawing.Point(109, 53);
            this.colorSwapperRadio.Name = "colorSwapperRadio";
            this.colorSwapperRadio.Size = new System.Drawing.Size(101, 19);
            this.colorSwapperRadio.TabIndex = 5;
            this.colorSwapperRadio.Text = "Color swapper";
            this.toolTip1.SetToolTip(this.colorSwapperRadio, "Color swapper randomizes colors (e.g. if the color is white on black, it may get " +
        "changed to green on yellow).");
            this.colorSwapperRadio.UseVisualStyleBackColor = true;
            this.colorSwapperRadio.CheckedChanged += new System.EventHandler(this.CorruptionTypeSet);
            // 
            // saveCorruptedFile
            // 
            this.saveCorruptedFile.DefaultExt = "bat";
            this.saveCorruptedFile.Filter = "Batch file|*.bat|Windows NT command script|*.cmd|All files|*.*";
            // 
            // waitForThread
            // 
            this.waitForThread.Tick += new System.EventHandler(this.waitForThread_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 333);
            this.Controls.Add(this.corruptionsGroup);
            this.Controls.Add(this.previewGroup);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.openBatchfileButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.batchfilePath);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "MessBatch - A semi-nondestructive batch file corruptor";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.previewGroup.ResumeLayout(false);
            this.previewGroup.PerformLayout();
            this.corruptionsGroup.ResumeLayout(false);
            this.corruptionsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.strengthBar)).EndInit();
            this.corruptionSelectorPanel.ResumeLayout(false);
            this.corruptionSelectorPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox batchfilePath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.OpenFileDialog openBatchfile;
        private System.Windows.Forms.Button openBatchfileButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox previewBox;
        private System.Windows.Forms.GroupBox previewGroup;
        private System.Windows.Forms.GroupBox corruptionsGroup;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button corruptButton;
        private System.Windows.Forms.TrackBar strengthBar;
        private System.Windows.Forms.Label strengthLabel;
        private System.Windows.Forms.FlowLayoutPanel corruptionSelectorPanel;
        private System.Windows.Forms.RadioButton lineSwapperRadio;
        private System.Windows.Forms.RadioButton functionSwapRadio;
        private System.Windows.Forms.RadioButton stringCorruptorRadio;
        private System.Windows.Forms.RadioButton substringCorruptorRadio;
        private System.Windows.Forms.RadioButton stringReverserRadio;
        private System.Windows.Forms.RadioButton colorSwapperRadio;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SaveFileDialog saveCorruptedFile;
        private System.Windows.Forms.Button justSaveButton;
        private System.Windows.Forms.Timer waitForThread;
    }
}

