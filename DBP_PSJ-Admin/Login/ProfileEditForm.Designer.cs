namespace Login
{
    partial class ProfileEditForm
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
            TB_Name = new TextBox();
            TB_NickName = new TextBox();
            TB_Zipcode = new TextBox();
            TB_Address = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            LB_Department = new Label();
            label5 = new Label();
            PB_Profile = new PictureBox();
            btnSelectProfileImage = new Button();
            label6 = new Label();
            label7 = new Label();
            TB_CurrentPw = new TextBox();
            TB_NewPw = new TextBox();
            TB_NewPwCheck = new TextBox();
            label8 = new Label();
            btnSaveProfile = new Button();
            btnChangePassword = new Button();
            ((System.ComponentModel.ISupportInitialize)PB_Profile).BeginInit();
            SuspendLayout();
            // 
            // TB_Name
            // 
            TB_Name.Location = new Point(119, 35);
            TB_Name.Name = "TB_Name";
            TB_Name.Size = new Size(156, 23);
            TB_Name.TabIndex = 0;
            // 
            // TB_NickName
            // 
            TB_NickName.Location = new Point(119, 77);
            TB_NickName.Name = "TB_NickName";
            TB_NickName.Size = new Size(156, 23);
            TB_NickName.TabIndex = 1;
            // 
            // TB_Zipcode
            // 
            TB_Zipcode.Location = new Point(119, 163);
            TB_Zipcode.Name = "TB_Zipcode";
            TB_Zipcode.Size = new Size(156, 23);
            TB_Zipcode.TabIndex = 3;
            // 
            // TB_Address
            // 
            TB_Address.Location = new Point(119, 119);
            TB_Address.Name = "TB_Address";
            TB_Address.Size = new Size(156, 23);
            TB_Address.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 10F);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(49, 37);
            label1.Name = "label1";
            label1.Size = new Size(37, 19);
            label1.TabIndex = 4;
            label1.Text = "이름";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 10F);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(49, 77);
            label2.Name = "label2";
            label2.Size = new Size(37, 19);
            label2.TabIndex = 5;
            label2.Text = "별명";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 10F);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(49, 121);
            label3.Name = "label3";
            label3.Size = new Size(37, 19);
            label3.TabIndex = 6;
            label3.Text = "주소";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 10F);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(34, 165);
            label4.Name = "label4";
            label4.Size = new Size(65, 19);
            label4.TabIndex = 7;
            label4.Text = "우편번호";
            // 
            // LB_Department
            // 
            LB_Department.AutoSize = true;
            LB_Department.Font = new Font("맑은 고딕", 10F);
            LB_Department.ForeColor = SystemColors.ButtonFace;
            LB_Department.Location = new Point(119, 216);
            LB_Department.Name = "LB_Department";
            LB_Department.Size = new Size(51, 19);
            LB_Department.TabIndex = 8;
            LB_Department.Text = "부서명";
            LB_Department.Click += LB_Department_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 10F);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(49, 216);
            label5.Name = "label5";
            label5.Size = new Size(37, 19);
            label5.TabIndex = 9;
            label5.Text = "부서";
            // 
            // PB_Profile
            // 
            PB_Profile.BackColor = Color.White;
            PB_Profile.BackgroundImageLayout = ImageLayout.Stretch;
            PB_Profile.BorderStyle = BorderStyle.FixedSingle;
            PB_Profile.Location = new Point(333, 35);
            PB_Profile.Name = "PB_Profile";
            PB_Profile.Size = new Size(151, 149);
            PB_Profile.TabIndex = 10;
            PB_Profile.TabStop = false;
            // 
            // btnSelectProfileImage
            // 
            btnSelectProfileImage.BackColor = Color.FromArgb(88, 101, 242);
            btnSelectProfileImage.FlatStyle = FlatStyle.Popup;
            btnSelectProfileImage.ForeColor = Color.Transparent;
            btnSelectProfileImage.Location = new Point(366, 212);
            btnSelectProfileImage.Name = "btnSelectProfileImage";
            btnSelectProfileImage.Size = new Size(75, 23);
            btnSelectProfileImage.TabIndex = 12;
            btnSelectProfileImage.Text = "사진선택";
            btnSelectProfileImage.UseVisualStyleBackColor = false;
            btnSelectProfileImage.Click += btnSelectProfileImage_Click_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("맑은 고딕", 10F);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(20, 272);
            label6.Name = "label6";
            label6.Size = new Size(93, 19);
            label6.TabIndex = 13;
            label6.Text = "현재비밀번호";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("맑은 고딕", 10F);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(21, 309);
            label7.Name = "label7";
            label7.Size = new Size(84, 19);
            label7.TabIndex = 14;
            label7.Text = "새 비밀번호";
            // 
            // TB_CurrentPw
            // 
            TB_CurrentPw.Location = new Point(119, 270);
            TB_CurrentPw.Name = "TB_CurrentPw";
            TB_CurrentPw.Size = new Size(156, 23);
            TB_CurrentPw.TabIndex = 15;
            // 
            // TB_NewPw
            // 
            TB_NewPw.Location = new Point(119, 307);
            TB_NewPw.Name = "TB_NewPw";
            TB_NewPw.Size = new Size(156, 23);
            TB_NewPw.TabIndex = 16;
            // 
            // TB_NewPwCheck
            // 
            TB_NewPwCheck.Location = new Point(119, 346);
            TB_NewPwCheck.Name = "TB_NewPwCheck";
            TB_NewPwCheck.Size = new Size(156, 23);
            TB_NewPwCheck.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("맑은 고딕", 10F);
            label8.ForeColor = SystemColors.ButtonFace;
            label8.Location = new Point(20, 346);
            label8.Name = "label8";
            label8.Size = new Size(93, 19);
            label8.TabIndex = 17;
            label8.Text = "비밀번호확인";
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.BackColor = Color.FromArgb(88, 101, 242);
            btnSaveProfile.FlatStyle = FlatStyle.Popup;
            btnSaveProfile.ForeColor = Color.Transparent;
            btnSaveProfile.Location = new Point(419, 402);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(87, 23);
            btnSaveProfile.TabIndex = 19;
            btnSaveProfile.Text = "정보변경저장";
            btnSaveProfile.UseVisualStyleBackColor = false;
            btnSaveProfile.Click += btnSaveProfile_Click_1;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.FromArgb(88, 101, 242);
            btnChangePassword.FlatStyle = FlatStyle.Popup;
            btnChangePassword.ForeColor = Color.Transparent;
            btnChangePassword.Location = new Point(292, 402);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(91, 23);
            btnChangePassword.TabIndex = 20;
            btnChangePassword.Text = "비밀번호변경";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click_1;
            // 
            // ProfileEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(57, 58, 65);
            ClientSize = new Size(520, 450);
            Controls.Add(btnChangePassword);
            Controls.Add(btnSaveProfile);
            Controls.Add(TB_NewPwCheck);
            Controls.Add(label8);
            Controls.Add(TB_NewPw);
            Controls.Add(TB_CurrentPw);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnSelectProfileImage);
            Controls.Add(PB_Profile);
            Controls.Add(label5);
            Controls.Add(LB_Department);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TB_Zipcode);
            Controls.Add(TB_Address);
            Controls.Add(TB_NickName);
            Controls.Add(TB_Name);
            Name = "ProfileEditForm";
            Text = "ProfileEditForm";
            Load += ProfileEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)PB_Profile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_Name;
        private TextBox TB_NickName;
        private TextBox TB_Zipcode;
        private TextBox TB_Address;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label LB_Department;
        private Label label5;
        private PictureBox PB_Profile;
        private Button btnSelectProfileImage;
        private Label label6;
        private Label label7;
        private TextBox TB_CurrentPw;
        private TextBox TB_NewPw;
        private TextBox TB_NewPwCheck;
        private Label label8;
        private Button btnSaveProfile;
        private Button btnChangePassword;
    }
}