
namespace MessBatch
{
    partial class Compare
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.originalPreview = new MessBatch.SyncTextBox();
            this.corruptedPreview = new MessBatch.SyncTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // originalPreview
            // 
            this.originalPreview.BackColor = System.Drawing.Color.Black;
            this.originalPreview.Buddy = this.corruptedPreview;
            this.originalPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalPreview.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.originalPreview.ForeColor = System.Drawing.Color.Cyan;
            this.originalPreview.Location = new System.Drawing.Point(0, 0);
            this.originalPreview.Multiline = true;
            this.originalPreview.Name = "originalPreview";
            this.originalPreview.ReadOnly = true;
            this.originalPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.originalPreview.Size = new System.Drawing.Size(287, 305);
            this.originalPreview.TabIndex = 0;
            this.originalPreview.WordWrap = false;
            // 
            // corruptedPreview
            // 
            this.corruptedPreview.BackColor = System.Drawing.Color.Black;
            this.corruptedPreview.Buddy = this.originalPreview;
            this.corruptedPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.corruptedPreview.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.corruptedPreview.ForeColor = System.Drawing.Color.Lime;
            this.corruptedPreview.Location = new System.Drawing.Point(0, 0);
            this.corruptedPreview.Multiline = true;
            this.corruptedPreview.Name = "corruptedPreview";
            this.corruptedPreview.ReadOnly = true;
            this.corruptedPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.corruptedPreview.Size = new System.Drawing.Size(293, 305);
            this.corruptedPreview.TabIndex = 1;
            this.corruptedPreview.WordWrap = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.originalPreview);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.corruptedPreview);
            this.splitContainer1.Size = new System.Drawing.Size(584, 305);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.TabIndex = 2;
            // 
            // Compare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 305);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Compare";
            this.Text = "Compare with original";
            this.Load += new System.EventHandler(this.Compare_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal SyncTextBox originalPreview;
        internal SyncTextBox corruptedPreview;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}