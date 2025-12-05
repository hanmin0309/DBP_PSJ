namespace Login
{
    partial class login
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            airForm1 = new ReaLTaiizor.Forms.AirForm();
            checkBox_AutoLogin = new CheckBox();
            checkBox_Remember = new CheckBox();
            notice_label2 = new Label();
            notice_label = new Label();
            button1 = new Button();
            login_btn = new Button();
            crownLabel1 = new ReaLTaiizor.Controls.CrownLabel();
            passWord_Box = new RichTextBox();
            iD_Box = new RichTextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            airForm1.SuspendLayout();
            SuspendLayout();
            // 
            // airForm1
            // 
            airForm1.BackColor = Color.FromArgb(57, 58, 65);
            airForm1.BorderStyle = FormBorderStyle.None;
            airForm1.Controls.Add(checkBox_AutoLogin);
            airForm1.Controls.Add(checkBox_Remember);
            airForm1.Controls.Add(notice_label2);
            airForm1.Controls.Add(notice_label);
            airForm1.Controls.Add(button1);
            airForm1.Controls.Add(login_btn);
            airForm1.Controls.Add(crownLabel1);
            airForm1.Controls.Add(passWord_Box);
            airForm1.Controls.Add(iD_Box);
            airForm1.Controls.Add(label4);
            airForm1.Controls.Add(label3);
            airForm1.Controls.Add(label2);
            airForm1.Controls.Add(label1);
            airForm1.Customization = "AAAA/1paWv9ycnL/";
            airForm1.Dock = DockStyle.Fill;
            airForm1.Font = new Font("Segoe UI", 9F);
            airForm1.Image = null;
            airForm1.Location = new Point(0, 0);
            airForm1.Margin = new Padding(3, 4, 3, 4);
            airForm1.MinimumSize = new Size(126, 47);
            airForm1.Movable = true;
            airForm1.Name = "airForm1";
            airForm1.NoRounding = false;
            airForm1.Sizable = true;
            airForm1.Size = new Size(900, 600);
            airForm1.SmartBounds = true;
            airForm1.StartPosition = FormStartPosition.WindowsDefaultLocation;
            airForm1.TabIndex = 0;
            airForm1.TransparencyKey = Color.Fuchsia;
            airForm1.Transparent = false;
            // 
            // checkBox_AutoLogin
            // 
            checkBox_AutoLogin.AutoSize = true;
            checkBox_AutoLogin.Font = new Font("Segoe UI", 12F);
            checkBox_AutoLogin.ForeColor = Color.White;
            checkBox_AutoLogin.Location = new Point(424, 424);
            checkBox_AutoLogin.Margin = new Padding(3, 4, 3, 4);
            checkBox_AutoLogin.Name = "checkBox_AutoLogin";
            checkBox_AutoLogin.Size = new Size(134, 32);
            checkBox_AutoLogin.TabIndex = 13;
            checkBox_AutoLogin.Text = "자동로그인";
            checkBox_AutoLogin.UseVisualStyleBackColor = true;
            // 
            // checkBox_Remember
            // 
            checkBox_Remember.AutoSize = true;
            checkBox_Remember.Font = new Font("Segoe UI", 12F);
            checkBox_Remember.ForeColor = Color.White;
            checkBox_Remember.Location = new Point(219, 424);
            checkBox_Remember.Margin = new Padding(3, 4, 3, 4);
            checkBox_Remember.Name = "checkBox_Remember";
            checkBox_Remember.Size = new Size(176, 32);
            checkBox_Remember.TabIndex = 12;
            checkBox_Remember.Text = "ID/PW 자동입력";
            checkBox_Remember.UseVisualStyleBackColor = true;
            // 
            // notice_label2
            // 
            notice_label2.AutoSize = true;
            notice_label2.ForeColor = Color.White;
            notice_label2.Location = new Point(227, 393);
            notice_label2.Name = "notice_label2";
            notice_label2.Size = new Size(13, 20);
            notice_label2.TabIndex = 11;
            notice_label2.Text = " ";
            // 
            // notice_label
            // 
            notice_label.AutoSize = true;
            notice_label.ForeColor = Color.White;
            notice_label.Location = new Point(227, 393);
            notice_label.Name = "notice_label";
            notice_label.Size = new Size(13, 20);
            notice_label.TabIndex = 10;
            notice_label.Text = " ";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(128, 150, 255);
            button1.Location = new Point(180, 560);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(99, 40);
            button1.TabIndex = 8;
            button1.Text = "가입하기";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.FromArgb(88, 101, 242);
            login_btn.BackgroundImageLayout = ImageLayout.Center;
            login_btn.FlatAppearance.BorderColor = Color.FromArgb(88, 101, 242);
            login_btn.FlatAppearance.BorderSize = 0;
            login_btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            login_btn.FlatStyle = FlatStyle.Flat;
            login_btn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            login_btn.ForeColor = Color.Transparent;
            login_btn.Location = new Point(218, 461);
            login_btn.Margin = new Padding(3, 4, 3, 4);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(467, 73);
            login_btn.TabIndex = 7;
            login_btn.Text = "로그인";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += login_btn_Click;
            // 
            // crownLabel1
            // 
            crownLabel1.AutoSize = true;
            crownLabel1.Font = new Font("Segoe UI", 10F);
            crownLabel1.ForeColor = Color.LightGray;
            crownLabel1.Location = new Point(12, 568);
            crownLabel1.Name = "crownLabel1";
            crownLabel1.Size = new Size(159, 23);
            crownLabel1.TabIndex = 6;
            crownLabel1.Text = "계정이 필요한가요?";
            // 
            // passWord_Box
            // 
            passWord_Box.BackColor = Color.FromArgb(64, 64, 64);
            passWord_Box.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passWord_Box.ForeColor = SystemColors.Window;
            passWord_Box.Location = new Point(219, 316);
            passWord_Box.Margin = new Padding(3, 4, 3, 4);
            passWord_Box.Name = "passWord_Box";
            passWord_Box.ScrollBars = RichTextBoxScrollBars.None;
            passWord_Box.Size = new Size(466, 72);
            passWord_Box.TabIndex = 5;
            passWord_Box.Text = "";
            // 
            // iD_Box
            // 
            iD_Box.BackColor = Color.FromArgb(64, 64, 64);
            iD_Box.BorderStyle = BorderStyle.FixedSingle;
            iD_Box.ForeColor = SystemColors.Window;
            iD_Box.Location = new Point(219, 184);
            iD_Box.Margin = new Padding(3, 4, 3, 4);
            iD_Box.Name = "iD_Box";
            iD_Box.ScrollBars = RichTextBoxScrollBars.None;
            iD_Box.Size = new Size(466, 72);
            iD_Box.TabIndex = 4;
            iD_Box.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(213, 278);
            label4.Name = "label4";
            label4.Size = new Size(84, 25);
            label4.TabIndex = 3;
            label4.Text = "비밀번호";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(213, 138);
            label3.Name = "label3";
            label3.Size = new Size(66, 25);
            label3.TabIndex = 2;
            label3.Text = "아이디";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(331, 88);
            label2.Name = "label2";
            label2.Size = new Size(231, 25);
            label2.TabIndex = 1;
            label2.Text = "다시 돌아왔구나, 오태식이!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(280, 18);
            label1.Name = "label1";
            label1.Size = new Size(319, 41);
            label1.TabIndex = 0;
            label1.Text = "오셨군요? 환영합니다!";
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(57, 58, 65);
            ClientSize = new Size(900, 600);
            Controls.Add(airForm1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(126, 47);
            Name = "login";
            ShowIcon = false;
            Text = "themeForm1";
            TransparencyKey = Color.Fuchsia;
            Load += login_Load;
            airForm1.ResumeLayout(false);
            airForm1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.AirForm airForm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox passWord_Box;
        private System.Windows.Forms.RichTextBox iD_Box;
        private ReaLTaiizor.Controls.CrownLabel crownLabel1;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label notice_label;
        private System.Windows.Forms.Label notice_label2;
        private System.Windows.Forms.CheckBox checkBox_AutoLogin;
        private System.Windows.Forms.CheckBox checkBox_Remember;
    }
}

