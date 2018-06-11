namespace LostContactFinder._01_Automated
{
    partial class Test_StringSpliterForm
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
            this.tbxInput = new System.Windows.Forms.TextBox();
            this.tbxFinalOutput = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCharClear = new System.Windows.Forms.Button();
            this.tbxOutputChars = new System.Windows.Forms.TextBox();
            this.tbxCharInsput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxInput
            // 
            this.tbxInput.Location = new System.Drawing.Point(13, 13);
            this.tbxInput.Name = "tbxInput";
            this.tbxInput.Size = new System.Drawing.Size(259, 20);
            this.tbxInput.TabIndex = 0;
            // 
            // tbxFinalOutput
            // 
            this.tbxFinalOutput.Location = new System.Drawing.Point(13, 190);
            this.tbxFinalOutput.Multiline = true;
            this.tbxFinalOutput.Name = "tbxFinalOutput";
            this.tbxFinalOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxFinalOutput.Size = new System.Drawing.Size(259, 105);
            this.tbxFinalOutput.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(161, 39);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(153, 161);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(119, 23);
            this.btnSplit.TabIndex = 3;
            this.btnSplit.Text = "Split String";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 75);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Char";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCharClear
            // 
            this.btnCharClear.Location = new System.Drawing.Point(13, 132);
            this.btnCharClear.Name = "btnCharClear";
            this.btnCharClear.Size = new System.Drawing.Size(111, 23);
            this.btnCharClear.TabIndex = 5;
            this.btnCharClear.Text = "Clear Chars";
            this.btnCharClear.UseVisualStyleBackColor = true;
            this.btnCharClear.Click += new System.EventHandler(this.btnCharClear_Click);
            // 
            // tbxOutputChars
            // 
            this.tbxOutputChars.Location = new System.Drawing.Point(130, 75);
            this.tbxOutputChars.Multiline = true;
            this.tbxOutputChars.Name = "tbxOutputChars";
            this.tbxOutputChars.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxOutputChars.Size = new System.Drawing.Size(142, 80);
            this.tbxOutputChars.TabIndex = 6;
            // 
            // tbxCharInsput
            // 
            this.tbxCharInsput.Location = new System.Drawing.Point(93, 75);
            this.tbxCharInsput.MaxLength = 1;
            this.tbxCharInsput.Name = "tbxCharInsput";
            this.tbxCharInsput.Size = new System.Drawing.Size(31, 20);
            this.tbxCharInsput.TabIndex = 7;
            // 
            // Test_StringSpliterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 298);
            this.Controls.Add(this.tbxCharInsput);
            this.Controls.Add(this.tbxOutputChars);
            this.Controls.Add(this.btnCharClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbxFinalOutput);
            this.Controls.Add(this.tbxInput);
            this.Name = "Test_StringSpliterForm";
            this.Text = "Test_StringSpliterForm";
            this.Load += new System.EventHandler(this.Test_StringSpliterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxInput;
        private System.Windows.Forms.TextBox tbxFinalOutput;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCharClear;
        private System.Windows.Forms.TextBox tbxOutputChars;
        private System.Windows.Forms.TextBox tbxCharInsput;
    }
}