using System.Windows.Forms;

namespace Login
{
    partial class ContactMainForm
    {
        private System.ComponentModel.IContainer components = null;

        // 부서/사원 TreeView
        private TreeView tvContacts;

        // 즐겨찾기 리스트
        private ListBox lstFavorites;

        // 검색 타입(ID/이름/부서)
        private ComboBox cbSearchType;

        // 검색어 입력
        private TextBox txtSearch;

        // 검색 버튼
        private Button btnSearch;

        // 즐겨찾기 추가/삭제
        private Button btnAddFavorite;
        private Button btnRemoveFavorite;

        // 현재 열려 있는 채팅방 목록
        private ListBox lstChatList;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tvContacts = new TreeView();
            lstFavorites = new ListBox();
            cbSearchType = new ComboBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnAddFavorite = new Button();
            btnRemoveFavorite = new Button();
            lstChatList = new ListBox();
            btnAdmin = new Button();
            btnWhite = new Button();
            SuspendLayout();
            // 
            // tvContacts
            // 
            tvContacts.Location = new Point(15, 17);
            tvContacts.Margin = new Padding(4);
            tvContacts.Name = "tvContacts";
            tvContacts.Size = new Size(312, 597);
            tvContacts.TabIndex = 7;
            tvContacts.NodeMouseDoubleClick += tvContacts_NodeMouseDoubleClick;
            // 
            // lstFavorites
            // 
            lstFavorites.ItemHeight = 25;
            lstFavorites.Location = new Point(335, 17);
            lstFavorites.Margin = new Padding(4);
            lstFavorites.Name = "lstFavorites";
            lstFavorites.Size = new Size(281, 229);
            lstFavorites.TabIndex = 6;
            lstFavorites.DoubleClick += lstFavorites_DoubleClick;
            // 
            // cbSearchType
            // 
            cbSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchType.Location = new Point(335, 291);
            cbSearchType.Margin = new Padding(4);
            cbSearchType.Name = "cbSearchType";
            cbSearchType.Size = new Size(135, 33);
            cbSearchType.TabIndex = 5;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(481, 293);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(135, 31);
            txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(335, 332);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(281, 44);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "검색";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAddFavorite
            // 
            btnAddFavorite.Font = new Font("맑은 고딕", 9F);
            btnAddFavorite.Location = new Point(335, 250);
            btnAddFavorite.Margin = new Padding(4);
            btnAddFavorite.Name = "btnAddFavorite";
            btnAddFavorite.Size = new Size(135, 35);
            btnAddFavorite.TabIndex = 2;
            btnAddFavorite.Text = "즐겨찾기 추가";
            btnAddFavorite.UseVisualStyleBackColor = true;
            btnAddFavorite.Click += btnAddFavorite_Click;
            // 
            // btnRemoveFavorite
            // 
            btnRemoveFavorite.Location = new Point(481, 250);
            btnRemoveFavorite.Margin = new Padding(4);
            btnRemoveFavorite.Name = "btnRemoveFavorite";
            btnRemoveFavorite.Size = new Size(135, 35);
            btnRemoveFavorite.TabIndex = 1;
            btnRemoveFavorite.Text = "즐겨찾기 삭제";
            btnRemoveFavorite.UseVisualStyleBackColor = true;
            btnRemoveFavorite.Click += btnRemoveFavorite_Click;
            // 
            // lstChatList
            // 
            lstChatList.ItemHeight = 25;
            lstChatList.Location = new Point(335, 384);
            lstChatList.Margin = new Padding(4);
            lstChatList.Name = "lstChatList";
            lstChatList.Size = new Size(281, 179);
            lstChatList.TabIndex = 0;
            lstChatList.DoubleClick += lstChatList_DoubleClick;
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(335, 570);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(135, 44);
            btnAdmin.TabIndex = 8;
            btnAdmin.Text = "관리자 기능";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // btnWhite
            // 
            btnWhite.Location = new Point(481, 570);
            btnWhite.Name = "btnWhite";
            btnWhite.Size = new Size(135, 44);
            btnWhite.TabIndex = 9;
            btnWhite.Text = "화이트 모드";
            btnWhite.UseVisualStyleBackColor = true;
            btnWhite.Click += btnWhite_Click;
            // 
            // ContactMainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 632);
            Controls.Add(btnWhite);
            Controls.Add(btnAdmin);
            Controls.Add(lstChatList);
            Controls.Add(btnRemoveFavorite);
            Controls.Add(btnAddFavorite);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(cbSearchType);
            Controls.Add(lstFavorites);
            Controls.Add(tvContacts);
            Margin = new Padding(4);
            Name = "ContactMainForm";
            Text = "대화 상대 관리 / 1:1 채팅";
            FormClosing += ContactMainForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnAdmin;
        private Button btnWhite;
    }
}