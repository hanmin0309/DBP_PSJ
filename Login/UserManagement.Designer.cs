namespace EG
{
    partial class Form3
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
            this.label = new System.Windows.Forms.Label();
            this.TeamValue = new System.Windows.Forms.TextBox();
            this.DepartmentValue = new System.Windows.Forms.TextBox();
            this.run = new System.Windows.Forms.Button();
            this.TeamText = new System.Windows.Forms.TextBox();
            this.TeamList = new System.Windows.Forms.ListBox();
            this.DepartmentList = new System.Windows.Forms.ListBox();
            this.DepartmentText = new System.Windows.Forms.TextBox();
            this.userID = new System.Windows.Forms.ComboBox();
            this.User = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label.ForeColor = System.Drawing.Color.Yellow;
            this.label.Location = new System.Drawing.Point(10, 287);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(118, 12);
            this.label.TabIndex = 28;
            this.label.Text = "이동시킬 부서 / 팀";
            // 
            // TeamValue
            // 
            this.TeamValue.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TeamValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TeamValue.Enabled = false;
            this.TeamValue.ForeColor = System.Drawing.Color.Yellow;
            this.TeamValue.Location = new System.Drawing.Point(12, 323);
            this.TeamValue.Name = "TeamValue";
            this.TeamValue.Size = new System.Drawing.Size(178, 14);
            this.TeamValue.TabIndex = 27;
            // 
            // DepartmentValue
            // 
            this.DepartmentValue.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DepartmentValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DepartmentValue.Enabled = false;
            this.DepartmentValue.ForeColor = System.Drawing.Color.Yellow;
            this.DepartmentValue.Location = new System.Drawing.Point(12, 304);
            this.DepartmentValue.Name = "DepartmentValue";
            this.DepartmentValue.Size = new System.Drawing.Size(178, 14);
            this.DepartmentValue.TabIndex = 26;
            // 
            // run
            // 
            this.run.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.run.ForeColor = System.Drawing.Color.Yellow;
            this.run.Location = new System.Drawing.Point(218, 304);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(74, 23);
            this.run.TabIndex = 25;
            this.run.Text = "변경";
            this.run.UseVisualStyleBackColor = false;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // TeamText
            // 
            this.TeamText.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TeamText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TeamText.Enabled = false;
            this.TeamText.ForeColor = System.Drawing.Color.Yellow;
            this.TeamText.Location = new System.Drawing.Point(139, 267);
            this.TeamText.Name = "TeamText";
            this.TeamText.Size = new System.Drawing.Size(178, 14);
            this.TeamText.TabIndex = 24;
            // 
            // TeamList
            // 
            this.TeamList.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TeamList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TeamList.ForeColor = System.Drawing.Color.Yellow;
            this.TeamList.ItemHeight = 12;
            this.TeamList.Location = new System.Drawing.Point(104, 12);
            this.TeamList.Name = "TeamList";
            this.TeamList.Size = new System.Drawing.Size(92, 180);
            this.TeamList.TabIndex = 20;
            this.TeamList.SelectedIndexChanged += new System.EventHandler(this.TeamList_SelectedIndexChanged);
            // 
            // DepartmentList
            // 
            this.DepartmentList.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DepartmentList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DepartmentList.ForeColor = System.Drawing.Color.Yellow;
            this.DepartmentList.ItemHeight = 12;
            this.DepartmentList.Location = new System.Drawing.Point(5, 12);
            this.DepartmentList.Name = "DepartmentList";
            this.DepartmentList.Size = new System.Drawing.Size(92, 180);
            this.DepartmentList.TabIndex = 21;
            this.DepartmentList.SelectedIndexChanged += new System.EventHandler(this.DepartmentList_SelectedIndexChanged);
            // 
            // DepartmentText
            // 
            this.DepartmentText.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DepartmentText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DepartmentText.Enabled = false;
            this.DepartmentText.ForeColor = System.Drawing.Color.Yellow;
            this.DepartmentText.Location = new System.Drawing.Point(139, 247);
            this.DepartmentText.Name = "DepartmentText";
            this.DepartmentText.Size = new System.Drawing.Size(178, 14);
            this.DepartmentText.TabIndex = 23;
            // 
            // userID
            // 
            this.userID.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userID.ForeColor = System.Drawing.Color.Yellow;
            this.userID.FormattingEnabled = true;
            this.userID.Location = new System.Drawing.Point(12, 241);
            this.userID.Name = "userID";
            this.userID.Size = new System.Drawing.Size(120, 20);
            this.userID.TabIndex = 22;
            this.userID.SelectedIndexChanged += new System.EventHandler(this.userID_SelectedIndexChanged);
            // 
            // User
            // 
            this.User.AutoSize = true;
            this.User.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.User.ForeColor = System.Drawing.Color.Yellow;
            this.User.Location = new System.Drawing.Point(12, 217);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(62, 12);
            this.User.TabIndex = 29;
            this.User.Text = "유저 선택";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(338, 357);
            this.Controls.Add(this.User);
            this.Controls.Add(this.label);
            this.Controls.Add(this.TeamValue);
            this.Controls.Add(this.DepartmentValue);
            this.Controls.Add(this.run);
            this.Controls.Add(this.TeamText);
            this.Controls.Add(this.TeamList);
            this.Controls.Add(this.DepartmentList);
            this.Controls.Add(this.DepartmentText);
            this.Controls.Add(this.userID);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form3";
            this.Text = "유저 부서 관리";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox TeamValue;
        private System.Windows.Forms.TextBox DepartmentValue;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.TextBox TeamText;
        private System.Windows.Forms.ListBox TeamList;
        private System.Windows.Forms.ListBox DepartmentList;
        private System.Windows.Forms.TextBox DepartmentText;
        private System.Windows.Forms.ComboBox userID;
        private System.Windows.Forms.Label User;
    }
}