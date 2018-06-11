namespace LostContactFinder._01_Automated
{
    partial class SearchDataBaseForm
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
            this.GbxDBSearchMode = new System.Windows.Forms.GroupBox();
            this.BtnSearchDBSMode = new System.Windows.Forms.Button();
            this.GbxFileEntrySMode = new System.Windows.Forms.GroupBox();
            this.LblFileInSmode = new System.Windows.Forms.Label();
            this.BtnLoadFileSMode = new System.Windows.Forms.Button();
            this.RbtnFileEntrySMode = new System.Windows.Forms.RadioButton();
            this.GbxSingleEntrySMode = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SingleFileSMode = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dbView = new System.Windows.Forms.DataGridView();
            this.Btnsave2File = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GbxDBSearchMode.SuspendLayout();
            this.GbxFileEntrySMode.SuspendLayout();
            this.GbxSingleEntrySMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbView)).BeginInit();
            this.SuspendLayout();
            // 
            // GbxDBSearchMode
            // 
            this.GbxDBSearchMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GbxDBSearchMode.Controls.Add(this.RbtnFileEntrySMode);
            this.GbxDBSearchMode.Controls.Add(this.GbxSingleEntrySMode);
            this.GbxDBSearchMode.Controls.Add(this.SingleFileSMode);
            this.GbxDBSearchMode.Controls.Add(this.BtnSearchDBSMode);
            this.GbxDBSearchMode.Controls.Add(this.GbxFileEntrySMode);
            this.GbxDBSearchMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GbxDBSearchMode.Location = new System.Drawing.Point(4, -2);
            this.GbxDBSearchMode.Name = "GbxDBSearchMode";
            this.GbxDBSearchMode.Size = new System.Drawing.Size(540, 294);
            this.GbxDBSearchMode.TabIndex = 4;
            this.GbxDBSearchMode.TabStop = false;
            this.GbxDBSearchMode.Text = "Database Search Mode";
            // 
            // BtnSearchDBSMode
            // 
            this.BtnSearchDBSMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearchDBSMode.Location = new System.Drawing.Point(343, 229);
            this.BtnSearchDBSMode.Name = "BtnSearchDBSMode";
            this.BtnSearchDBSMode.Size = new System.Drawing.Size(175, 59);
            this.BtnSearchDBSMode.TabIndex = 3;
            this.BtnSearchDBSMode.Text = "Search Database";
            this.BtnSearchDBSMode.UseVisualStyleBackColor = true;
            // 
            // GbxFileEntrySMode
            // 
            this.GbxFileEntrySMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GbxFileEntrySMode.Controls.Add(this.LblFileInSmode);
            this.GbxFileEntrySMode.Controls.Add(this.BtnLoadFileSMode);
            this.GbxFileEntrySMode.Location = new System.Drawing.Point(8, 149);
            this.GbxFileEntrySMode.Name = "GbxFileEntrySMode";
            this.GbxFileEntrySMode.Size = new System.Drawing.Size(526, 72);
            this.GbxFileEntrySMode.TabIndex = 2;
            this.GbxFileEntrySMode.TabStop = false;
            // 
            // LblFileInSmode
            // 
            this.LblFileInSmode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LblFileInSmode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFileInSmode.Location = new System.Drawing.Point(117, 13);
            this.LblFileInSmode.Name = "LblFileInSmode";
            this.LblFileInSmode.Size = new System.Drawing.Size(403, 53);
            this.LblFileInSmode.TabIndex = 2;
            this.LblFileInSmode.Text = "No File Loaded";
            this.LblFileInSmode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnLoadFileSMode
            // 
            this.BtnLoadFileSMode.Location = new System.Drawing.Point(8, 25);
            this.BtnLoadFileSMode.Name = "BtnLoadFileSMode";
            this.BtnLoadFileSMode.Size = new System.Drawing.Size(103, 27);
            this.BtnLoadFileSMode.TabIndex = 1;
            this.BtnLoadFileSMode.Text = "Load File";
            this.BtnLoadFileSMode.UseVisualStyleBackColor = true;
            // 
            // RbtnFileEntrySMode
            // 
            this.RbtnFileEntrySMode.AutoSize = true;
            this.RbtnFileEntrySMode.BackColor = System.Drawing.Color.Cyan;
            this.RbtnFileEntrySMode.Location = new System.Drawing.Point(19, 135);
            this.RbtnFileEntrySMode.Name = "RbtnFileEntrySMode";
            this.RbtnFileEntrySMode.Size = new System.Drawing.Size(71, 17);
            this.RbtnFileEntrySMode.TabIndex = 0;
            this.RbtnFileEntrySMode.TabStop = true;
            this.RbtnFileEntrySMode.Text = "File Entry:";
            this.RbtnFileEntrySMode.UseVisualStyleBackColor = false;
            // 
            // GbxSingleEntrySMode
            // 
            this.GbxSingleEntrySMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.GbxSingleEntrySMode.Controls.Add(this.label1);
            this.GbxSingleEntrySMode.Controls.Add(this.textBox1);
            this.GbxSingleEntrySMode.Location = new System.Drawing.Point(8, 45);
            this.GbxSingleEntrySMode.Name = "GbxSingleEntrySMode";
            this.GbxSingleEntrySMode.Size = new System.Drawing.Size(525, 75);
            this.GbxSingleEntrySMode.TabIndex = 0;
            this.GbxSingleEntrySMode.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Number";
            // 
            // SingleFileSMode
            // 
            this.SingleFileSMode.AutoSize = true;
            this.SingleFileSMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.SingleFileSMode.Location = new System.Drawing.Point(16, 28);
            this.SingleFileSMode.Name = "SingleFileSMode";
            this.SingleFileSMode.Size = new System.Drawing.Size(84, 17);
            this.SingleFileSMode.TabIndex = 0;
            this.SingleFileSMode.TabStop = true;
            this.SingleFileSMode.Text = "Single Entry:";
            this.SingleFileSMode.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 20);
            this.textBox1.TabIndex = 1;
            // 
            // dbView
            // 
            this.dbView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbView.Location = new System.Drawing.Point(4, 320);
            this.dbView.Name = "dbView";
            this.dbView.Size = new System.Drawing.Size(540, 216);
            this.dbView.TabIndex = 5;
            // 
            // Btnsave2File
            // 
            this.Btnsave2File.Location = new System.Drawing.Point(395, 537);
            this.Btnsave2File.Name = "Btnsave2File";
            this.Btnsave2File.Size = new System.Drawing.Size(148, 32);
            this.Btnsave2File.TabIndex = 6;
            this.Btnsave2File.Text = "Save To File";
            this.Btnsave2File.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 537);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "View Summary";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SearchDataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 572);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btnsave2File);
            this.Controls.Add(this.dbView);
            this.Controls.Add(this.GbxDBSearchMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SearchDataBaseForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchDataBaseForm";
            this.GbxDBSearchMode.ResumeLayout(false);
            this.GbxDBSearchMode.PerformLayout();
            this.GbxFileEntrySMode.ResumeLayout(false);
            this.GbxSingleEntrySMode.ResumeLayout(false);
            this.GbxSingleEntrySMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxDBSearchMode;
        private System.Windows.Forms.Button BtnSearchDBSMode;
        private System.Windows.Forms.GroupBox GbxFileEntrySMode;
        private System.Windows.Forms.Label LblFileInSmode;
        private System.Windows.Forms.Button BtnLoadFileSMode;
        private System.Windows.Forms.RadioButton RbtnFileEntrySMode;
        private System.Windows.Forms.GroupBox GbxSingleEntrySMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton SingleFileSMode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dbView;
        private System.Windows.Forms.Button Btnsave2File;
        private System.Windows.Forms.Button button1;
    }
}