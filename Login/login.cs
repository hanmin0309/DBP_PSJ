// NuGet에서 MySql.Data 설치 필요
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.Properties;
using System.Data.Common;

namespace Login
{
    public partial class login : Form
    {
        private DataTable table;

        public login()
        {
            InitializeComponent();

            // 폼 생성 시, 각 텍스트 박스의 SizeChanged 이벤트에
            // 폰트 크기 조정 함수(textBox_SizeChanged)를 연결
            if (this.Controls.Contains(iD_Box))
            {
                iD_Box.SizeChanged += textBox_SizeChanged;
            }
            if (this.Controls.Contains(passWord_Box))
            {
                passWord_Box.SizeChanged += textBox_SizeChanged;
            }

            // 자동 로그인 체크박스 이벤트
            this.checkBox_AutoLogin.CheckedChanged += checkBox_AutoLogin_CheckedChanged;
        }

        private void login_Load(object sender, EventArgs e)
        {
            // 폼 로드 시 초기 폰트 크기 설정
            textBox_SizeChanged(iD_Box, EventArgs.Empty);
            textBox_SizeChanged(passWord_Box, EventArgs.Empty);

            // 로그인 버튼 모서리 둥글게
            RoundButtonCorners(login_btn, 8);

            // 알림 라벨 초기화
            notice_label.Text = "";
            notice_label.ForeColor = Color.Red;
            notice_label.Visible = false;

            notice_label2.Text = "";
            notice_label2.ForeColor = Color.Red;
            notice_label2.Visible = false;

            // 1) 저장된 체크 상태 불러오기
            checkBox_Remember.Checked = Properties.Settings.Default.RememberIDPW;
            checkBox_AutoLogin.Checked = Properties.Settings.Default.AutoLogin;

            // 2) RememberIDPW가 켜져 있으면 ID/PW 자동 입력
            if (Properties.Settings.Default.RememberIDPW)
            {
                iD_Box.Text = Properties.Settings.Default.SavedID;
                passWord_Box.Text = Properties.Settings.Default.SavedPW;
            }

            // ⭐ 3) AutoLogin이 켜져 있고, ID/PW가 비어있지 않다면 자동 로그인 시도
            if (Properties.Settings.Default.AutoLogin &&
                !string.IsNullOrEmpty(Properties.Settings.Default.SavedID) &&
                !string.IsNullOrEmpty(Properties.Settings.Default.SavedPW))
            {
                // 폼이 완전히 로드된 후 자동 로그인 실행하도록 BeginInvoke 사용
                this.BeginInvoke(new Action(() =>
                {
                    TryLogin(Properties.Settings.Default.SavedID,
                             Properties.Settings.Default.SavedPW,
                             isAutoLogin: true);
                }));
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control == null) return;

            int newFontSize = (int)(control.Height * 0.55);

            const int MIN_FONT_SIZE = 8;
            const int MAX_FONT_SIZE = 30;

            if (newFontSize < MIN_FONT_SIZE)
                newFontSize = MIN_FONT_SIZE;
            if (newFontSize > MAX_FONT_SIZE)
                newFontSize = MAX_FONT_SIZE;

            try
            {
                control.Font = new Font(control.Font.FontFamily, newFontSize, control.Font.Style);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"폰트 설정 오류: {ex.Message}");
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control == null) return;

            int newFontSize = (int)(control.Height * 0.7);

            const int MIN_FONT_SIZE = 8;
            const int MAX_FONT_SIZE = 30;

            if (newFontSize < MIN_FONT_SIZE)
                newFontSize = MIN_FONT_SIZE;
            if (newFontSize > MAX_FONT_SIZE)
                newFontSize = MAX_FONT_SIZE;

