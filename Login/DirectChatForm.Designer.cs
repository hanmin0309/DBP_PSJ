using System.Windows.Forms;

namespace Login
{
    partial class DirectChatForm
    {
        private System.ComponentModel.IContainer components = null;

        private FlowLayoutPanel flowMessages;
        private TextBox txtInput;
        private Button btnSend;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            flowMessages = new FlowLayoutPanel();
            txtInput = new TextBox();
            btnSend = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnDelete = new Button();
            cboNotice = new ComboBox();
            btnNoticeRemove = new Button();
            btnNoticeAdd = new Button();
            SuspendLayout();
            // 
            // flowMessages
            // 
            flowMessages.AutoScroll = true;
            flowMessages.BackColor = Color.LightYellow;
            flowMessages.FlowDirection = FlowDirection.TopDown;
            flowMessages.Location = new Point(15, 52);
            flowMessages.Margin = new Padding(4);
            flowMessages.Name = "flowMessages";
            flowMessages.Padding = new Padding(6, 7, 6, 7);
            flowMessages.Size = new Size(782, 548);
            flowMessages.TabIndex = 8;
            flowMessages.WrapContents = false;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(15, 611);
            txtInput.Margin = new Padding(4);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(624, 31);
            txtInput.TabIndex = 0;
            txtInput.KeyDown += txtInput_KeyDown;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(650, 608);
            btnSend.Margin = new Padding(4);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(148, 42);
            btnSend.TabIndex = 1;
            btnSend.Text = "전송";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(15, 658);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(449, 31);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(472, 656);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 42);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "검색";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(650, 656);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(148, 42);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "선택 삭제";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // cboNotice
            // 
            cboNotice.FormattingEnabled = true;
            cboNotice.Location = new Point(12, 12);
            cboNotice.Name = "cboNotice";
            cboNotice.Size = new Size(480, 33);
            cboNotice.TabIndex = 5;
            // 
            // btnNoticeRemove
            // 
            btnNoticeRemove.Location = new Point(650, 10);
            btnNoticeRemove.Name = "btnNoticeRemove";
            btnNoticeRemove.Size = new Size(147, 34);
            btnNoticeRemove.TabIndex = 7;
            btnNoticeRemove.Text = "공지삭제";
            btnNoticeRemove.UseVisualStyleBackColor = true;
            btnNoticeRemove.Click += btnNoticeRemove_Click;
            // 
            // btnNoticeAdd
            // 
            btnNoticeAdd.Location = new Point(498, 11);
            btnNoticeAdd.Name = "btnNoticeAdd";
            btnNoticeAdd.Size = new Size(147, 34);
            btnNoticeAdd.TabIndex = 6;
            btnNoticeAdd.Text = "공지추가";
            btnNoticeAdd.UseVisualStyleBackColor = true;
            btnNoticeAdd.Click += btnNoticeAdd_Click;
            // 
            // DirectChatForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 715);
            Controls.Add(btnNoticeAdd);
            Controls.Add(btnNoticeRemove);
            Controls.Add(cboNotice);
            Controls.Add(btnDelete);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnSend);
            Controls.Add(txtInput);
            Controls.Add(flowMessages);
            Margin = new Padding(4);
            Name = "DirectChatForm";
            Text = "1:1 채팅";
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cboNotice;
        private Button btnNoticeRemove;
        private Button btnNoticeAdd;
    }
}