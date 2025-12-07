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
    }
}
