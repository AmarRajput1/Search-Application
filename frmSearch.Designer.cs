namespace SearchTest
{
    partial class frmSearch
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgRes = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHighSal = new System.Windows.Forms.TextBox();
            this.txtLowSal = new System.Windows.Forms.TextBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.gbRailRef = new System.Windows.Forms.GroupBox();
            this.rdoPartEmpNum = new System.Windows.Forms.RadioButton();
            this.rdoExactEmpNum = new System.Windows.Forms.RadioButton();
            this.txtEmpNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClear = new System.Windows.Forms.Button();
            this.BGW1 = new System.ComponentModel.BackgroundWorker();
            this.cbSQL = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgRes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbRailRef.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(555, 325);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(145, 46);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search Results";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgRes
            // 
            this.dgRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRes.Location = new System.Drawing.Point(382, 72);
            this.dgRes.Name = "dgRes";
            this.dgRes.Size = new System.Drawing.Size(318, 247);
            this.dgRes.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.cmbGender);
            this.groupBox2.Controls.Add(this.gbRailRef);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(21, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 330);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Criteria";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtHighSal);
            this.groupBox3.Controls.Add(this.txtLowSal);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(17, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 79);
            this.groupBox3.TabIndex = 383;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Salary Range";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 17);
            this.label5.TabIndex = 384;
            this.label5.Text = "to";
            // 
            // txtHighSal
            // 
            this.txtHighSal.Location = new System.Drawing.Point(165, 33);
            this.txtHighSal.Name = "txtHighSal";
            this.txtHighSal.Size = new System.Drawing.Size(119, 23);
            this.txtHighSal.TabIndex = 382;
            // 
            // txtLowSal
            // 
            this.txtLowSal.Location = new System.Drawing.Point(14, 33);
            this.txtLowSal.Name = "txtLowSal";
            this.txtLowSal.Size = new System.Drawing.Size(119, 23);
            this.txtLowSal.TabIndex = 381;
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(93, 74);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(95, 28);
            this.cmbGender.TabIndex = 340;
            // 
            // gbRailRef
            // 
            this.gbRailRef.Controls.Add(this.rdoPartEmpNum);
            this.gbRailRef.Controls.Add(this.rdoExactEmpNum);
            this.gbRailRef.Controls.Add(this.txtEmpNum);
            this.gbRailRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRailRef.Location = new System.Drawing.Point(17, 116);
            this.gbRailRef.Name = "gbRailRef";
            this.gbRailRef.Size = new System.Drawing.Size(302, 105);
            this.gbRailRef.TabIndex = 339;
            this.gbRailRef.TabStop = false;
            this.gbRailRef.Text = "Employee Number";
            // 
            // rdoPartEmpNum
            // 
            this.rdoPartEmpNum.AutoSize = true;
            this.rdoPartEmpNum.Location = new System.Drawing.Point(165, 68);
            this.rdoPartEmpNum.Name = "rdoPartEmpNum";
            this.rdoPartEmpNum.Size = new System.Drawing.Size(108, 21);
            this.rdoPartEmpNum.TabIndex = 382;
            this.rdoPartEmpNum.Text = "Partial Match";
            this.rdoPartEmpNum.UseVisualStyleBackColor = true;
            this.rdoPartEmpNum.CheckedChanged += new System.EventHandler(this.rdoPartEmpNum_CheckedChanged);
            // 
            // rdoExactEmpNum
            // 
            this.rdoExactEmpNum.AutoSize = true;
            this.rdoExactEmpNum.Checked = true;
            this.rdoExactEmpNum.Location = new System.Drawing.Point(20, 68);
            this.rdoExactEmpNum.Name = "rdoExactEmpNum";
            this.rdoExactEmpNum.Size = new System.Drawing.Size(102, 21);
            this.rdoExactEmpNum.TabIndex = 340;
            this.rdoExactEmpNum.TabStop = true;
            this.rdoExactEmpNum.Text = "Exact match";
            this.rdoExactEmpNum.UseVisualStyleBackColor = true;
            this.rdoExactEmpNum.CheckedChanged += new System.EventHandler(this.rdoExactEmpNum_CheckedChanged);
            // 
            // txtEmpNum
            // 
            this.txtEmpNum.Location = new System.Drawing.Point(20, 36);
            this.txtEmpNum.Name = "txtEmpNum";
            this.txtEmpNum.Size = new System.Drawing.Size(264, 23);
            this.txtEmpNum.TabIndex = 381;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Gender:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 26);
            this.txtName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Name:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(719, 29);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(152, 26);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(382, 325);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(145, 46);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear Criteria";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // BGW1
            // 
            this.BGW1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW1_DoWork);
            this.BGW1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW1_RunWorkerCompleted);
            // 
            // cbSQL
            // 
            this.cbSQL.AutoSize = true;
            this.cbSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSQL.Location = new System.Drawing.Point(382, 45);
            this.cbSQL.Name = "cbSQL";
            this.cbSQL.Size = new System.Drawing.Size(247, 21);
            this.cbSQL.TabIndex = 12;
            this.cbSQL.Text = "Include results from SQL Database";
            this.cbSQL.UseVisualStyleBackColor = true;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 382);
            this.Controls.Add(this.cbSQL);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgRes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSearch";
            this.Text = "Search Data";
            ((System.ComponentModel.ISupportInitialize)(this.dgRes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbRailRef.ResumeLayout(false);
            this.gbRailRef.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgRes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHighSal;
        private System.Windows.Forms.TextBox txtLowSal;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.GroupBox gbRailRef;
        private System.Windows.Forms.RadioButton rdoPartEmpNum;
        private System.Windows.Forms.RadioButton rdoExactEmpNum;
        private System.Windows.Forms.TextBox txtEmpNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button btnClear;
        private System.ComponentModel.BackgroundWorker BGW1;
        private System.Windows.Forms.CheckBox cbSQL;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
    }
}

