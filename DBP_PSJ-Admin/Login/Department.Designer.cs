namespace EG
{
    partial class Department
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
            this.DepartmentList = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDepartment = new System.Windows.Forms.Button();
            this.TeamList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.유저부서관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DepartmentText = new System.Windows.Forms.Label();
            this.TeamText = new System.Windows.Forms.Label();
            this.DepartmentValue = new System.Windows.Forms.TextBox();
            this.TeamValue = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.run = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DepartmentList
            // 
            this.DepartmentList.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DepartmentList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DepartmentList.ForeColor = System.Drawing.Color.Yellow;
            this.DepartmentList.ItemHeight = 12;
            this.DepartmentList.Location = new System.Drawing.Point(12, 36);
            this.DepartmentList.Name = "DepartmentList";
            this.DepartmentList.Size = new System.Drawing.Size(93, 204);
            this.DepartmentList.TabIndex = 0;
            this.DepartmentList.SelectedIndexChanged += new System.EventHandler(this.DepartmentList_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.ForeColor = System.Drawing.Color.Yellow;
            this.textBox1.Location = new System.Drawing.Point(12, 296);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 21);
            this.textBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(10, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "부서명 입력";
            // 
            // buttonDepartment
            // 
            this.buttonDepartment.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDepartment.ForeColor = System.Drawing.Color.Yellow;
            this.buttonDepartment.Location = new System.Drawing.Point(178, 296);
            this.buttonDepartment.Name = "buttonDepartment";
            this.buttonDepartment.Size = new System.Drawing.Size(75, 23);
            this.buttonDepartment.TabIndex = 10;
            this.buttonDepartment.Text = " 부서 추가";
            this.buttonDepartment.UseVisualStyleBackColor = false;
            // 
            // TeamList
            // 
            this.TeamList.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TeamList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TeamList.ForeColor = System.Drawing.Color.Yellow;
            this.TeamList.ItemHeight = 12;
            this.TeamList.Location = new System.Drawing.Point(111, 36);
            this.TeamList.Name = "TeamList";
            this.TeamList.Size = new System.Drawing.Size(93, 204);
            this.TeamList.TabIndex = 0;
            this.TeamList.SelectedIndexChanged += new System.EventHandler(this.TeamList_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(178, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "팀 추가";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(10, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "팀명 입력";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox2.ForeColor = System.Drawing.Color.Yellow;
            this.textBox2.Location = new System.Drawing.Point(12, 345);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(160, 21);
            this.textBox2.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Info;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.유저부서관리ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(503, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 유저부서관리ToolStripMenuItem
            // 
            this.유저부서관리ToolStripMenuItem.Name = "유저부서관리ToolStripMenuItem";
            this.유저부서관리ToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.유저부서관리ToolStripMenuItem.Text = "유저 부서 관리";
            this.유저부서관리ToolStripMenuItem.Click += new System.EventHandler(this.유저부서관리ToolStripMenuItem_Click);
            // 
            // DepartmentText
            // 
            this.DepartmentText.AutoSize = true;
            this.DepartmentText.ForeColor = System.Drawing.Color.Yellow;
            this.DepartmentText.Location = new System.Drawing.Point(242, 73);
            this.DepartmentText.Name = "DepartmentText";
            this.DepartmentText.Size = new System.Drawing.Size(0, 12);
            this.DepartmentText.TabIndex = 16;
            // 
            // TeamText
            // 
            this.TeamText.AutoSize = true;
            this.TeamText.ForeColor = System.Drawing.Color.Yellow;
            this.TeamText.Location = new System.Drawing.Point(242, 95);
            this.TeamText.Name = "TeamText";
            this.TeamText.Size = new System.Drawing.Size(0, 12);
            this.TeamText.TabIndex = 17;
            // 
            // DepartmentValue
            // 
            this.DepartmentValue.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DepartmentValue.ForeColor = System.Drawing.Color.Yellow;
            this.DepartmentValue.Location = new System.Drawing.Point(374, 70);
            this.DepartmentValue.Name = "DepartmentValue";
            this.DepartmentValue.Size = new System.Drawing.Size(100, 21);
            this.DepartmentValue.TabIndex = 18;
            this.DepartmentValue.Click += new System.EventHandler(this.DepartmentValue_Click);
            // 
            // TeamValue
            // 
            this.TeamValue.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TeamValue.ForeColor = System.Drawing.Color.Yellow;
            this.TeamValue.Location = new System.Drawing.Point(374, 97);
            this.TeamValue.Name = "TeamValue";
            this.TeamValue.Size = new System.Drawing.Size(100, 21);
            this.TeamValue.TabIndex = 19;
            this.TeamValue.Click += new System.EventHandler(this.TeamValue_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ForeColor = System.Drawing.Color.Yellow;
            this.label.Location = new System.Drawing.Point(242, 36);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(95, 12);
            this.label.TabIndex = 20;
            this.label.Text = "변경할 부서 / 팀";
            // 
            // run
            // 
            this.run.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.run.ForeColor = System.Drawing.Color.Yellow;
            this.run.Location = new System.Drawing.Point(399, 131);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(75, 23);
            this.run.TabIndex = 21;
            this.run.Text = "변경";
            this.run.UseVisualStyleBackColor = false;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(351, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "→";
            // 
            // Department
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(503, 401);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.run);
            this.Controls.Add(this.label);
            this.Controls.Add(this.TeamValue);
            this.Controls.Add(this.DepartmentValue);
            this.Controls.Add(this.TeamText);
            this.Controls.Add(this.DepartmentText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.TeamList);
            this.Controls.Add(this.buttonDepartment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DepartmentList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Department";
            this.Text = "부서 관리";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox DepartmentList;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDepartment;
        private System.Windows.Forms.ListBox TeamList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 유저부서관리ToolStripMenuItem;
        private System.Windows.Forms.Label DepartmentText;
        private System.Windows.Forms.Label TeamText;
        private System.Windows.Forms.TextBox DepartmentValue;
        private System.Windows.Forms.TextBox TeamValue;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Label label3;
    }
}