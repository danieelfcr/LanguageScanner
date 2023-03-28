namespace Scanner
{
    partial class AutomatonData
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
            this.dGVFirstLastNullable = new System.Windows.Forms.DataGridView();
            this.dGVFollow = new System.Windows.Forms.DataGridView();
            this.dGVTransitions = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFirstLastNullable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFollow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVTransitions)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVFirstLastNullable
            // 
            this.dGVFirstLastNullable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVFirstLastNullable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dGVFirstLastNullable.Location = new System.Drawing.Point(22, 12);
            this.dGVFirstLastNullable.Name = "dGVFirstLastNullable";
            this.dGVFirstLastNullable.RowTemplate.Height = 25;
            this.dGVFirstLastNullable.Size = new System.Drawing.Size(384, 229);
            this.dGVFirstLastNullable.TabIndex = 0;
            // 
            // dGVFollow
            // 
            this.dGVFollow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVFollow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6});
            this.dGVFollow.Location = new System.Drawing.Point(441, 12);
            this.dGVFollow.Name = "dGVFollow";
            this.dGVFollow.RowTemplate.Height = 25;
            this.dGVFollow.Size = new System.Drawing.Size(384, 229);
            this.dGVFollow.TabIndex = 1;
            // 
            // dGVTransitions
            // 
            this.dGVTransitions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVTransitions.Location = new System.Drawing.Point(22, 256);
            this.dGVTransitions.Name = "dGVTransitions";
            this.dGVTransitions.RowTemplate.Height = 25;
            this.dGVTransitions.Size = new System.Drawing.Size(803, 229);
            this.dGVTransitions.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Symbol";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "First";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Last";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Nullable";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Symbol";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Follow";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // AutomatonData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 509);
            this.Controls.Add(this.dGVTransitions);
            this.Controls.Add(this.dGVFollow);
            this.Controls.Add(this.dGVFirstLastNullable);
            this.Name = "AutomatonData";
            this.Text = "AutomatonData";
            ((System.ComponentModel.ISupportInitialize)(this.dGVFirstLastNullable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFollow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVTransitions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dGVFirstLastNullable;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridView dGVFollow;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridView dGVTransitions;
    }
}