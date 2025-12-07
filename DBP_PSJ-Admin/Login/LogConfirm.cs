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
            if(user != null)
            {
                foreach(DataRow row in user.Rows)
                {
                    UserBox.Items.Add($"{row["ID"]} {row["Name"]}");
                }
            }
        }

        private void UserBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(UserBox.SelectedIndex != -1)
            {
                string[] user = UserBox.SelectedItem.ToString().Split(' ');

                DataTable table = DBconnector.getInstance().ShowChatUserLog(user[0], user[1]);

                UserLogView.DataSource = table;
            }
        }
    }
}
