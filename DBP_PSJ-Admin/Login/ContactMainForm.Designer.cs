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
            components = new System.ComponentModel.Container();
            tvContacts = new TreeView();
            contextMenuStrip2 = new ContextMenuStrip(components);
            cmsContacts = new ToolStripMenuItem();
            menuSetMultiProfile = new ToolStripMenuItem();
            lstFavorites = new ListBox();
            cbSearchType = new ComboBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnAddFavorite = new Button();
            btnRemoveFavorite = new Button();
            lstChatList = new ListBox();
            btnAdmin = new Button();
            btnWhite = new Button();
            btnEditProfile = new Button();
            btnLogout = new Button();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // tvContacts
            // 
            tvContacts.ContextMenuStrip = contextMenuStrip2;
            tvContacts.Location = new Point(10, 29);
            tvContacts.Margin = new Padding(3, 2, 3, 2);
            tvContacts.Name = "tvContacts";
            tvContacts.Size = new Size(220, 388);
            tvContacts.TabIndex = 7;
            tvContacts.AfterSelect += tvContacts_AfterSelect;
            tvContacts.NodeMouseDoubleClick += tvContacts_NodeMouseDoubleClick;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { cmsContacts });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(99, 26);
            // 
            // cmsContacts
            // 
            cmsContacts.DropDownItems.AddRange(new ToolStripItem[] { menuSetMultiProfile });
            cmsContacts.Name = "cmsContacts";
            cmsContacts.Size = new Size(98, 22);
            cmsContacts.Text = "이름";
            // 
            // menuSetMultiProfile
            // 
            menuSetMultiProfile.Name = "menuSetMultiProfile";
            menuSetMultiProfile.Size = new Size(178, 22);
            menuSetMultiProfile.Text = "상대별 프로필 설정";
            menuSetMultiProfile.Click += menuSetMultiProfile_Click;
            // 
            // lstFavorites
            // 
            lstFavorites.ItemHeight = 15;
            lstFavorites.Location = new Point(234, 32);
            lstFavorites.Margin = new Padding(3, 2, 3, 2);
            lstFavorites.Name = "lstFavorites";
            lstFavorites.Size = new Size(300, 169);
            lstFavorites.TabIndex = 6;
            lstFavorites.DoubleClick += lstFavorites_DoubleClick;
            // 
            // cbSearchType
            // 
            cbSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchType.Location = new Point(256, 227);
            cbSearchType.Margin = new Padding(3, 2, 3, 2);
            cbSearchType.Name = "cbSearchType";
            cbSearchType.Size = new Size(96, 23);
            cbSearchType.TabIndex = 5;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(429, 227);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(96, 23);
            txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(234, 251);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(300, 26);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "검색";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAddFavorite
            // 
            btnAddFavorite.Font = new Font("맑은 고딕", 9F);
            btnAddFavorite.Location = new Point(236, 202);
            btnAddFavorite.Margin = new Padding(3, 2, 3, 2);
            btnAddFavorite.Name = "btnAddFavorite";
            btnAddFavorite.Size = new Size(150, 21);
            btnAddFavorite.TabIndex = 2;
            btnAddFavorite.Text = "즐겨찾기 추가";
            btnAddFavorite.UseVisualStyleBackColor = true;
            btnAddFavorite.Click += btnAddFavorite_Click;
            // 
            // btnRemoveFavorite
            // 
            btnRemoveFavorite.Location = new Point(401, 202);
            btnRemoveFavorite.Margin = new Padding(3, 2, 3, 2);
            btnRemoveFavorite.Name = "btnRemoveFavorite";
            btnRemoveFavorite.Size = new Size(133, 21);
            btnRemoveFavorite.TabIndex = 1;
            btnRemoveFavorite.Text = "즐겨찾기 삭제";
            btnRemoveFavorite.UseVisualStyleBackColor = true;
            btnRemoveFavorite.Click += btnRemoveFavorite_Click;
            // 
            // lstChatList
            // 
            lstChatList.ItemHeight = 15;
            lstChatList.Location = new Point(234, 282);
            lstChatList.Margin = new Padding(3, 2, 3, 2);
            lstChatList.Name = "lstChatList";
            lstChatList.Size = new Size(300, 109);
            lstChatList.TabIndex = 0;
            lstChatList.DoubleClick += lstChatList_DoubleClick;
            // 
            // btnAdmin
            // 
            btnAdmin.Location = new Point(234, 394);
            btnAdmin.Margin = new Padding(2);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(94, 26);
            btnAdmin.TabIndex = 8;
            btnAdmin.Text = "관리자 기능";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // btnWhite
            // 
            btnWhite.Location = new Point(432, 394);
            btnWhite.Margin = new Padding(2);
            btnWhite.Name = "btnWhite";
            btnWhite.Size = new Size(94, 26);
            btnWhite.TabIndex = 9;
            btnWhite.Text = "화이트 모드";
            btnWhite.UseVisualStyleBackColor = true;
            btnWhite.Click += btnWhite_Click;
            // 
            // btnEditProfile
            // 
            btnEditProfile.Location = new Point(334, 394);
            btnEditProfile.Margin = new Padding(2);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(94, 26);
            btnEditProfile.TabIndex = 10;
            btnEditProfile.Text = "프로필 수정";
            btnEditProfile.UseVisualStyleBackColor = true;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(459, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "로그아웃";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // ContactMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 428);
            Controls.Add(btnLogout);
            Controls.Add(btnEditProfile);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "ContactMainForm";
            Text = "대화 상대 관리 / 1:1 채팅";
            FormClosing += ContactMainForm_FormClosing;
            Load += ContactMainForm_Load;
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnAdmin;
        private Button btnWhite;
        private Button btnEditProfile;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem cmsContacts;
        private ToolStripMenuItem menuSetMultiProfile;
        private Button btnLogout;
    }
}