namespace WindowsFormsApp5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.airForm1 = new ReaLTaiizor.Forms.AirForm();
            this.notice_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.login_btn = new System.Windows.Forms.Button();
            this.crownLabel1 = new ReaLTaiizor.Controls.CrownLabel();
            this.passWord_Box = new System.Windows.Forms.RichTextBox();
            this.iD_Box = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notice_label2 = new System.Windows.Forms.Label();
            this.airForm1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // airForm1
            // 
            this.airForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(58)))), ((int)(((byte)(65)))));
            this.airForm1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.airForm1.Controls.Add(this.notice_label2);
            this.airForm1.Controls.Add(this.notice_label);
            this.airForm1.Controls.Add(this.pictureBox1);
            this.airForm1.Controls.Add(this.button1);
            this.airForm1.Controls.Add(this.login_btn);
            this.airForm1.Controls.Add(this.crownLabel1);
            this.airForm1.Controls.Add(this.passWord_Box);
            this.airForm1.Controls.Add(this.iD_Box);
            this.airForm1.Controls.Add(this.label4);
            this.airForm1.Controls.Add(this.label3);
            this.airForm1.Controls.Add(this.label2);
            this.airForm1.Controls.Add(this.label1);
            this.airForm1.Customization = "AAAA/1paWv9ycnL/";
            this.airForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.airForm1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.airForm1.Image = null;
            this.airForm1.Location = new System.Drawing.Point(0, 0);
            this.airForm1.MinimumSize = new System.Drawing.Size(112, 35);
            this.airForm1.Movable = true;
            this.airForm1.Name = "airForm1";
            this.airForm1.NoRounding = false;
            this.airForm1.Sizable = true;
            this.airForm1.Size = new System.Drawing.Size(800, 450);
            this.airForm1.SmartBounds = true;
            this.airForm1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.airForm1.TabIndex = 0;
            this.airForm1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.airForm1.Transparent = false;
            this.airForm1.Click += new System.EventHandler(this.airForm1_Click);
            // 
            // notice_label
            // 
            this.notice_label.AutoSize = true;
            this.notice_label.ForeColor = System.Drawing.Color.White;
            this.notice_label.Location = new System.Drawing.Point(46, 306);
            this.notice_label.Name = "notice_label";
            this.notice_label.Size = new System.Drawing.Size(13, 20);
            this.notice_label.TabIndex = 10;
            this.notice_label.Text = " ";
            this.notice_label.Click += new System.EventHandler(this.notice_label_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(555, 149);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(167, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "가입하기";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.login_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.login_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(101)))), ((int)(((byte)(242)))));
            this.login_btn.FlatAppearance.BorderSize = 0;
            this.login_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_btn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn.ForeColor = System.Drawing.Color.Transparent;
            this.login_btn.Location = new System.Drawing.Point(38, 354);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(415, 55);
            this.login_btn.TabIndex = 7;
            this.login_btn.Text = "로그인";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // crownLabel1
            // 
            this.crownLabel1.AutoSize = true;
            this.crownLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.crownLabel1.ForeColor = System.Drawing.Color.LightGray;
            this.crownLabel1.Location = new System.Drawing.Point(12, 422);
            this.crownLabel1.Name = "crownLabel1";
            this.crownLabel1.Size = new System.Drawing.Size(159, 23);
            this.crownLabel1.TabIndex = 6;
            this.crownLabel1.Text = "계정이 필요한가요?";
            this.crownLabel1.Click += new System.EventHandler(this.crownLabel1_Click);
            // 
            // passWord_Box
            // 
            this.passWord_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.passWord_Box.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passWord_Box.ForeColor = System.Drawing.SystemColors.Window;
            this.passWord_Box.Location = new System.Drawing.Point(38, 248);
            this.passWord_Box.Name = "passWord_Box";
            this.passWord_Box.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.passWord_Box.Size = new System.Drawing.Size(415, 55);
            this.passWord_Box.TabIndex = 5;
            this.passWord_Box.Text = "";
            this.passWord_Box.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged_1);
            // 
            // iD_Box
            // 
            this.iD_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iD_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iD_Box.ForeColor = System.Drawing.SystemColors.Window;
            this.iD_Box.Location = new System.Drawing.Point(38, 149);
            this.iD_Box.Name = "iD_Box";
            this.iD_Box.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.iD_Box.Size = new System.Drawing.Size(415, 55);
            this.iD_Box.TabIndex = 4;
            this.iD_Box.Text = "";
            this.iD_Box.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(33, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "비밀번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(33, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(138, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "다시 돌아왔구나, 오태식이!";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(92, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "오셨군요? 환영합니다!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // notice_label2
            // 
            this.notice_label2.AutoSize = true;
            this.notice_label2.ForeColor = System.Drawing.Color.White;
            this.notice_label2.Location = new System.Drawing.Point(46, 306);
            this.notice_label2.Name = "notice_label2";
            this.notice_label2.Size = new System.Drawing.Size(13, 20);
            this.notice_label2.TabIndex = 11;
            this.notice_label2.Text = " ";
            this.notice_label2.Click += new System.EventHandler(this.notice_label2_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(58)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.airForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(112, 35);
            this.Name = "login";
            this.ShowIcon = false;
            this.Text = "themeForm1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.login_Load);
            this.airForm1.ResumeLayout(false);
            this.airForm1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label notice_label;
        private System.Windows.Forms.Label notice_label2;
    }
}

