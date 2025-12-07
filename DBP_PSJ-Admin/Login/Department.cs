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

            if(DepartmentList.SelectedItem != null)
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
    }
}
