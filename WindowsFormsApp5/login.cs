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

namespace WindowsFormsApp5
{
    public partial class login : Form
    {
        // ▶ MySQL 연결 문자열 (본인 환경에 맞게 수정 필수)
        private string _connectionString =
            "server=223.130.151.111;port=3306;database=s5701514;uid=s5701514;pwd=s5701514;";

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
        }

        // 폼 로드 이벤트 이름을 login_Load 로 맞추는 것을 권장
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
            notice_label.Visible = false;   // 처음에는 숨김

            notice_label2.Text = "";
            notice_label2.ForeColor = Color.Red;
            notice_label2.Visible = false;  // 처음에는 숨김
        }

        private void airRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void airForm2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

            int newFontSize = (int)(control.Height * 0.55);

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

        private void textBox_SizeChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control == null) return;

            int newFontSize = (int)(control.Height * 0.55);

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

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void airForm1_Click(object sender, EventArgs e)
        {

        }

        // 기존 테스트용 버튼 (있다면)
        private void button1_Click(object sender, EventArgs e)
        {
            RoundButtonCorners(login_btn, 8);
        }

        private void crownLabel1_Click(object sender, EventArgs e)
        {

        }

        // ✅ 로그인 버튼 클릭 이벤트 (핵심)
        private void login_btn_Click(object sender, EventArgs e)
        {
            // 1. ID / PW 읽기
            string userId = iD_Box.Text.Trim();
            string userPw = passWord_Box.Text.Trim();

            // 2. 빈 값 체크
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userPw))
            {
                notice_label.ForeColor = Color.White;
                notice_label2.ForeColor = Color.White;

                // 여기서는 예시로 notice_label만 사용
                notice_label.Text = "ID와 PW를 입력하세요";
                notice_label.Visible = true;

                notice_label2.Text = "";
                notice_label2.Visible = false;

                return;
            }

            // 3. MySQL에서 계정 존재 여부 확인
            bool isExist = CheckUserExists(userId, userPw);

            if (!isExist)
            {
                // ❌ 계정이 없을 때
                notice_label.ForeColor = Color.White;
                notice_label2.ForeColor = Color.White;

                // 예: 여기서는 notice_label2를 사용하고, 1은 숨김
                notice_label.Text = "";
                notice_label.Visible = false;

                notice_label2.Text = "계정을 생성해주세요.";
                notice_label2.Visible = true;
            }
            else
            {
                // ✅ 계정이 있을 때 (로그인 성공)
                notice_label.ForeColor = Color.White;
                notice_label2.ForeColor = Color.White;

                // 예: 로그인 성공은 notice_label에 출력
                notice_label.Text = "로그인 성공!";
                notice_label.Visible = true;

                notice_label2.Text = "";
                notice_label2.Visible = false;

                // TODO: 로그인 성공 후 동작 (원하면 나중에 추가)
                // MainForm main = new MainForm();
                // main.Show();
                // this.Hide();
            }
        }

        private void RoundButtonCorners(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);

            int r = radius;
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);                    // 좌상단
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);            // 우상단
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);     // 우하단
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);            // 좌하단
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void notice_label_Click(object sender, EventArgs e)
        {

        }

        private void notice_label2_Click(object sender, EventArgs e)
        {

        }

        // =====================================
        //   MySQL 계정 존재 여부 확인 함수
        // =====================================
        private bool CheckUserExists(string id, string pw)
        {
            // ⚠️ 테이블/컬럼 이름을 실제 DB에 맞게 수정해야 합니다.
            // 예시: users 테이블, user_id / user_pw 컬럼 사용
            string query = "SELECT COUNT(*) FROM UserInformation WHERE Identity = @id AND Password = @pw";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pw", pw);

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
                // 예외 발생 시 콘솔에 출력(개발용)
                Console.WriteLine("MySQL 오류: " + ex.Message);
                MessageBox.Show("MySQL 오류: " + ex.Message);

                // 사용자에게는 서버 오류 메시지 표시
                // 예: 서버 오류는 notice_label2에만 출력하고, 1은 숨김
                notice_label.ForeColor = Color.Red;
                notice_label2.ForeColor = Color.Red;

                notice_label.Text = "";
                notice_label.Visible = false;

                notice_label2.Text = "서버 오류가 발생했습니다. 잠시 후 다시 시도해주세요.";
                notice_label2.Visible = true;

                return false;
            }
        }
    }
}