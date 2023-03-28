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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dGVFirstLastNullable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVFollow = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVTransitions = new System.Windows.Forms.DataGridView();
            this.lTransitions = new System.Windows.Forms.Label();
            this.lFirstLastNullable = new System.Windows.Forms.Label();
            this.lFollow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFirstLastNullable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFollow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVTransitions)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVFirstLastNullable
            // 
            this.dGVFirstLastNullable.AllowUserToAddRows = false;
            this.dGVFirstLastNullable.AllowUserToDeleteRows = false;
            this.dGVFirstLastNullable.AllowUserToResizeColumns = false;
            this.dGVFirstLastNullable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVFirstLastNullable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVFirstLastNullable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVFirstLastNullable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVFirstLastNullable.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVFirstLastNullable.Location = new System.Drawing.Point(22, 53);
            this.dGVFirstLastNullable.Name = "dGVFirstLastNullable";
            this.dGVFirstLastNullable.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dGVFirstLastNullable.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVFirstLastNullable.RowTemplate.Height = 25;
            this.dGVFirstLastNullable.Size = new System.Drawing.Size(384, 229);
            this.dGVFirstLastNullable.TabIndex = 0;
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
            // dGVFollow
            // 
            this.dGVFollow.AllowUserToAddRows = false;
            this.dGVFollow.AllowUserToDeleteRows = false;
            this.dGVFollow.AllowUserToResizeColumns = false;
            this.dGVFollow.AllowUserToResizeRows = false;
            this.dGVFollow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVFollow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVFollow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6});
            this.dGVFollow.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVFollow.Location = new System.Drawing.Point(441, 53);
            this.dGVFollow.Name = "dGVFollow";
            this.dGVFollow.ReadOnly = true;
            this.dGVFollow.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVFollow.RowTemplate.Height = 25;
            this.dGVFollow.Size = new System.Drawing.Size(384, 229);
            this.dGVFollow.TabIndex = 1;
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
            // dGVTransitions
            // 
            this.dGVTransitions.AllowUserToAddRows = false;
            this.dGVTransitions.AllowUserToDeleteRows = false;
            this.dGVTransitions.AllowUserToResizeColumns = false;
            this.dGVTransitions.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVTransitions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVTransitions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVTransitions.DefaultCellStyle = dataGridViewCellStyle5;
            this.dGVTransitions.Location = new System.Drawing.Point(22, 333);
            this.dGVTransitions.Name = "dGVTransitions";
            this.dGVTransitions.ReadOnly = true;
            this.dGVTransitions.RowHeadersVisible = false;
            this.dGVTransitions.RowTemplate.Height = 25;
            this.dGVTransitions.Size = new System.Drawing.Size(803, 229);
            this.dGVTransitions.TabIndex = 2;
            // 
            // lTransitions
            // 
            this.lTransitions.AutoSize = true;
            this.lTransitions.Font = new System.Drawing.Font("Segoe UI Variable Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lTransitions.ForeColor = System.Drawing.Color.Black;
            this.lTransitions.Location = new System.Drawing.Point(22, 298);
            this.lTransitions.Name = "lTransitions";
            this.lTransitions.Size = new System.Drawing.Size(139, 32);
            this.lTransitions.TabIndex = 3;
            this.lTransitions.Text = "Transitions";
            // 
            // lFirstLastNullable
            // 
            this.lFirstLastNullable.AutoSize = true;
            this.lFirstLastNullable.Font = new System.Drawing.Font("Segoe UI Variable Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lFirstLastNullable.ForeColor = System.Drawing.Color.Black;
            this.lFirstLastNullable.Location = new System.Drawing.Point(22, 18);
            this.lFirstLastNullable.Name = "lFirstLastNullable";
            this.lFirstLastNullable.Size = new System.Drawing.Size(232, 32);
            this.lFirstLastNullable.TabIndex = 4;
            this.lFirstLastNullable.Text = "First, Last, Nullable";
            // 
            // lFollow
            // 
            this.lFollow.AutoSize = true;
            this.lFollow.Font = new System.Drawing.Font("Segoe UI Variable Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lFollow.ForeColor = System.Drawing.Color.Black;
            this.lFollow.Location = new System.Drawing.Point(441, 18);
            this.lFollow.Name = "lFollow";
            this.lFollow.Size = new System.Drawing.Size(89, 32);
            this.lFollow.TabIndex = 5;
            this.lFollow.Text = "Follow";
            // 
            // AutomatonData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 574);
            this.Controls.Add(this.lFollow);
            this.Controls.Add(this.lFirstLastNullable);
            this.Controls.Add(this.lTransitions);
            this.Controls.Add(this.dGVTransitions);
            this.Controls.Add(this.dGVFollow);
            this.Controls.Add(this.dGVFirstLastNullable);
            this.Name = "AutomatonData";
            this.Text = "AutomatonData";
            ((System.ComponentModel.ISupportInitialize)(this.dGVFirstLastNullable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFollow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVTransitions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Label lTransitions;
        private Label lFirstLastNullable;
        private Label lFollow;
    }
}