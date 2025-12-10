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
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ApplyTheme(Program.IsDarkTheme);
            LoadData();
        }

        public void LoadData()
        {
            DataTable temp = DBconnector.getInstance().ShowChatUserDepartment();
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
            TeamText.Text = "";
            TeamValue.Clear();

            if (DepartmentList.SelectedItem != null)
            {
                string department = DepartmentList.SelectedItem.ToString();
                DataTable temp = DBconnector.getInstance().ShowChatUserTeam(department);

                foreach (DataRow row in temp.Rows)
                {
                    TeamList.Items.Add(row["Team"].ToString());
                }

                DepartmentText.Text = DepartmentList.SelectedItem.ToString();
                DepartmentValue.Text = DepartmentList.SelectedItem.ToString();
            }
        }
        private void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeamList.SelectedItem != null)
            {
                TeamText.Text = TeamList.SelectedItem.ToString();
                TeamValue.Text = TeamList.SelectedItem.ToString();
            }
        }

        private void 유저부서관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainform = new Form3();
            mainform.ShowDialog();
        }

        private void DepartmentValue_Click(object sender, EventArgs e)
        {
            DepartmentValue.Clear();
        }

        private void TeamValue_Click(object sender, EventArgs e)
        {
            TeamValue.Clear();
        }

        private void run_Click(object sender, EventArgs e)
        {
            string department = DepartmentList.SelectedItem.ToString();
            string team = TeamList.SelectedItem.ToString();

            string[] destination = new string[2];
            destination[0] = DepartmentValue.Text;
            destination[1] = TeamValue.Text;

            if (destination[0] != "" && destination[1] != "")
            {
                DBconnector.getInstance().ChangeDepartment(department, destination[0]);
                DBconnector.getInstance().ChangeTeam(department, team, destination[0], destination[1]);
            }

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


            this.BackColor = formBg;
            this.ForeColor = textCol;

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

            if (label != null)
            {
                label.BackColor = panelBg;
                label.ForeColor = textCol;
            }
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
            if (textBox1 != null)
            {
                textBox1.BackColor = inputBg;
                textBox1.ForeColor = textCol;
            }
            if (textBox2 != null)
            {
                textBox2.BackColor = inputBg;
                textBox2.ForeColor = textCol;
            }

            Button[] btns = { run, buttonDepartment, button1 };
            foreach (var b in btns)
            {
                if (b == null) continue;
                b.BackColor = SystemColors.Control;
                b.ForeColor = Color.Black;
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

            if (label != null)
            {
                label.BackColor = panelBg;
                label.ForeColor = textCol;
            }
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
            if (textBox1 != null)
            {
                textBox1.BackColor = inputBg;
                textBox1.ForeColor = textCol;
            }
            if (textBox2 != null)
            {
                textBox2.BackColor = inputBg;
                textBox2.ForeColor = textCol;
            }

            Button[] btns = { run, buttonDepartment, button1 };
            foreach (var b in btns)
            {
                if (b == null) continue;
                b.BackColor = SystemColors.Control;
                b.ForeColor = Color.Black;
            }
        }
    }
}
