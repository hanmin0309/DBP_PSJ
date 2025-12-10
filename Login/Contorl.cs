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
using static EG.DBconnector;

namespace EG
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            InitServerInfo();
            ApplyTheme(Program.IsDarkTheme);
            if (DBconnector.getInstance().CheckLogin() == true)
            {
                // show  table
                DataTable table;
                table = DBconnector.getInstance().ShowChatUserList();
                Grid02.DataSource = table;
                table = DBconnector.getInstance().ShowChatUserPermission();
                Grid01.DataSource = table;
                table = DBconnector.getInstance().ShowChatUserList();
                foreach (DataRow row in table.Rows)
                {
                    user01.Items.Add(row["ID"].ToString());
                }
            }
        }

        // DB connect
        public void InitServerInfo()
        {
            string add = "223.130.151.111";
            int port = 3306;
            string database = "s5701514";

            DBconnector.getInstance().InitServer(add, port, database, database, database);
        }
        //

        /* Strip Menu */
        private void 부서관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainform = new Department();
            mainform.ShowDialog();
        }
        private void 로그확인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainform = new LogConfirm();
            mainform.ShowDialog();
        }
        private void 대화검색ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainform = new SearchComment();
            mainform.ShowDialog();
        }
        //

        /* Button Click Event */
        // 보기 / 대화 건환을 활성화
        private void butAllow_Click(object sender, EventArgs e)
        {
            string send = user01.SelectedItem.ToString();
            string receive = user02.SelectedItem.ToString();

            DBconnector.getInstance().ChangePermission(send, receive, 1);
            DBconnector.getInstance().ChangePermission(receive, send, 1);

            // show  table
            DataTable table;
            table = DBconnector.getInstance().ShowChatUserList();
            Grid02.DataSource = table;
            table = DBconnector.getInstance().ShowChatUserPermission();
            Grid01.DataSource = table;
        }
        // 보기 / 대화 권한을 비활성화
        private void butDisallow_Click(object sender, EventArgs e)
        {
            string send = user01.SelectedItem.ToString();
            string receive = user02.SelectedItem.ToString();

            DBconnector.getInstance().ChangePermission(send, receive, 0);
            DBconnector.getInstance().ChangePermission(receive, send, 0);

            // show  table
            DataTable table;
            table = DBconnector.getInstance().ShowChatUserList();
            Grid02.DataSource = table;
            table = DBconnector.getInstance().ShowChatUserPermission();
            Grid01.DataSource = table;
        }
        //

        /* textbox click event*/
        // 첫 번째 콤보상자의 이름을 선택하면
        // 두 번째 콤보상자에 이름을 채움 ( 첫 번째 상자에서 선택된 사람을 제외한 )
        private void user01_SelectedIndexChanged(object sender, EventArgs e)
        {
            user02.Items.Clear();

            string user = user01.SelectedItem.ToString();

            DataTable table = DBconnector.getInstance().GetUserID(user);

            foreach (DataRow row in table.Rows)
            {
                user02.Items.Add(row["ID"].ToString());
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
            if (label != null)
            {
                label.BackColor = panelBg;
                label.ForeColor = textCol;
            }

            // 
            if (label1 != null)
            {
                label1.BackColor = panelBg;
                label1.ForeColor = textCol;
            }

            // 
            if (user01 != null)
            {
                user01.BackColor = panelBg;
                user01.ForeColor = textCol;
            }

            // 
            if (user02 != null)
            {
                user02.BackColor = inputBg;
                user02.ForeColor = textCol;
                user02.FlatStyle = FlatStyle.Flat;
            }

            // 
            Button[] btns =
            {
                butAllow,
                butDisallow
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

            if (user01 != null)
            {
                user01.BackColor = panelBg;
                user01.ForeColor = textCol;
            }

            if (user02 != null)
            {
                user02.BackColor = inputBg;
                user02.ForeColor = textCol;
            }

            Button[] btns = { butAllow, butDisallow };
            foreach (var b in btns)
            {
                if (b == null) continue;
                b.BackColor = SystemColors.Control;
                b.ForeColor = Color.Black;
                b.FlatStyle = FlatStyle.Standard;
            }
        }

        // 프로그램 연결할 때 이 form만 오류가나서 생김
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            butDisallow = new Button();
            butAllow = new Button();
            label1 = new Label();
            label = new Label();
            user02 = new ComboBox();
            user01 = new ComboBox();
            Control = new TabControl();
            tab01 = new TabPage();
            Grid01 = new DataGridView();
            tab02 = new TabPage();
            Grid02 = new DataGridView();
            menuStrip1 = new MenuStrip();
            부서관리ToolStripMenuItem = new ToolStripMenuItem();
            로그확인ToolStripMenuItem = new ToolStripMenuItem();
            대화검색ToolStripMenuItem = new ToolStripMenuItem();
            Control.SuspendLayout();
            tab01.SuspendLayout();
            ((ISupportInitialize)Grid01).BeginInit();
            tab02.SuspendLayout();
            ((ISupportInitialize)Grid02).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // butDisallow
            // 
            butDisallow.BackColor = SystemColors.ActiveCaptionText;
            butDisallow.FlatStyle = FlatStyle.Flat;
            butDisallow.ForeColor = Color.Yellow;
            butDisallow.Location = new Point(308, 412);
            butDisallow.Margin = new Padding(3, 4, 3, 4);
            butDisallow.Name = "butDisallow";
            butDisallow.Size = new Size(75, 29);
            butDisallow.TabIndex = 19;
            butDisallow.Text = "불가";
            butDisallow.UseVisualStyleBackColor = false;
            butDisallow.Click += butDisallow_Click;
            // 
            // butAllow
            // 
            butAllow.BackColor = SystemColors.ActiveCaptionText;
            butAllow.FlatStyle = FlatStyle.Flat;
            butAllow.ForeColor = Color.Yellow;
            butAllow.Location = new Point(308, 376);
            butAllow.Margin = new Padding(3, 4, 3, 4);
            butAllow.Name = "butAllow";
            butAllow.Size = new Size(75, 29);
            butAllow.TabIndex = 18;
            butAllow.Text = "가능";
            butAllow.UseVisualStyleBackColor = false;
            butAllow.Click += butAllow_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("굴림", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(14, 376);
            label1.Name = "label1";
            label1.Size = new Size(136, 12);
            label1.TabIndex = 17;
            label1.Text = "보기 / 대화 권한 조정";
            // 
            // label
            // 
            label.AutoSize = true;
            label.ForeColor = Color.Yellow;
            label.Location = new Point(141, 418);
            label.Name = "label";
            label.Size = new Size(19, 15);
            label.TabIndex = 16;
            label.Text = "와";
            // 
            // user02
            // 
            user02.BackColor = SystemColors.ActiveCaptionText;
            user02.FlatStyle = FlatStyle.Flat;
            user02.ForeColor = Color.Yellow;
            user02.FormattingEnabled = true;
            user02.Location = new Point(164, 408);
            user02.Margin = new Padding(3, 4, 3, 4);
            user02.Name = "user02";
            user02.Size = new Size(121, 23);
            user02.TabIndex = 15;
            // 
            // user01
            // 
            user01.BackColor = SystemColors.ActiveCaptionText;
            user01.FlatStyle = FlatStyle.Flat;
            user01.ForeColor = Color.Yellow;
            user01.FormattingEnabled = true;
            user01.Location = new Point(14, 408);
            user01.Margin = new Padding(3, 4, 3, 4);
            user01.Name = "user01";
            user01.Size = new Size(121, 23);
            user01.TabIndex = 14;
            user01.SelectedIndexChanged += user01_SelectedIndexChanged;
            // 
            // Control
            // 
            Control.Controls.Add(tab01);
            Control.Controls.Add(tab02);
            Control.Location = new Point(12, 38);
            Control.Margin = new Padding(3, 4, 3, 4);
            Control.Name = "Control";
            Control.SelectedIndex = 0;
            Control.Size = new Size(481, 315);
            Control.TabIndex = 12;
            // 
            // tab01
            // 
            tab01.BackColor = Color.White;
            tab01.Controls.Add(Grid01);
            tab01.Location = new Point(4, 24);
            tab01.Margin = new Padding(3, 4, 3, 4);
            tab01.Name = "tab01";
            tab01.Padding = new Padding(3, 4, 3, 4);
            tab01.Size = new Size(473, 287);
            tab01.TabIndex = 0;
            tab01.Text = "유저 권한 현황";
            // 
            // Grid01
            // 
            Grid01.BackgroundColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new Font("굴림", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            dataGridViewCellStyle3.ForeColor = Color.Yellow;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Grid01.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            Grid01.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid01.Location = new Point(0, 0);
            Grid01.Margin = new Padding(3, 4, 3, 4);
            Grid01.Name = "Grid01";
            Grid01.RowTemplate.Height = 23;
            Grid01.Size = new Size(473, 282);
            Grid01.TabIndex = 1;
            // 
            // tab02
            // 
            tab02.BackColor = Color.White;
            tab02.Controls.Add(Grid02);
            tab02.Location = new Point(4, 24);
            tab02.Margin = new Padding(3, 4, 3, 4);
            tab02.Name = "tab02";
            tab02.Padding = new Padding(3, 4, 3, 4);
            tab02.Size = new Size(473, 287);
            tab02.TabIndex = 1;
            tab02.Text = "유저 정보";
            // 
            // Grid02
            // 
            Grid02.BackgroundColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new Font("굴림", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            dataGridViewCellStyle4.ForeColor = Color.Yellow;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            Grid02.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            Grid02.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid02.Location = new Point(0, 0);
            Grid02.Margin = new Padding(3, 4, 3, 4);
            Grid02.Name = "Grid02";
            Grid02.RowTemplate.Height = 23;
            Grid02.Size = new Size(473, 282);
            Grid02.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Info;
            menuStrip1.Items.AddRange(new ToolStripItem[] { 부서관리ToolStripMenuItem, 로그확인ToolStripMenuItem, 대화검색ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(539, 24);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // 부서관리ToolStripMenuItem
            // 
            부서관리ToolStripMenuItem.Name = "부서관리ToolStripMenuItem";
            부서관리ToolStripMenuItem.Size = new Size(71, 20);
            부서관리ToolStripMenuItem.Text = "부서 관리";
            부서관리ToolStripMenuItem.Click += 부서관리ToolStripMenuItem_Click;
            // 
            // 로그확인ToolStripMenuItem
            // 
            로그확인ToolStripMenuItem.Name = "로그확인ToolStripMenuItem";
            로그확인ToolStripMenuItem.Size = new Size(71, 20);
            로그확인ToolStripMenuItem.Text = "로그 확인";
            로그확인ToolStripMenuItem.Click += 로그확인ToolStripMenuItem_Click;
            // 
            // 대화검색ToolStripMenuItem
            // 
            대화검색ToolStripMenuItem.Name = "대화검색ToolStripMenuItem";
            대화검색ToolStripMenuItem.Size = new Size(71, 20);
            대화검색ToolStripMenuItem.Text = "대화 검색";
            대화검색ToolStripMenuItem.Click += 대화검색ToolStripMenuItem_Click;
            // 
            // AdminForm
            // 
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(539, 463);
            Controls.Add(butDisallow);
            Controls.Add(butAllow);
            Controls.Add(label1);
            Controls.Add(label);
            Controls.Add(user02);
            Controls.Add(user01);
            Controls.Add(Control);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "AdminForm";
            Load += AdminForm_Load;
            Control.ResumeLayout(false);
            tab01.ResumeLayout(false);
            ((ISupportInitialize)Grid01).EndInit();
            tab02.ResumeLayout(false);
            ((ISupportInitialize)Grid02).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        private Button butDisallow;
        private Button butAllow;
        private Label label1;
        private Label label;
        private ComboBox user02;
        private ComboBox user01;
        private TabControl Control;
        private TabPage tab01;
        private DataGridView Grid01;
        private TabPage tab02;
        private DataGridView Grid02;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 부서관리ToolStripMenuItem;
        private ToolStripMenuItem 로그확인ToolStripMenuItem;
        private ToolStripMenuItem 대화검색ToolStripMenuItem;
    }
}
