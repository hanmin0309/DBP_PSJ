using Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EG
{
    public partial class LogConfirm : Form
    {
        public LogConfirm()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DataTable user = DBconnector.getInstance().GetUserID(" ");
            ApplyTheme(Program.IsDarkTheme);
            if (user != null)
            {
                foreach (DataRow row in user.Rows)
                {
                    UserBox.Items.Add($"{row["ID"]} {row["Name"]}");
                }
            }
        }

        private void UserBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserBox.SelectedIndex != -1)
            {
                string[] user = UserBox.SelectedItem.ToString().Split(' ');

                DataTable table = DBconnector.getInstance().ShowChatUserLog(user[0]);

                UserLogView.DataSource = table;
            }
        }
        public void ApplyTheme(bool dark)
        {
            if (dark) ApplyDarkTheme();
            else ApplyWhiteTheme();
        }

        // ================== 다크 테마 적용 ==================
        private void ApplyDarkTheme()
        {
            // 로그인 / 회원가입 폼의 컬러 팔레트와 비슷하게
            Color formBg = Color.FromArgb(57, 58, 65);  // 전체 배경
            Color panelBg = Color.FromArgb(30, 31, 34);  // 리스트/패널 배경
            Color inputBg = Color.FromArgb(64, 64, 64);  // 검색 박스 등
            Color textCol = Color.White;
            Color accent = Color.FromArgb(88, 101, 242); // 포인트 버튼 색

            // 폼 전체
            this.BackColor = formBg;

            //
            if (label1 != null)
            {
                label1.BackColor = panelBg;
                label1.ForeColor = textCol;
            }

            //
            if (UserBox != null)
            {
                UserBox.BackColor = panelBg;
                UserBox.ForeColor = textCol;
            }

            //
            if (UserLogView != null)
            {
                UserLogView.BackColor = formBg;
                UserLogView.ForeColor = Color.Black;
            }
        }

        private void ApplyWhiteTheme()
        {
            Color formBg = SystemColors.Control;
            Color panelBg = Color.White;
            Color inputBg = Color.White;
            Color textCol = Color.Black;

            // 폼 전체
            this.BackColor = formBg;
            this.ForeColor = textCol;

            //
            if (label1 != null)
            {
                label1.BackColor = panelBg;
                label1.ForeColor = textCol;
            }

            //
            if (UserBox != null)
            {
                UserBox.BackColor = panelBg;
                UserBox.ForeColor = textCol;
            }

            //
            if (UserLogView != null)
            {
                UserLogView.BackColor = formBg;
                UserLogView.ForeColor = textCol;
            }
        }
    }
}
