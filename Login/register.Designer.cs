namespace Login
{
    partial class register
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
            TB_id = new TextBox();
            label1 = new Label();
            TB_pw = new TextBox();
            TB_name = new TextBox();
            TB_zipCode = new TextBox();
            TB_nickname = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            BT_signUp = new Button();
            CB_apartment = new ComboBox();
            BT_close = new Button();
            PB_profile = new PictureBox();
            LB_id_duped = new Label();
            BT_find_zipCode = new Button();
            label8 = new Label();
            TB_pw_check = new TextBox();
            LB_pw_check = new Label();
            label9 = new Label();
            TB_address_detail = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PB_profile).BeginInit();
            SuspendLayout();
            // 
            // TB_id
            // 
            TB_id.BackColor = Color.FromArgb(30, 31, 34);
            TB_id.BorderStyle = BorderStyle.FixedSingle;
            TB_id.ForeColor = SystemColors.Window;
            TB_id.Location = new Point(152, 152);
            TB_id.Name = "TB_id";
            TB_id.Size = new Size(170, 27);
            TB_id.TabIndex = 0;
            TB_id.LostFocus += TB_id_LostFocus;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(246, 39);
            label1.Name = "label1";
            label1.Size = new Size(174, 31);
            label1.TabIndex = 1;
            label1.Text = "Create Account";
            label1.Click += label1_Click;
            // 
            // TB_pw
            // 
            TB_pw.BackColor = Color.FromArgb(30, 31, 34);
            TB_pw.BorderStyle = BorderStyle.FixedSingle;
            TB_pw.ForeColor = SystemColors.Window;
            TB_pw.Location = new Point(152, 203);
            TB_pw.Name = "TB_pw";
            TB_pw.PasswordChar = '*';
            TB_pw.Size = new Size(170, 27);
            TB_pw.TabIndex = 1;
            TB_pw.TextChanged += textBox2_TextChanged;
            // 
            // TB_name
            // 
            TB_name.BackColor = Color.FromArgb(30, 31, 34);
            TB_name.BorderStyle = BorderStyle.FixedSingle;
            TB_name.ForeColor = SystemColors.Window;
            TB_name.Location = new Point(152, 308);
            TB_name.Name = "TB_name";
            TB_name.Size = new Size(170, 27);
            TB_name.TabIndex = 3;
            // 
            // TB_zipCode
            // 
            TB_zipCode.BackColor = Color.FromArgb(30, 31, 34);
            TB_zipCode.BorderStyle = BorderStyle.FixedSingle;
            TB_zipCode.ForeColor = SystemColors.Window;
            TB_zipCode.Location = new Point(444, 340);
            TB_zipCode.Name = "TB_zipCode";
            TB_zipCode.Size = new Size(170, 27);
            TB_zipCode.TabIndex = 6;
            // 
            // TB_nickname
            // 
            TB_nickname.BackColor = Color.FromArgb(30, 31, 34);
            TB_nickname.BorderStyle = BorderStyle.FixedSingle;
            TB_nickname.ForeColor = SystemColors.Window;
            TB_nickname.Location = new Point(152, 358);
            TB_nickname.Name = "TB_nickname";
            TB_nickname.Size = new Size(170, 27);
            TB_nickname.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(58, 154);
            label2.Name = "label2";
            label2.Size = new Size(30, 25);
            label2.TabIndex = 7;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(58, 205);
            label3.Name = "label3";
            label3.Size = new Size(39, 25);
            label3.TabIndex = 8;
            label3.Text = "PW";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(58, 310);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 9;
            label4.Text = "이름";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(350, 342);
            label5.Name = "label5";
            label5.Size = new Size(48, 25);
            label5.TabIndex = 10;
            label5.Text = "주소";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("맑은 고딕", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(58, 361);
            label6.Name = "label6";
            label6.Size = new Size(48, 25);
            label6.TabIndex = 11;
            label6.Text = "별명";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("맑은 고딕", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(58, 412);
            label7.Name = "label7";
            label7.Size = new Size(84, 25);
            label7.TabIndex = 12;
            label7.Text = "소속부서";
            // 
            // BT_signUp
            // 
            BT_signUp.BackColor = Color.FromArgb(88, 101, 242);
            BT_signUp.FlatAppearance.BorderColor = Color.FromArgb(88, 101, 242);
            BT_signUp.FlatStyle = FlatStyle.Flat;
            BT_signUp.Location = new Point(285, 470);
            BT_signUp.Name = "BT_signUp";
            BT_signUp.Size = new Size(94, 29);
            BT_signUp.TabIndex = 8;
            BT_signUp.Text = "Sign up";
            BT_signUp.UseVisualStyleBackColor = false;
            BT_signUp.Click += BT_signUp_Click;
            // 
            // CB_apartment
            // 
            CB_apartment.BackColor = Color.FromArgb(30, 31, 34);
            CB_apartment.FlatStyle = FlatStyle.Popup;
            CB_apartment.ForeColor = SystemColors.Window;
            CB_apartment.FormattingEnabled = true;
            CB_apartment.Location = new Point(152, 409);
            CB_apartment.Name = "CB_apartment";
            CB_apartment.Size = new Size(170, 28);
            CB_apartment.TabIndex = 5;
            // 
            // BT_close
            // 
            BT_close.FlatAppearance.BorderSize = 0;
            BT_close.FlatStyle = FlatStyle.Flat;
            BT_close.ForeColor = Color.FromArgb(88, 101, 242);
            BT_close.Location = new Point(629, 1);
            BT_close.Name = "BT_close";
            BT_close.Size = new Size(21, 28);
            BT_close.TabIndex = 15;
            BT_close.Text = "X";
            BT_close.UseVisualStyleBackColor = true;
            BT_close.Click += button1_Click;
            // 
            // PB_profile
            // 
            PB_profile.BackColor = Color.FromArgb(30, 31, 34);
            PB_profile.Location = new Point(368, 125);
            PB_profile.Name = "PB_profile";
            PB_profile.Size = new Size(246, 185);
            PB_profile.TabIndex = 17;
            PB_profile.TabStop = false;
            PB_profile.Click += pictureBox_Click;
            // 
            // LB_id_duped
            // 
            LB_id_duped.AutoSize = true;
            LB_id_duped.ForeColor = Color.IndianRed;
            LB_id_duped.Location = new Point(152, 180);
            LB_id_duped.Name = "LB_id_duped";
            LB_id_duped.Size = new Size(114, 20);
            LB_id_duped.TabIndex = 18;
            LB_id_duped.Text = "iD중복확인멘트";
            LB_id_duped.Visible = false;
            // 
            // BT_find_zipCode
            // 
            BT_find_zipCode.BackColor = Color.FromArgb(57, 58, 65);
            BT_find_zipCode.FlatAppearance.BorderColor = Color.FromArgb(57, 58, 65);
            BT_find_zipCode.FlatStyle = FlatStyle.Flat;
            BT_find_zipCode.ForeColor = SystemColors.ControlLightLight;
            BT_find_zipCode.Location = new Point(444, 369);
            BT_find_zipCode.Name = "BT_find_zipCode";
            BT_find_zipCode.Size = new Size(83, 30);
            BT_find_zipCode.TabIndex = 19;
            BT_find_zipCode.Text = "주소찾기";
            BT_find_zipCode.UseVisualStyleBackColor = false;
            BT_find_zipCode.Click += BT_find_zipCode_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("맑은 고딕", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(58, 251);
            label8.Name = "label8";
            label8.Size = new Size(81, 25);
            label8.TabIndex = 20;
            label8.Text = "PW 확인";
            // 
            // TB_pw_check
            // 
            TB_pw_check.BackColor = Color.FromArgb(30, 31, 34);
            TB_pw_check.BorderStyle = BorderStyle.FixedSingle;
            TB_pw_check.ForeColor = SystemColors.Window;
            TB_pw_check.Location = new Point(152, 249);
            TB_pw_check.Name = "TB_pw_check";
            TB_pw_check.PasswordChar = '*';
            TB_pw_check.Size = new Size(170, 27);
            TB_pw_check.TabIndex = 2;
            TB_pw_check.TextChanged += TB_pw_check_TextChanged;
            // 
            // LB_pw_check
            // 
            LB_pw_check.AutoSize = true;
            LB_pw_check.ForeColor = Color.IndianRed;
            LB_pw_check.Location = new Point(152, 279);
            LB_pw_check.Name = "LB_pw_check";
            LB_pw_check.Size = new Size(149, 20);
            LB_pw_check.TabIndex = 22;
            LB_pw_check.Text = "비밀번호가 다릅니다";
            LB_pw_check.Visible = false;
            LB_pw_check.Click += LB_pw_check_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("맑은 고딕", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(348, 407);
            label9.Name = "label9";
            label9.Size = new Size(90, 25);
            label9.TabIndex = 24;
            label9.Text = "주소 상세";
            // 
            // TB_address_detail
            // 
            TB_address_detail.BackColor = Color.FromArgb(30, 31, 34);
            TB_address_detail.BorderStyle = BorderStyle.FixedSingle;
            TB_address_detail.ForeColor = SystemColors.Window;
            TB_address_detail.Location = new Point(444, 405);
            TB_address_detail.Name = "TB_address_detail";
            TB_address_detail.Size = new Size(170, 27);
            TB_address_detail.TabIndex = 7;
            // 
            // register
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(57, 58, 65);
            ClientSize = new Size(650, 543);
            Controls.Add(label9);
            Controls.Add(TB_address_detail);
            Controls.Add(LB_pw_check);
            Controls.Add(TB_pw_check);
            Controls.Add(label8);
            Controls.Add(BT_find_zipCode);
            Controls.Add(LB_id_duped);
            Controls.Add(PB_profile);
            Controls.Add(BT_close);
            Controls.Add(CB_apartment);
            Controls.Add(BT_signUp);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TB_nickname);
            Controls.Add(TB_zipCode);
            Controls.Add(TB_name);
            Controls.Add(TB_pw);
            Controls.Add(label1);
            Controls.Add(TB_id);
            FormBorderStyle = FormBorderStyle.None;
            Name = "register";
            StartPosition = FormStartPosition.CenterParent;
            Text = "register";
            Load += register_Load;
            MouseDown += register_MouseDown;
            MouseMove += register_MouseMove;
            MouseUp += register_MouseUp;
            ((System.ComponentModel.ISupportInitialize)PB_profile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_id;
        private Label label1;
        private TextBox TB_pw;
        private TextBox TB_name;
        private TextBox TB_zipCode;
        private TextBox TB_nickname;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button BT_signUp;
        private ComboBox CB_apartment;
        private Button BT_close;
        private PictureBox PB_profile;
        private Label LB_id_duped;
        private Button BT_find_zipCode;
        private Label label8;
        private TextBox TB_pw_check;
        private Label LB_pw_check;
        private Label label9;
        private TextBox TB_address_detail;
    }
}