namespace LostContactFinder._01_Automated
{
    partial class DisplayPreview
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
            this.dbGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CbxFName = new System.Windows.Forms.ComboBox();
            this.cbxLName = new System.Windows.Forms.ComboBox();
            this.CbxMidName = new System.Windows.Forms.ComboBox();
            this.cbxPhone1 = new System.Windows.Forms.ComboBox();
            this.cbxPhone2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxPhone3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxPhone4 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxEmail1 = new System.Windows.Forms.ComboBox();
            this.cbxEmail2 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClearMatch = new System.Windows.Forms.Button();
            this.btnAutoMatch = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxPhone5 = new System.Windows.Forms.ComboBox();
            this.cbxPhone6 = new System.Windows.Forms.ComboBox();
            this.btnPreviewFinalTable = new System.Windows.Forms.Button();
            this.tbxDebuging = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dbGridView
            // 
            this.dbGridView.AllowUserToAddRows = false;
            this.dbGridView.AllowUserToDeleteRows = false;
            this.dbGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridView.Location = new System.Drawing.Point(9, 258);
            this.dbGridView.Name = "dbGridView";
            this.dbGridView.ReadOnly = true;
            this.dbGridView.Size = new System.Drawing.Size(825, 302);
            this.dbGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(14, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name:------------------------>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(15, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:---------------------->";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Location = new System.Drawing.Point(14, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Middle Name:------------------>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Location = new System.Drawing.Point(12, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Phone 1:-------------------------->";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Location = new System.Drawing.Point(15, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Phone 2:--------------------------->";
            // 
            // CbxFName
            // 
            this.CbxFName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxFName.FormattingEnabled = true;
            this.CbxFName.Location = new System.Drawing.Point(151, 47);
            this.CbxFName.Name = "CbxFName";
            this.CbxFName.Size = new System.Drawing.Size(239, 21);
            this.CbxFName.TabIndex = 6;
            this.CbxFName.SelectedIndexChanged += new System.EventHandler(this.CbxFName_SelectedIndexChanged);
            // 
            // cbxLName
            // 
            this.cbxLName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLName.FormattingEnabled = true;
            this.cbxLName.Location = new System.Drawing.Point(151, 78);
            this.cbxLName.Name = "cbxLName";
            this.cbxLName.Size = new System.Drawing.Size(239, 21);
            this.cbxLName.TabIndex = 7;
            this.cbxLName.SelectedIndexChanged += new System.EventHandler(this.CbxFName_SelectedIndexChanged);
            // 
            // CbxMidName
            // 
            this.CbxMidName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxMidName.FormattingEnabled = true;
            this.CbxMidName.Items.AddRange(new object[] {
            "Not Set"});
            this.CbxMidName.Location = new System.Drawing.Point(151, 107);
            this.CbxMidName.Name = "CbxMidName";
            this.CbxMidName.Size = new System.Drawing.Size(239, 21);
            this.CbxMidName.TabIndex = 8;
            this.CbxMidName.SelectedIndexChanged += new System.EventHandler(this.CbxFName_SelectedIndexChanged);
            // 
            // cbxPhone1
            // 
            this.cbxPhone1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPhone1.FormattingEnabled = true;
            this.cbxPhone1.Items.AddRange(new object[] {
            "Not Set"});
            this.cbxPhone1.Location = new System.Drawing.Point(151, 139);
            this.cbxPhone1.Name = "cbxPhone1";
            this.cbxPhone1.Size = new System.Drawing.Size(239, 21);
            this.cbxPhone1.TabIndex = 9;
            this.cbxPhone1.SelectedIndexChanged += new System.EventHandler(this.CbxFName_SelectedIndexChanged);
            // 
            // cbxPhone2
            // 
            this.cbxPhone2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPhone2.FormattingEnabled = true;
            this.cbxPhone2.Location = new System.Drawing.Point(151, 175);
            this.cbxPhone2.Name = "cbxPhone2";
            this.cbxPhone2.Size = new System.Drawing.Size(239, 21);
            this.cbxPhone2.TabIndex = 10;
            this.cbxPhone2.SelectedIndexChanged += new System.EventHandler(this.CbxFName_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Program Fields     |";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(151, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Loaded File Fields";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label8.Location = new System.Drawing.Point(13, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Phone 3:--------------------------->";
            // 
            // cbxPhone3
            // 
            this.cbxPhone3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPhone3.FormattingEnabled = true;
            this.cbxPhone3.Location = new System.Drawing.Point(154, 203);
            this.cbxPhone3.Name = "cbxPhone3";
            this.cbxPhone3.Size = new System.Drawing.Size(236, 21);
            this.cbxPhone3.TabIndex = 14;
            this.cbxPhone3.SelectedIndexChanged += new System.EventHandler(this.CbxFName_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label9.Location = new System.Drawing.Point(12, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Phone 4:--------------------------->";
            // 
            // cbxPhone4
            // 
            this.cbxPhone4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPhone4.FormattingEnabled = true;
            this.cbxPhone4.Location = new System.Drawing.Point(156, 231);
            this.cbxPhone4.Name = "cbxPhone4";
            this.cbxPhone4.Size = new System.Drawing.Size(234, 21);
            this.cbxPhone4.TabIndex = 16;
            this.cbxPhone4.SelectedIndexChanged += new System.EventHandler(this.CbxFName_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(397, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(1, 250);
            this.label10.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(414, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Email 1:------------------------------>";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(415, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Email 2:------------------------------->";
            // 
            // cbxEmail1
            // 
            this.cbxEmail1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEmail1.FormattingEnabled = true;
            this.cbxEmail1.Location = new System.Drawing.Point(572, 61);
            this.cbxEmail1.Name = "cbxEmail1";
            this.cbxEmail1.Size = new System.Drawing.Size(262, 21);
            this.cbxEmail1.TabIndex = 20;
            this.cbxEmail1.SelectedIndexChanged += new System.EventHandler(this.CbxFName_SelectedIndexChanged);
            // 
            // cbxEmail2
            // 
            this.cbxEmail2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEmail2.FormattingEnabled = true;
            this.cbxEmail2.Location = new System.Drawing.Point(572, 91);
            this.cbxEmail2.Name = "cbxEmail2";
            this.cbxEmail2.Size = new System.Drawing.Size(262, 21);
            this.cbxEmail2.TabIndex = 21;
            this.cbxEmail2.SelectedIndexChanged += new System.EventHandler(this.CbxFName_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label13.Location = new System.Drawing.Point(418, 124);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(416, 1);
            this.label13.TabIndex = 22;
            // 
            // btnClearMatch
            // 
            this.btnClearMatch.Location = new System.Drawing.Point(421, 148);
            this.btnClearMatch.Name = "btnClearMatch";
            this.btnClearMatch.Size = new System.Drawing.Size(86, 46);
            this.btnClearMatch.TabIndex = 23;
            this.btnClearMatch.Text = "Reset Views";
            this.btnClearMatch.UseVisualStyleBackColor = true;
            this.btnClearMatch.Click += new System.EventHandler(this.btnClearMatch_Click);
            // 
            // btnAutoMatch
            // 
            this.btnAutoMatch.Location = new System.Drawing.Point(421, 204);
            this.btnAutoMatch.Name = "btnAutoMatch";
            this.btnAutoMatch.Size = new System.Drawing.Size(206, 43);
            this.btnAutoMatch.TabIndex = 24;
            this.btnAutoMatch.Text = "Auto Match Numbers";
            this.btnAutoMatch.UseVisualStyleBackColor = true;
            this.btnAutoMatch.Click += new System.EventHandler(this.btnAutoMatch_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(671, 148);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(157, 43);
            this.btnAccept.TabIndex = 25;
            this.btnAccept.Text = "Accept Bindings";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(671, 203);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(157, 43);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Done! Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(414, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(137, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Phone 5:--------------------------->";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(414, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Phone 6:--------------------------->";
            // 
            // cbxPhone5
            // 
            this.cbxPhone5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPhone5.FormattingEnabled = true;
            this.cbxPhone5.Location = new System.Drawing.Point(572, 3);
            this.cbxPhone5.Name = "cbxPhone5";
            this.cbxPhone5.Size = new System.Drawing.Size(262, 21);
            this.cbxPhone5.TabIndex = 29;
            // 
            // cbxPhone6
            // 
            this.cbxPhone6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPhone6.FormattingEnabled = true;
            this.cbxPhone6.Location = new System.Drawing.Point(572, 32);
            this.cbxPhone6.Name = "cbxPhone6";
            this.cbxPhone6.Size = new System.Drawing.Size(262, 21);
            this.cbxPhone6.TabIndex = 30;
            // 
            // btnPreviewFinalTable
            // 
            this.btnPreviewFinalTable.Location = new System.Drawing.Point(530, 148);
            this.btnPreviewFinalTable.Name = "btnPreviewFinalTable";
            this.btnPreviewFinalTable.Size = new System.Drawing.Size(96, 46);
            this.btnPreviewFinalTable.TabIndex = 31;
            this.btnPreviewFinalTable.Text = "Preview Final Table";
            this.btnPreviewFinalTable.UseVisualStyleBackColor = true;
            this.btnPreviewFinalTable.Click += new System.EventHandler(this.btnPreviewFinalTable_Click);
            // 
            // tbxDebuging
            // 
            this.tbxDebuging.Location = new System.Drawing.Point(356, 264);
            this.tbxDebuging.Multiline = true;
            this.tbxDebuging.Name = "tbxDebuging";
            this.tbxDebuging.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxDebuging.Size = new System.Drawing.Size(472, 248);
            this.tbxDebuging.TabIndex = 32;
            // 
            // DisplayPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 571);
            this.ControlBox = false;
            this.Controls.Add(this.tbxDebuging);
            this.Controls.Add(this.btnPreviewFinalTable);
            this.Controls.Add(this.cbxPhone6);
            this.Controls.Add(this.cbxPhone5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnAutoMatch);
            this.Controls.Add(this.btnClearMatch);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbxEmail2);
            this.Controls.Add(this.cbxEmail1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbxPhone4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxPhone3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxPhone2);
            this.Controls.Add(this.cbxPhone1);
            this.Controls.Add(this.CbxMidName);
            this.Controls.Add(this.cbxLName);
            this.Controls.Add(this.CbxFName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "DisplayPreview";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisplayPreview";
            this.Load += new System.EventHandler(this.DisplayPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CbxFName;
        private System.Windows.Forms.ComboBox cbxLName;
        private System.Windows.Forms.ComboBox CbxMidName;
        private System.Windows.Forms.ComboBox cbxPhone1;
        private System.Windows.Forms.ComboBox cbxPhone2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxPhone3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxPhone4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxEmail1;
        private System.Windows.Forms.ComboBox cbxEmail2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClearMatch;
        private System.Windows.Forms.Button btnAutoMatch;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxPhone5;
        private System.Windows.Forms.ComboBox cbxPhone6;
        private System.Windows.Forms.Button btnPreviewFinalTable;
        private System.Windows.Forms.TextBox tbxDebuging;
    }
}