using Login;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class SearchComment : Form
    {
        public SearchComment()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DataTable user = DBconnector.getInstance().GetUserID(" ");
            ApplyTheme(Program.IsDarkTheme);
            if (user != null)
            {
                foreach (DataRow row in user.Rows)
                {
                    SenderBox.Items.Add(row["ID"].ToString());
                }
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SenderBox.SelectedIndex != -1 && ReceiverBox.SelectedIndex != -1)
            {
                MessageList.Items.Clear();
                string[] senderID = SenderBox.SelectedItem.ToString().Split(' ');
                string[] receiverID = ReceiverBox.SelectedItem.ToString().Split(' ');
                string date = Date.Text.ToString();
                DataTable message;

                if (KeyWord.Text == null && Date.Text == null)
                {
                    message = DBconnector.getInstance().ShowChatUserDM(senderID[0], receiverID[0]);
                }
                else if (KeyWord.Text != null && Date.Text == null)
                {
                    string content = KeyWord.Text;
                    message = DBconnector.getInstance().ShowChatUserDM(senderID[0], receiverID[0], content);
                }
                else if (KeyWord.Text == null && Date.Text != null)
                {
                    message = DBconnector.getInstance().ShowChatUserDM2(senderID[0], receiverID[0], date);
                }
                else
                {
                    string content = KeyWord.Text;
                    message = DBconnector.getInstance().ShowChatUserDM2(senderID[0], receiverID[0], content, date);
                }

                foreach (DataRow row in message.Rows)
                {
                    MessageList.Items.Add($"{row["Content"]} |\t {row["SendTime"]}");
                }
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            string[] date = monthCalendar1.SelectionStart.ToShortDateString().Split('/');
            string info = $"{date[0]}";

            Date.Text = info;
        }

        private void SenderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReceiverBox.Items.Clear();

            string user = SenderBox.SelectedItem.ToString();

            DataTable table = DBconnector.getInstance().GetUserID(user);

            foreach (DataRow row in table.Rows)
            {
                ReceiverBox.Items.Add(row["ID"].ToString());
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
            //this.ForeColor = textCol;

            // 
            if (label1 != null)
            {
                label1.BackColor = panelBg;
                label1.ForeColor = textCol;
            }
            if (label2 != null)
            {
                label2.BackColor = panelBg;
                label2.ForeColor = textCol;
            }
            if (label3 != null)
            {
                label3.BackColor = panelBg;
                label3.ForeColor = textCol;
            }
            if (label4 != null)
            {
                label4.BackColor = panelBg;
                label4.ForeColor = textCol;
            }

            // 
            if (MessageList != null)
            {
                MessageList.BackColor = panelBg;
                MessageList.ForeColor = textCol;
            }

            // 
            if (Date != null)
            {
                Date.BackColor = inputBg;
                Date.ForeColor = textCol;
            }
            if (KeyWord != null)
            {
                KeyWord.BackColor = inputBg;
                KeyWord.ForeColor = textCol;
            }
            if (SenderBox != null)
            {
                SenderBox.BackColor = inputBg;
                SenderBox.ForeColor = textCol;
            }
            if (ReceiverBox != null)
            {
                ReceiverBox.BackColor = inputBg;
                ReceiverBox.ForeColor = textCol;
            }
            // 
            Button[] btns =
            {
                SearchButton
            };

            foreach (var b in btns)
            {
                if (b == null) continue;
                b.BackColor = accent;
                b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            }
        }

        private void ApplyWhiteTheme()
        {
            Color formBg = SystemColors.Control;
            Color panelBg = Color.White;
            Color inputBg = Color.White;
            Color textCol = Color.Black;

            this.BackColor = formBg;
            this.ForeColor = textCol;

            if (label1 != null)
            {
                label1.BackColor = panelBg;
                label1.ForeColor = textCol;
            }

            if (label2 != null)
            {
                label2.BackColor = panelBg;
                label2.ForeColor = textCol;
            }

            if (label3 != null)
            {
                label3.BackColor = panelBg;
                label3.ForeColor = textCol;
            }

            if (label4 != null)
            {
                label4.BackColor = inputBg;
                label4.ForeColor = textCol;
            }
            // 
            if (MessageList != null)
            {
                MessageList.BackColor = panelBg;
                MessageList.ForeColor = textCol;
            }

            // 
            if (Date != null)
            {
                Date.BackColor = inputBg;
                Date.ForeColor = textCol;
            }
            if (KeyWord != null)
            {
                KeyWord.BackColor = inputBg;
                KeyWord.ForeColor = textCol;
            }
            if (SenderBox != null)
            {
                SenderBox.BackColor = inputBg;
                SenderBox.ForeColor = textCol;
            }
            if (ReceiverBox != null)
            {
                ReceiverBox.BackColor = inputBg;
                ReceiverBox.ForeColor = textCol;
            }
            Button[] btns = { SearchButton };
            foreach (var b in btns)
            {
                if (b == null) continue;
                b.BackColor = SystemColors.Control;
                b.ForeColor = Color.Black;
            }
        }
    }
}
