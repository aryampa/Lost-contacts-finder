namespace LostContactFinder._01_Automated
{
    partial class MainForm
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
            this.GbxUpdateMode = new System.Windows.Forms.GroupBox();
            this.GbxFileEntryUMode = new System.Windows.Forms.GroupBox();
            this.ckBtnUpdateMode = new System.Windows.Forms.CheckBox();
            this.btnClearDB = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.BtnOkUpdate = new System.Windows.Forms.Button();
            this.lblFileInUpdateMode = new System.Windows.Forms.Label();
            this.BtnLoadFileUpdateMode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RbtnMultiVcardUpdateMode = new System.Windows.Forms.RadioButton();
            this.RbtnSingleUpdateMode = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminToolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncToServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxLog = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.lblLog = new System.Windows.Forms.Label();
            this.GbxUpdateMode.SuspendLayout();
            this.GbxFileEntryUMode.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbxUpdateMode
            // 
            this.GbxUpdateMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.GbxUpdateMode.Controls.Add(this.GbxFileEntryUMode);
            this.GbxUpdateMode.Location = new System.Drawing.Point(16, 27);
            this.GbxUpdateMode.Name = "GbxUpdateMode";
            this.GbxUpdateMode.Size = new System.Drawing.Size(480, 277);
            this.GbxUpdateMode.TabIndex = 0;
            this.GbxUpdateMode.TabStop = false;
            this.GbxUpdateMode.Text = "DataBase Update Mode";
            // 
            // GbxFileEntryUMode
            // 
            this.GbxFileEntryUMode.Controls.Add(this.ckBtnUpdateMode);
            this.GbxFileEntryUMode.Controls.Add(this.btnClearDB);
            this.GbxFileEntryUMode.Controls.Add(this.checkBox1);
            this.GbxFileEntryUMode.Controls.Add(this.BtnOkUpdate);
            this.GbxFileEntryUMode.Controls.Add(this.lblFileInUpdateMode);
            this.GbxFileEntryUMode.Controls.Add(this.BtnLoadFileUpdateMode);
            this.GbxFileEntryUMode.Controls.Add(this.label2);
            this.GbxFileEntryUMode.Controls.Add(this.RbtnMultiVcardUpdateMode);
            this.GbxFileEntryUMode.Controls.Add(this.RbtnSingleUpdateMode);
            this.GbxFileEntryUMode.Location = new System.Drawing.Point(11, 19);
            this.GbxFileEntryUMode.Name = "GbxFileEntryUMode";
            this.GbxFileEntryUMode.Size = new System.Drawing.Size(454, 242);
            this.GbxFileEntryUMode.TabIndex = 1;
            this.GbxFileEntryUMode.TabStop = false;
            this.GbxFileEntryUMode.Text = "File Entry:";
            // 
            // ckBtnUpdateMode
            // 
            this.ckBtnUpdateMode.AutoSize = true;
            this.ckBtnUpdateMode.Location = new System.Drawing.Point(13, 179);
            this.ckBtnUpdateMode.Name = "ckBtnUpdateMode";
            this.ckBtnUpdateMode.Size = new System.Drawing.Size(99, 17);
            this.ckBtnUpdateMode.TabIndex = 8;
            this.ckBtnUpdateMode.Text = "Manual Update";
            this.ckBtnUpdateMode.UseVisualStyleBackColor = true;
            // 
            // btnClearDB
            // 
            this.btnClearDB.ForeColor = System.Drawing.Color.Black;
            this.btnClearDB.Location = new System.Drawing.Point(364, 213);
            this.btnClearDB.Name = "btnClearDB";
            this.btnClearDB.Size = new System.Drawing.Size(75, 23);
            this.btnClearDB.TabIndex = 7;
            this.btnClearDB.Text = "Clear DB";
            this.btnClearDB.UseVisualStyleBackColor = true;
            this.btnClearDB.Click += new System.EventHandler(this.btnClearDB_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(13, 219);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "On-Line Update";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // BtnOkUpdate
            // 
            this.BtnOkUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.BtnOkUpdate.FlatAppearance.BorderSize = 3;
            this.BtnOkUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOkUpdate.ForeColor = System.Drawing.Color.Black;
            this.BtnOkUpdate.Location = new System.Drawing.Point(250, 152);
            this.BtnOkUpdate.Name = "BtnOkUpdate";
            this.BtnOkUpdate.Size = new System.Drawing.Size(189, 59);
            this.BtnOkUpdate.TabIndex = 1;
            this.BtnOkUpdate.Text = "Update DataBase";
            this.BtnOkUpdate.UseVisualStyleBackColor = true;
            this.BtnOkUpdate.Click += new System.EventHandler(this.BtnOkUpdate_Click);
            // 
            // lblFileInUpdateMode
            // 
            this.lblFileInUpdateMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblFileInUpdateMode.ForeColor = System.Drawing.Color.Black;
            this.lblFileInUpdateMode.Location = new System.Drawing.Point(13, 98);
            this.lblFileInUpdateMode.Name = "lblFileInUpdateMode";
            this.lblFileInUpdateMode.Size = new System.Drawing.Size(426, 42);
            this.lblFileInUpdateMode.TabIndex = 5;
            this.lblFileInUpdateMode.Text = "label3";
            this.lblFileInUpdateMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnLoadFileUpdateMode
            // 
            this.BtnLoadFileUpdateMode.ForeColor = System.Drawing.Color.Black;
            this.BtnLoadFileUpdateMode.Location = new System.Drawing.Point(250, 40);
            this.BtnLoadFileUpdateMode.Name = "BtnLoadFileUpdateMode";
            this.BtnLoadFileUpdateMode.Size = new System.Drawing.Size(129, 36);
            this.BtnLoadFileUpdateMode.TabIndex = 4;
            this.BtnLoadFileUpdateMode.Text = "Load File(s)";
            this.BtnLoadFileUpdateMode.UseVisualStyleBackColor = true;
            this.BtnLoadFileUpdateMode.Click += new System.EventHandler(this.BtnLoadFileUpdateMode_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Loaded File Name:";
            // 
            // RbtnMultiVcardUpdateMode
            // 
            this.RbtnMultiVcardUpdateMode.AutoSize = true;
            this.RbtnMultiVcardUpdateMode.ForeColor = System.Drawing.Color.Black;
            this.RbtnMultiVcardUpdateMode.Location = new System.Drawing.Point(33, 59);
            this.RbtnMultiVcardUpdateMode.Name = "RbtnMultiVcardUpdateMode";
            this.RbtnMultiVcardUpdateMode.Size = new System.Drawing.Size(97, 17);
            this.RbtnMultiVcardUpdateMode.TabIndex = 2;
            this.RbtnMultiVcardUpdateMode.TabStop = true;
            this.RbtnMultiVcardUpdateMode.Text = "Multiple Vcards";
            this.RbtnMultiVcardUpdateMode.UseVisualStyleBackColor = true;
            // 
            // RbtnSingleUpdateMode
            // 
            this.RbtnSingleUpdateMode.AutoSize = true;
            this.RbtnSingleUpdateMode.ForeColor = System.Drawing.Color.Black;
            this.RbtnSingleUpdateMode.Location = new System.Drawing.Point(33, 23);
            this.RbtnSingleUpdateMode.Name = "RbtnSingleUpdateMode";
            this.RbtnSingleUpdateMode.Size = new System.Drawing.Size(73, 17);
            this.RbtnSingleUpdateMode.TabIndex = 1;
            this.RbtnSingleUpdateMode.TabStop = true;
            this.RbtnSingleUpdateMode.Text = "Single File";
            this.RbtnSingleUpdateMode.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Preview";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.SearchMenuItem,
            this.AdminToolsMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(508, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.AutoSize = false;
            this.FileMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(94, 20);
            this.FileMenuItem.Text = "File";
            // 
            // SearchMenuItem
            // 
            this.SearchMenuItem.Name = "SearchMenuItem";
            this.SearchMenuItem.Size = new System.Drawing.Size(105, 20);
            this.SearchMenuItem.Text = "Search Database";
            this.SearchMenuItem.Click += new System.EventHandler(this.SearchMenuItem_Click);
            // 
            // AdminToolsMenuItem
            // 
            this.AdminToolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncToServerToolStripMenuItem,
            this.serverSettingsToolStripMenuItem});
            this.AdminToolsMenuItem.Name = "AdminToolsMenuItem";
            this.AdminToolsMenuItem.Size = new System.Drawing.Size(87, 20);
            this.AdminToolsMenuItem.Text = "Admin Tools";
            // 
            // syncToServerToolStripMenuItem
            // 
            this.syncToServerToolStripMenuItem.Name = "syncToServerToolStripMenuItem";
            this.syncToServerToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.syncToServerToolStripMenuItem.Text = "Sync To Server";
            // 
            // serverSettingsToolStripMenuItem
            // 
            this.serverSettingsToolStripMenuItem.Name = "serverSettingsToolStripMenuItem";
            this.serverSettingsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.serverSettingsToolStripMenuItem.Text = "Server Settings";
            // 
            // tbxLog
            // 
            this.tbxLog.BackColor = System.Drawing.Color.Black;
            this.tbxLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tbxLog.Location = new System.Drawing.Point(13, 330);
            this.tbxLog.Multiline = true;
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.ReadOnly = true;
            this.tbxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxLog.Size = new System.Drawing.Size(483, 222);
            this.tbxLog.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            // 
            // lblLog
            // 
            this.lblLog.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(88, 304);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(393, 23);
            this.lblLog.TabIndex = 6;
            this.lblLog.Text = "label1";
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //this.lblLog.Click += new System.EventHandler(this.lblLog_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 564);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.tbxLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GbxUpdateMode);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacts Finder 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GbxUpdateMode.ResumeLayout(false);
            this.GbxFileEntryUMode.ResumeLayout(false);
            this.GbxFileEntryUMode.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxUpdateMode;
        private System.Windows.Forms.GroupBox GbxFileEntryUMode;
        private System.Windows.Forms.Button BtnOkUpdate;
        private System.Windows.Forms.Label lblFileInUpdateMode;
        private System.Windows.Forms.Button BtnLoadFileUpdateMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RbtnMultiVcardUpdateMode;
        private System.Windows.Forms.RadioButton RbtnSingleUpdateMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminToolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncToServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverSettingsToolStripMenuItem;
        private System.Windows.Forms.TextBox tbxLog;
        private System.Windows.Forms.ToolStripMenuItem SearchMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnClearDB;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.CheckBox ckBtnUpdateMode;
    }
}

