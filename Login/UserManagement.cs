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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            ApplyTheme(Program.IsDarkTheme);
            LoadData();
        }

        public void LoadData()
        {
            DataTable temp = DBconnector.getInstance().ShowChatUserList();
            foreach (DataRow row in temp.Rows)
            {
                userID.Items.Add(row["ID"].ToString());
            }

            temp = DBconnector.getInstance().ShowChatUserDepartment();
            if (temp.Rows.Count != 0)
            {
                foreach (DataRow row in temp.Rows)
                {
                    DepartmentList.Items.Add(row["Department"].ToString());
                }
            }
        }

        private void DepartmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TeamList.Items.Clear();

            string department = DepartmentList.SelectedItem.ToString();
            DataTable temp = DBconnector.getInstance().ShowChatUserTeam(department);

            foreach (DataRow row in temp.Rows)
            {
                TeamList.Items.Add(row["Team"].ToString());
            }
            if (userID.SelectedItem != null)
                DepartmentValue.Text = DepartmentList.SelectedItem.ToString();
        }

        private void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userID.SelectedItem != null)
                TeamValue.Text = TeamList.SelectedItem.ToString();
        }

        private void userID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = userID.SelectedItem.ToString();
            DataTable temp = DBconnector.getInstance().GetDepartment(id);

            if (temp.Rows[0]["Department"].ToString() != "")
            {
                DepartmentText.Text = temp.Rows[0]["Department"].ToString();
            }
            else
            {
                DepartmentText.Text = "아직 정해진 부서가 없습니다";
            }

            temp = DBconnector.getInstance().GetTeam(id);
            if (temp.Rows[0]["Team"].ToString() != "")
            {
                TeamText.Text = temp.Rows[0]["Team"].ToString();
            }
            else
            {
                TeamText.Text = "아직 정해진 팀이 없습니다";
            }
        }

        private void run_Click(object sender, EventArgs e)
        {
            string userid = userID.SelectedItem.ToString();
            string department = DepartmentList.SelectedItem.ToString();
            string team = TeamList.SelectedItem.ToString();

            DBconnector.getInstance().SetDepartmentTeam(userid, department, team);
            MessageBox.Show("부서 / 팀 변경 완료");
            LoadData();
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
            this.ForeColor = textCol;

            // 
            if (DepartmentList != null)
            {
                DepartmentList.BackColor = panelBg;
                DepartmentList.ForeColor = textCol;
            }

            if (TeamList != null)
            {
                TeamList.BackColor = panelBg;
                TeamList.ForeColor = textCol;
            }

            // 
            if (User != null)
            {
                User.BackColor = panelBg;
                User.ForeColor = textCol;
            }

            // 
            if (label != null)
            {
                label.BackColor = panelBg;
                label.ForeColor = textCol;
            }

            if (userID != null)
            {
                userID.BackColor = panelBg;
                userID.ForeColor = textCol;
            }

            // 
            if (DepartmentText != null)
            {
                DepartmentText.BackColor = inputBg;
                DepartmentText.ForeColor = textCol;
            }

            if (TeamText != null)
            {
                TeamText.BackColor = inputBg;
                TeamText.ForeColor = textCol;
            }

            if (DepartmentValue != null)
            {
                DepartmentValue.BackColor = inputBg;
                DepartmentValue.ForeColor = textCol;
            }

            if (TeamValue != null)
            {
                TeamValue.BackColor = inputBg;
                TeamValue.ForeColor = textCol;
            }

            // 
            Button[] btns =
            {
                run
            };

            foreach (var b in btns)
            {
                if (b == null) continue;
                b.BackColor = accent;
                b.ForeColor = Color.White;
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

            // 폼 전체
            this.BackColor = formBg;
            this.ForeColor = textCol;

            // 
            if (DepartmentList != null)
            {
                DepartmentList.BackColor = panelBg;
                DepartmentList.ForeColor = textCol;
            }

            if (TeamList != null)
            {
                TeamList.BackColor = panelBg;
                TeamList.ForeColor = textCol;
            }

            // 
            if (User != null)
            {
                User.BackColor = panelBg;
                User.ForeColor = textCol;
            }

            // 
            if (label != null)
            {
                label.BackColor = panelBg;
                label.ForeColor = textCol;
            }

            if (userID != null)
            {
                userID.BackColor = panelBg;
                userID.ForeColor = textCol;
            }

            // 
            if (DepartmentText != null)
            {
                DepartmentText.BackColor = inputBg;
                DepartmentText.ForeColor = textCol;
            }

            if (TeamText != null)
            {
                TeamText.BackColor = inputBg;
                TeamText.ForeColor = textCol;
            }

            if (DepartmentValue != null)
            {
                DepartmentValue.BackColor = inputBg;
                DepartmentValue.ForeColor = textCol;
            }

            if (TeamValue != null)
            {
                TeamValue.BackColor = inputBg;
                TeamValue.ForeColor = textCol;
            }

            Button[] btns = { run };
            foreach (var b in btns)
            {
                if (b == null) continue;
                b.BackColor = SystemColors.Control;
                b.ForeColor = Color.Black;
                b.FlatStyle = FlatStyle.Standard;
            }
        }
    }
}
