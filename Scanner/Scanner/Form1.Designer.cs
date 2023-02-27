namespace Scanner
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tBFilePath = new System.Windows.Forms.TextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.rTBResult = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(173, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Language Scanner";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnOpenFile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpenFile.Location = new System.Drawing.Point(63, 99);
            this.btnOpenFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(137, 31);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Open file";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tBFilePath
            // 
            this.tBFilePath.Location = new System.Drawing.Point(216, 102);
            this.tBFilePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tBFilePath.Name = "tBFilePath";
            this.tBFilePath.ReadOnly = true;
            this.tBFilePath.Size = new System.Drawing.Size(320, 27);
            this.tBFilePath.TabIndex = 2;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnAnalyze.Enabled = false;
            this.btnAnalyze.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAnalyze.Location = new System.Drawing.Point(224, 159);
            this.btnAnalyze.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(137, 31);
            this.btnAnalyze.TabIndex = 3;
            this.btnAnalyze.Text = "Analyze grammar";
            this.btnAnalyze.UseVisualStyleBackColor = false;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // rTBResult
            // 
            this.rTBResult.BackColor = System.Drawing.Color.White;
            this.rTBResult.Location = new System.Drawing.Point(63, 215);
            this.rTBResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rTBResult.Name = "rTBResult";
            this.rTBResult.ReadOnly = true;
            this.rTBResult.Size = new System.Drawing.Size(470, 153);
            this.rTBResult.TabIndex = 4;
            this.rTBResult.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(610, 424);
            this.Controls.Add(this.rTBResult);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.tBFilePath);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Language Scanner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnOpenFile;
        private TextBox tBFilePath;
        private Button btnAnalyze;
        private RichTextBox rTBResult;
        private OpenFileDialog openFileDialog1;
    }
}