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
            this.label1.Location = new System.Drawing.Point(325, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Language Scanner";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnOpenFile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpenFile.Location = new System.Drawing.Point(118, 184);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(256, 57);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Open file";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tBFilePath
            // 
            this.tBFilePath.Location = new System.Drawing.Point(405, 189);
            this.tBFilePath.Name = "tBFilePath";
            this.tBFilePath.ReadOnly = true;
            this.tBFilePath.Size = new System.Drawing.Size(597, 43);
            this.tBFilePath.TabIndex = 2;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnAnalyze.Enabled = false;
            this.btnAnalyze.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAnalyze.Location = new System.Drawing.Point(420, 294);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(256, 57);
            this.btnAnalyze.TabIndex = 3;
            this.btnAnalyze.Text = "Analyze grammar";
            this.btnAnalyze.UseVisualStyleBackColor = false;
            // 
            // rTBResult
            // 
            this.rTBResult.Location = new System.Drawing.Point(118, 397);
            this.rTBResult.Name = "rTBResult";
            this.rTBResult.ReadOnly = true;
            this.rTBResult.Size = new System.Drawing.Size(878, 279);
            this.rTBResult.TabIndex = 4;
            this.rTBResult.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1144, 784);
            this.Controls.Add(this.rTBResult);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.tBFilePath);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.label1);
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