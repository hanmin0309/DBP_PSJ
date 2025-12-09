using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Login
{
    public partial class DirectChatForm : Form
    {
        public string TargetId { get; }
        public string DisplayName { get; }

        private DateTime lastDate = DateTime.MinValue;
        private readonly CultureInfo ko = new CultureInfo("ko-KR");

        private MessageItem _selectedMessage;

        // 검색 상태
        private string _lastSearchKeyword = "";
        private int _lastSearchIndex = -1;

        // 공지사항 콤보박스 아이템
        private class NoticeItem
        {
            public int NoticeId { get; set; }
            public string OwnerId { get; set; }
            public string Content { get; set; }

            public override string ToString() => Content;
        }

        private readonly List<NoticeItem> _noticeItems = new List<NoticeItem>();

        public DirectChatForm(string targetId, string displayName)
        {
            InitializeComponent();

            TargetId = targetId;
            DisplayName = displayName;
            this.Text = $"1:1 채팅 - {displayName}";

            // 메시지 영역 기본 세팅
            flowMessages.FlowDirection = FlowDirection.TopDown;
            flowMessages.WrapContents = false;
            flowMessages.AutoScroll = true;

            ApplyTheme(Program.IsDarkTheme);

            // 폼 리사이즈 시 말풍선 폭 조정
            this.Resize += DirectChatForm_Resize;

            Program.SendPacket("DNL", TargetId);
        }

        // ================== 날짜 헤더 추가 ==================
        private void AddDateHeader(DateTime when)
        {
            string text = when.ToString("yyyy년 M월 d일", ko);

            Label lbl = new Label
            {
                AutoSize = false,
                Width = flowMessages.Width - 20,
                Height = 22,
                Text = $"──────────  {text}  ──────────",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Gray,
                Margin = new Padding(3, 10, 3, 10),
                BackColor = Color.Transparent
            };

            flowMessages.Controls.Add(lbl);
        }

        // ================== 메시지 한 줄 추가 ==================
        private void AddMessage(DateTime when, string senderId, string msg)
        {
            bool isMine = senderId == Program.CurrentUserId;

            // 날짜가 바뀌면 헤더 추가
            if (lastDate.Date != when.Date)
            {
                AddDateHeader(when);
                lastDate = when.Date;
            }

            var item = new MessageItem(msg, when, isMine);
            item.ItemClicked += MessageItem_Clicked;

            // 현재 폭 기준으로 말풍선 최대폭 맞추기
            int w = flowMessages.ClientSize.Width;
            if (w <= 0) w = flowMessages.Width;
            item.UpdateContainerWidth(w - 10);

            flowMessages.Controls.Add(item);
            flowMessages.ScrollControlIntoView(item);
        }

        // ================== 말풍선 클릭(선택) ==================
        private void MessageItem_Clicked(object sender, EventArgs e)
        {
            if (_selectedMessage != null)
                _selectedMessage.Selected = false;

            _selectedMessage = (MessageItem)sender;
            _selectedMessage.Selected = true;
        }

        // ================== 히스토리를 문자열에서 세팅 (DML) ==================
        // history 형식 예: "2025-12-05 13:20|user1|안녕\n2025-12-05 13:21|me|ㅎㅇ\n..."
        public void SetHistory(string history)
        {
            flowMessages.Controls.Clear();
            lastDate = DateTime.MinValue;
            _selectedMessage = null;
            _lastSearchKeyword = "";
            _lastSearchIndex = -1;

            if (string.IsNullOrEmpty(history))
                return;

            string[] lines = history.Split('\n');

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length < 3) continue;

                if (!DateTime.TryParseExact(
                        parts[0],
                        "yyyy-MM-dd HH:mm",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime when))
                {
                    when = DateTime.Now;
                }

                string sender = parts[1];
                string msg = parts[2];

                AddMessage(when, sender, msg);
            }
        }

        // ================== DMG 로 실시간 수신 ==================
        public void AppendMessage(string senderId, string msg)
        {
            AddMessage(DateTime.Now, senderId, msg);
        }

        // ================== DMR 삭제 반영 ==================
        public void MarkMessageDeleted(string msgText)
        {
            foreach (Control c in flowMessages.Controls)
            {
                if (c is MessageItem item)
                {
                    if (item.OriginalText == msgText)
                    {
                        item.ShowDeleted();
                        break;
                    }
                }
            }
        }

        // ================== 전송 공통 로직 ==================
        private void SendCurrent()
        {
            string msg = txtInput.Text.Trim();
            if (msg == "") return;

            // 서버로 전송
            Program.SendPacket("DMG", TargetId + " " + msg);

            // 내 화면에 먼저 표시
            AppendMessage(Program.CurrentUserId, msg);

            txtInput.Clear();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendCurrent();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendCurrent();
            }
        }

        // ================== 검색 (같은 키워드로 다음 결과 찾기) ==================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text.Trim();
            if (key == "") return;

            // 1) 화면의 모든 MessageItem 중에서 키워드를 포함하는 것들 찾기
            var matches = new List<MessageItem>();

            foreach (Control c in flowMessages.Controls)
            {
                if (c is MessageItem item)
                {
                    if (!string.IsNullOrEmpty(item.OriginalText) &&
                        item.OriginalText.Contains(key))
                    {
                        matches.Add(item);
                    }
                }
            }

            if (matches.Count == 0)
            {
                MessageBox.Show("검색 결과가 없습니다.");
                return;
            }

            // 2) 새로운 키워드면 처음부터
            if (_lastSearchKeyword != key)
            {
                _lastSearchKeyword = key;
                _lastSearchIndex = 0;
            }
            else
            {
                // 같은 키워드면 다음 결과로
                _lastSearchIndex++;
                if (_lastSearchIndex >= matches.Count)
                    _lastSearchIndex = 0;   // 끝까지 가면 다시 처음으로
            }

            // 3) 선택 표시 갱신
            if (_selectedMessage != null)
                _selectedMessage.Selected = false;

            _selectedMessage = matches[_lastSearchIndex];
            _selectedMessage.Selected = true;

            flowMessages.ScrollControlIntoView(_selectedMessage);

            // (옵션) 타이틀에 몇 번째 결과인지 표시
            this.Text = $"1:1 채팅 - {DisplayName} (검색: {key} {_lastSearchIndex + 1}/{matches.Count})";
        }

        // ================== 선택 삭제 버튼(DMD 요청) ==================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedMessage == null)
            {
                MessageBox.Show("삭제할 메시지를 선택하세요.");
                return;
            }

            if (!_selectedMessage.IsMine)
            {
                MessageBox.Show("내가 보낸 메시지만 삭제할 수 있습니다.");
                return;
            }

            string msg = _selectedMessage.OriginalText;
            string payload = TargetId + "|" + msg;

            // 서버에 삭제 요청
            Program.SendPacket("DMD", payload);
        }

        // ================== 폼 리사이즈 시 말풍선 폭 조정 ==================
        private void DirectChatForm_Resize(object sender, EventArgs e)
        {
            AdjustMessageItemWidths();
        }

        private void AdjustMessageItemWidths()
        {
            int w = flowMessages.ClientSize.Width;
            if (w <= 0) w = flowMessages.Width;
            int widthForItem = w - 10;

            foreach (Control c in flowMessages.Controls)
            {
                if (c is MessageItem item)
                {
                    item.UpdateContainerWidth(widthForItem);
                }
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
            Color formBg = Color.FromArgb(57, 58, 65);
            Color panelBg = Color.FromArgb(30, 31, 34);
            Color inputBg = Color.FromArgb(64, 64, 64);
            Color textCol = Color.White;
            Color accent = Color.FromArgb(88, 101, 242);

            // 폼 전체
            this.BackColor = formBg;
            this.ForeColor = textCol;

            // 메시지 영역
            if (flowMessages != null)
                flowMessages.BackColor = panelBg;

            // 입력창
            if (txtInput != null)
            {
                txtInput.BackColor = inputBg;
                txtInput.ForeColor = textCol;
                txtInput.BorderStyle = BorderStyle.FixedSingle;
            }

            // 검색창
            if (txtSearch != null)
            {
                txtSearch.BackColor = inputBg;
                txtSearch.ForeColor = textCol;
                txtSearch.BorderStyle = BorderStyle.FixedSingle;
            }

            // 버튼들: 전송 / 검색 / 삭제
            var buttons = new List<Button>();
            if (btnSend != null) buttons.Add(btnSend);
            if (btnSearch != null) buttons.Add(btnSearch);
            if (btnDelete != null) buttons.Add(btnDelete);

            btnNoticeAdd.ForeColor = Color.Black;
            btnNoticeRemove.ForeColor = Color.Black;

            foreach (var b in buttons)
            {
                b.BackColor = accent;
                b.ForeColor = Color.White;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            }
        }

        // ================== 화이트(기본) 테마 적용 ==================
        private void ApplyWhiteTheme()
        {
            // 폼 전체 기본
            this.BackColor = SystemColors.Control;
            this.ForeColor = Color.Black;

            // 예전처럼 연한 노랑 배경
            if (flowMessages != null)
                flowMessages.BackColor = Color.LightYellow;

            // 입력창
            if (txtInput != null)
            {
                txtInput.BackColor = Color.White;
                txtInput.ForeColor = Color.Black;
                txtInput.BorderStyle = BorderStyle.FixedSingle;
            }

            // 검색창
            if (txtSearch != null)
            {
                txtSearch.BackColor = Color.White;
                txtSearch.ForeColor = Color.Black;
                txtSearch.BorderStyle = BorderStyle.FixedSingle;
            }

            // 버튼들: 시스템 기본 스타일
            var buttons = new List<Button>();
            if (btnSend != null) buttons.Add(btnSend);
            if (btnSearch != null) buttons.Add(btnSearch);
            if (btnDelete != null) buttons.Add(btnDelete);

            foreach (var b in buttons)
            {
                b.BackColor = SystemColors.Control;
                b.ForeColor = Color.Black;
                b.FlatStyle = FlatStyle.Standard;
            }
        }

        // ================== 공지사항 전체 세팅 (DNL 응답) ==================
        // data 형식: "partnerId\nnoticeId|ownerId|content\nnoticeId|ownerId|content\n..."
        public void SetNoticeList(string data)
        {
            _noticeItems.Clear();
            cboNotice.Items.Clear();

            if (string.IsNullOrEmpty(data))
                return;

            string[] lines = data.Split('\n');
            if (lines.Length <= 1) return;

            // lines[0] = partnerId
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length < 3) continue;

                if (!int.TryParse(parts[0], out int noticeId)) continue;
                string owner = parts[1];
                string content = parts[2];

                var item = new NoticeItem
                {
                    NoticeId = noticeId,
                    OwnerId = owner,
                    Content = content
                };

                _noticeItems.Add(item);
                cboNotice.Items.Add(item);
            }
        }

        // ================== 새 공지 추가 (DNN 수신) ==================
        // data 파싱은 Program.HandleFromServer 에서 하고, 여기엔 값만 넘겨줌
        public void AddNoticeFromServer(int noticeId, string ownerId, string content)
        {
            var item = new NoticeItem
            {
                NoticeId = noticeId,
                OwnerId = ownerId,
                Content = content
            };

            _noticeItems.Add(item);
            cboNotice.Items.Add(item);
        }

        // ================== 공지 삭제 반영 (DNR 수신) ==================
        public void RemoveNoticeFromServer(int noticeId)
        {
            NoticeItem target = null;

            foreach (var n in _noticeItems)
            {
                if (n.NoticeId == noticeId)
                {
                    target = n;
                    break;
                }
            }

            if (target != null)
            {
                _noticeItems.Remove(target);
                cboNotice.Items.Remove(target);
            }
        }

        // ================== 공지 추가 버튼 ==================
        private void btnNoticeAdd_Click(object sender, EventArgs e)
        {
            if (_selectedMessage == null)
            {
                MessageBox.Show("공지로 등록할 메시지를 먼저 선택하세요.");
                return;
            }

            string content = _selectedMessage.OriginalText;
            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("내용이 비어 있는 메시지는 공지로 등록할 수 없습니다.");
                return;
            }

            // 여기서 콤보박스에 직접 추가X → 서버에만 요청
            string payload = TargetId + "|" + content;
            Program.SendPacket("DNA", payload);
        }

        // ================== 공지 삭제 버튼 ==================
        private void btnNoticeRemove_Click(object sender, EventArgs e)
        {
            var item = cboNotice.SelectedItem as NoticeItem;
            if (item == null)
            {
                MessageBox.Show("삭제할 공지사항을 선택하세요.");
                return;
            }

            if (item.OwnerId != Program.CurrentUserId)
            {
                MessageBox.Show("해당 공지사항을 등록한 사람만 삭제할 수 있습니다.");
                return;
            }

            string payload = TargetId + "|" + item.NoticeId.ToString();
            Program.SendPacket("DND", payload);
        }
    }
}