            try
            {
                control.Font = new Font(control.Font.FontFamily, newFontSize, control.Font.Style);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"폰트 설정 오류: {ex.Message}");
            }
        }

        private void textBox_SizeChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control == null) return;

            int newFontSize = (int)(control.Height * 0.7);

            const int MIN_FONT_SIZE = 8;
            const int MAX_FONT_SIZE = 18;

            if (newFontSize < MIN_FONT_SIZE)
                newFontSize = MIN_FONT_SIZE;
            if (newFontSize > MAX_FONT_SIZE)
                newFontSize = MAX_FONT_SIZE;

            try
            {
                control.Font = new Font(control.Font.FontFamily, newFontSize, control.Font.Style);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"폰트 설정 오류: {ex.Message}");
            }
        }

        // 로그인 버튼 클릭 이벤트
        private void login_btn_Click(object sender, EventArgs e)
        {
            string userId = iD_Box.Text.Trim();
            string userPw = passWord_Box.Text.Trim();

            TryLogin(userId, userPw, isAutoLogin: false);
        }

        /// <summary>
        /// 실제 로그인 시도 함수.
        /// - isAutoLogin: 자동 로그인인지 여부
        /// </summary>
        private void TryLogin(string userId, string userPw, bool isAutoLogin = false)
        {
            // 1. 빈 값 체크
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userPw))
            {
                if (!isAutoLogin)
                {
                    notice_label.ForeColor = Color.White;
                    notice_label2.ForeColor = Color.White;

                    notice_label.Text = "ID와 PW를 입력하세요";
                    notice_label.Visible = true;

                    notice_label2.Text = "";
                    notice_label2.Visible = false;
                }
                return;
            }

            // 2. MySQL에서 계정 존재 여부 확인
            bool isExist = CheckUserExists(userId, userPw);

            if (!isExist)
            {
                // 로그인 실패
                notice_label.ForeColor = Color.White;
                notice_label2.ForeColor = Color.White;

                notice_label.Text = "";
                notice_label.Visible = false;

                notice_label2.Text = isAutoLogin
                    ? "자동 로그인 실패. ID/PW를 확인해주세요."
                    : "ID/PW를 확인해주세요.";
                notice_label2.Visible = true;

                return;
            }

            // ⭐ 3. 로그인 성공 메시지 (자동 로그인 시에는 표시 안 함)
            if (!isAutoLogin)
            {
                notice_label.ForeColor = Color.White;
                notice_label2.ForeColor = Color.White;

                notice_label.Text = "로그인 성공!";
                notice_label.Visible = true;

                notice_label2.Text = "";
                notice_label2.Visible = false;
            }

            // 4. 로그인 성공 후, 설정 저장
            SaveLoginSettings(userId, userPw);

            // 5. 사용자 정보 가져오기
            table = Login(userId, userPw);

            // ⭐ 6. ContactMainForm 열고 로그인 폼 숨기기
            ContactMainForm main = new ContactMainForm(table);

            // 채팅창이 닫히면 로그인 폼도 닫히도록 설정
            main.FormClosed += (s, args) =>
            {
                this.Close();
            };

            // ⭐⭐⭐ 핵심: 먼저 로그인 폼을 숨긴 후 채팅창을 보여줌
            this.Hide();
            main.Show();
        }

        /// <summary>
        /// 로그인 성공 후, 체크박스 상태에 따라 설정 저장/해제
        /// </summary>
        private void SaveLoginSettings(string userId, string userPw)
        {
            // 1. ID/PW 자동입력
            if (checkBox_Remember.Checked)
            {
                Properties.Settings.Default.RememberIDPW = true;
                Properties.Settings.Default.SavedID = userId;
                Properties.Settings.Default.SavedPW = userPw;
            }
            else
            {
                Properties.Settings.Default.RememberIDPW = false;
                Properties.Settings.Default.SavedID = "";
                Properties.Settings.Default.SavedPW = "";
            }

            // 2. 자동 로그인
            if (checkBox_AutoLogin.Checked)
            {
                Properties.Settings.Default.AutoLogin = true;

                // 자동 로그인이 켜져 있는데 Remember가 꺼져 있으면 강제로 저장
                if (!checkBox_Remember.Checked)
                {
                    Properties.Settings.Default.RememberIDPW = true;
                    Properties.Settings.Default.SavedID = userId;
                    Properties.Settings.Default.SavedPW = userPw;
                }
            }
            else
            {
                Properties.Settings.Default.AutoLogin = false;
            }

            // 3. 실제로 디스크에 저장
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// 자동 로그인 체크박스가 체크될 때, ID/PW 자동입력도 자동으로 켜 주기
        /// </summary>
        private void checkBox_AutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AutoLogin.Checked)
            {
                if (!checkBox_Remember.Checked)
                {
                    checkBox_Remember.Checked = true;
                }
            }
        }

        private void RoundButtonCorners(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);

            int r = radius;
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }

        /// <summary>
        /// MySQL 계정 존재 여부 확인 함수
        /// </summary>
        private bool CheckUserExists(string id, string pw)
        {
            string hashedPassword = register.HashPassword(pw);
            string query = "SELECT COUNT(*) FROM ChatUserDetail_test WHERE ID = @id AND Password = @hashedPw";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(register.ConnectionString))
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@hashedPw", hashedPassword);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    int count = 0;
                    if (result != null && int.TryParse(result.ToString(), out count))
                    {
                        return count > 0;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MySQL 오류: " + ex.Message);
                MessageBox.Show("로그인 실패: " + ex.Message);

                notice_label.Text = "";
                notice_label.Visible = false;
                notice_label2.Text = "서버 오류가 발생했습니다. 잠시 후 다시 시도해주세요.";
                notice_label2.Visible = true;

                return false;
            }
        }

        /// <summary>
        /// 사용자 로그인 확인 메서드
        /// </summary>
        private DataTable Login(string id, string pw)
        {
            using (var conn = new MySqlConnection(register.ConnectionString))
            {
                string hashedPassword = register.HashPassword(pw);

                conn.Open();
                string query = "Select * From ChatUserDetail_test Where ID = @ID AND Password = @PW";
                var cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@PW", hashedPassword);

                var reader = cmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                return table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            register registerForm = new register();
            registerForm.Show();
            registerForm.FormClosed += (s, args) => this.Show();
        }

        private void airForm1_Click(object sender, EventArgs e)
        {

        }

        private void CenterTextVertically(RichTextBox rtb)
        {
            if (rtb == null) return;

            using (Graphics g = rtb.CreateGraphics())
            {
                SizeF textSize = g.MeasureString("A", rtb.Font);
                int textHeight = (int)textSize.Height;

                int paddingTop = (rtb.Height - textHeight) / 2;

                if (paddingTop < 0) paddingTop = 0;

                rtb.Padding = new Padding(
                    rtb.Padding.Left,
                    paddingTop,
                    rtb.Padding.Right,
                    0
                );
            }
        }

        private void iD_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void passWord_Box_TextChanged(object sender, EventArgs e)
        {

        }
    }
}