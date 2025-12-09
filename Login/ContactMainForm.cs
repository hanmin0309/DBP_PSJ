using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace Login
{
    public partial class ContactMainForm : Form
    {
        // 로그인 성공 시 전달받은 DataTable (ChatUserDetail_test 기준)
        private DataTable table = new DataTable();

        // 서버에서 받은 유저 리스트(부서/ID/표시이름)를 담는 내부 모델
        public class UserInfo
        {
            public string DeptName;     // department
            public string UserId;       // ChatUserDetail_test.ID
            public string DisplayName;  // NickName 등
        }

        // 즐겨찾기 리스트 아이템
        public class FavoriteItem
        {
            public string EmpId;        // 실제로는 ChatUserDetail_test.ID
            public string DisplayName;  // NickName

            public override string ToString()
            {
                return $"{DisplayName} ({EmpId})";
            }
        }

        // 검색/TreeView용 전체 유저 목록 캐시
        private List<UserInfo> allUsers = new List<UserInfo>();

        public ContactMainForm(DataTable usertable)
        {
            InitializeComponent();

            table = usertable;

            string Admin = table.Rows[0]["isAdmin"].ToString();
            int admin = int.Parse(Admin);

            if (admin == 0)
            {
                btnAdmin.Hide();
            }

            // 검색 타입 콤보 초기화
            cbSearchType.Items.Clear();
            cbSearchType.Items.AddRange(new object[] { "ID", "이름", "부서" });
            cbSearchType.SelectedIndex = 0;

            // 아래 채팅방 목록: DirectChatForm.Text 를 표시
            lstChatList.DisplayMember = "Text";

            // 이 폼이 닫히면 프로그램 전체 종료
            this.FormClosing += ContactMainForm_FormClosing;

            // ★ 로그인한 사용자 ID를 Program.CurrentUserId에 세팅 (ChatUserDetail_test.ID)
            if (table != null && table.Rows.Count > 0)
            {
                if (table.Columns.Contains("ID"))
                {
                    Program.CurrentUserId = table.Rows[0]["ID"].ToString();
                }
                else
                {
                    MessageBox.Show("로그인 결과 DataTable 에 'ID' 컬럼이 없습니다.\nChatUserDetail_test 테이블 구조와 일치하는지 확인하세요.");
                }
            }

            // Program 쪽에 현재 유저 정보 / 메인 폼 등록 후 서버 연결 시작
            Program.CurrentUserTable = table;
            Program.ContactMain = this;

            // ★ 로그인 폼과 비슷한 다크 테마 적용
            ApplyTheme(Program.IsDarkTheme);

            Program.StartChat();
        }

        /// <summary>
        /// ContactMainForm 이 닫힐 때 앱 전체 종료
        /// </summary>
        private void ContactMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

            // 좌측 연락처 트리
            if (tvContacts != null)
            {
                tvContacts.BackColor = panelBg;
                tvContacts.ForeColor = textCol;
            }

            // 즐겨찾기 리스트
            if (lstFavorites != null)
            {
                lstFavorites.BackColor = panelBg;
                lstFavorites.ForeColor = textCol;
            }

            // 현재 채팅 목록
            if (lstChatList != null)
            {
                lstChatList.BackColor = panelBg;
                lstChatList.ForeColor = textCol;
            }

            // 검색 관련
            if (cbSearchType != null)
            {
                cbSearchType.BackColor = inputBg;
                cbSearchType.ForeColor = textCol;
                cbSearchType.FlatStyle = FlatStyle.Flat;
            }

            if (txtSearch != null)
            {
                txtSearch.BackColor = inputBg;
                txtSearch.ForeColor = textCol;
                txtSearch.BorderStyle = BorderStyle.FixedSingle;
            }

            // 버튼들: 검색 / 즐찾 추가 / 즐찾 삭제
            Button[] btns =
            {
                btnSearch,
                btnAddFavorite,
                btnRemoveFavorite
            };

            btnAdmin.ForeColor = Color.Black;
            btnWhite.ForeColor = Color.Black;

            foreach (var b in btns)
            {
                if (b == null) continue;
                b.BackColor = accent;
                b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            }

            if (btnWhite != null)
                btnWhite.Text = "화이트 모드";
        }

        private void ApplyWhiteTheme()
        {
            Color formBg = SystemColors.Control;
            Color panelBg = Color.White;
            Color inputBg = Color.White;
            Color textCol = Color.Black;

            this.BackColor = formBg;
            this.ForeColor = textCol;

            if (tvContacts != null)
            {
                tvContacts.BackColor = panelBg;
                tvContacts.ForeColor = textCol;
            }

            if (lstFavorites != null)
            {
                lstFavorites.BackColor = panelBg;
                lstFavorites.ForeColor = textCol;
            }

            if (lstChatList != null)
            {
                lstChatList.BackColor = panelBg;
                lstChatList.ForeColor = textCol;
            }

            if (cbSearchType != null)
            {
                cbSearchType.BackColor = inputBg;
                cbSearchType.ForeColor = textCol;
                cbSearchType.FlatStyle = FlatStyle.Standard;
            }

            if (txtSearch != null)
            {
                txtSearch.BackColor = inputBg;
                txtSearch.ForeColor = textCol;
                txtSearch.BorderStyle = BorderStyle.FixedSingle;
            }

            Button[] btns = { btnSearch, btnAddFavorite, btnRemoveFavorite, btnWhite, btnAdmin };
            foreach (var b in btns)
            {
                if (b == null) continue;
                b.BackColor = SystemColors.Control;
                b.ForeColor = Color.Black;
                b.FlatStyle = FlatStyle.Standard;
            }

            if (btnWhite != null)
                btnWhite.Text = "다크 모드";   // 다시 누르면 다크 모드로
        }

        // ================== 서버에서 온 유저 리스트(TreeView) 설정 ==================
        // data 형식 예: "부서|표시이름|ID\n부서|표시이름|ID\n..."
        public void SetUserTree(string data)
        {
            tvContacts.Nodes.Clear();
            allUsers.Clear();

            Dictionary<string, TreeNode> deptNodes =
                new Dictionary<string, TreeNode>();

            string[] lines = data.Split(new char[] { '\n' },
                                        StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length < 3) continue;

                string dept = parts[0];
                string disp = parts[1];
                string id = parts[2];     // ChatUserDetail_test.ID

                // 검색용 캐시
                UserInfo u = new UserInfo
                {
                    DeptName = dept,
                    DisplayName = disp,
                    UserId = id
                };
                allUsers.Add(u);

                // TreeView 구성
                TreeNode deptNode;
                if (!deptNodes.TryGetValue(dept, out deptNode))
                {
                    deptNode = new TreeNode(dept);
                    tvContacts.Nodes.Add(deptNode);
                    deptNodes.Add(dept, deptNode);
                }

                TreeNode uNode = new TreeNode(disp);
                uNode.Tag = id;          // Tag에 ID 저장
                deptNode.Nodes.Add(uNode);
            }

            tvContacts.ExpandAll();
        }

        // ================== 즐겨찾기 리스트 설정 ==================
        // data 형식 예: "ID|NickName\nID|NickName\n..."
        public void SetFavoriteList(string data)
        {
            lstFavorites.Items.Clear();

            string[] lines = data.Split(new char[] { '\n' },
                                        StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length < 2) continue;

                FavoriteItem item = new FavoriteItem
                {
                    EmpId = parts[0],   // = ChatUserDetail_test.ID
                    DisplayName = parts[1]    // = NickName
                };

                lstFavorites.Items.Add(item);
            }
        }

        // ================== 검색 버튼 ==================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "") return;

            if (cbSearchType.SelectedIndex < 0)
            {
                MessageBox.Show("검색 기준을 선택하세요.");
                return;
            }

            string type = cbSearchType.SelectedItem.ToString();

            // allUsers 에서 필터링
            List<UserInfo> filtered =
                allUsers.Where(u =>
                {
                    if (type == "ID")
                        return (u.UserId != null && u.UserId.Contains(keyword));
                    else if (type == "이름")
                        return (u.DisplayName != null && u.DisplayName.Contains(keyword));
                    else if (type == "부서")
                        return (u.DeptName != null && u.DeptName.Contains(keyword));
                    return false;
                }).ToList();

            if (filtered.Count == 0)
            {
                MessageBox.Show("검색 결과가 없습니다.");
                return;
            }

            // 첫 번째 결과로 이동
            UserInfo first = filtered[0];

            // TreeView에서 해당 노드 찾기
            foreach (TreeNode deptNode in tvContacts.Nodes)
            {
                foreach (TreeNode uNode in deptNode.Nodes)
                {
                    if (uNode.Text == first.DisplayName &&
                        (string)uNode.Tag == first.UserId)
                    {
                        tvContacts.SelectedNode = uNode;
                        tvContacts.Focus();
                        return;
                    }
                }
            }

            MessageBox.Show("TreeView 상에 해당 사용자를 찾지 못했습니다.");
        }

        // ================== TreeView 더블클릭 → 1:1 채팅 열기 ==================
        private void tvContacts_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null) return;

            string targetId = e.Node.Tag.ToString();   // 상대방 ID
            OpenDirectChat(targetId, e.Node.Text);     // 표시 이름
        }

        // ================== 즐겨찾기 더블클릭 → 1:1 채팅 ==================
        private void lstFavorites_DoubleClick(object sender, EventArgs e)
        {
            FavoriteItem item = lstFavorites.SelectedItem as FavoriteItem;
            if (item == null) return;

            OpenDirectChat(item.EmpId, item.DisplayName);
        }

        // ================== 1:1 채팅창 열기 공통 함수 ==================
        private void OpenDirectChat(string targetId, string displayName)
        {
            DirectChatForm chat = Program.GetOrCreateDirectChat(targetId, displayName);
            chat.Show();
            chat.Focus();

            // 히스토리 요청 (DMH + 상대 ID)
            Program.SendPacket("DMH", targetId);

            // 채팅 목록 갱신
            UpdateChatList();
        }

        // ================== 즐겨찾기 추가/삭제 ==================
        private void btnAddFavorite_Click(object sender, EventArgs e)
        {
            TreeNode node = tvContacts.SelectedNode;
            if (node == null || node.Tag == null) return;

            string targetId = node.Tag.ToString();   // 선택된 유저 ID
            Program.SendPacket("FAV", targetId);
        }

        private void btnRemoveFavorite_Click(object sender, EventArgs e)
        {
            FavoriteItem item = lstFavorites.SelectedItem as FavoriteItem;
            if (item == null) return;

            Program.SendPacket("FRE", item.EmpId);
        }

        // ================== 현재 채팅 중인 목록 갱신 ==================
        public void UpdateChatList()
        {
            lstChatList.Items.Clear();

            foreach (var kv in Program.DirectChats)
            {
                DirectChatForm f = kv.Value;
                if (f == null || f.IsDisposed) continue;

                // DisplayMember = "Text" 이므로
                // 여기서는 DirectChatForm 객체 자체를 넣어주면
                // ListBox에는 f.Text(예: "1:1 채팅 - qwer(qwer)")가 표시됨
                lstChatList.Items.Add(f);
            }
        }

        // ================== 대화 목록 더블클릭 → 채팅창 앞으로 ==================
        private void lstChatList_DoubleClick(object sender, EventArgs e)
        {
            DirectChatForm f = lstChatList.SelectedItem as DirectChatForm;
            if (f == null) return;

            f.Show();
            f.Activate();
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            // 전역 테마 플래그 토글
            Program.IsDarkTheme = !Program.IsDarkTheme;

            // 메인 폼 테마 적용
            ApplyTheme(Program.IsDarkTheme);

            // 모든 열린 채팅방에도 적용
            foreach (var kv in Program.DirectChats)
            {
                var form = kv.Value;
                if (form != null && !form.IsDisposed)
                    form.ApplyTheme(Program.IsDarkTheme);
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            //관리자 폼 연결 필요!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }
}