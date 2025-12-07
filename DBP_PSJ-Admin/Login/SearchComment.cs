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
            if(SenderBox.SelectedIndex != -1 &&  ReceiverBox.SelectedIndex != -1)
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
                else if(KeyWord.Text == null && Date.Text != null)
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
            string info = $"{date[2]}-{date[1]}-{date[0]}";

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
    }
}
