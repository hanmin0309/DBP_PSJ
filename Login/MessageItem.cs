using System;
using System.Drawing;
using System.Windows.Forms;

namespace Login
{
    /// <summary>
    /// 한 줄 채팅 메시지를 표현하는 컨트롤
    /// - FlowLayoutPanel 안에 들어감
    /// - bubble(흰 박스) 안에 텍스트 + 시간
    /// - 상대: 왼쪽 정렬, 나: 오른쪽 정렬
    /// - 클릭 시 선택(배경 파란색) / 삭제에 사용
    /// </summary>
    public class MessageItem : Panel
    {
        private Panel bubble;      // 실제 흰색 박스
        private Label lblText;     // 메시지 텍스트
        private Label lblTime;     // 시간

        public string OriginalText { get; }
        public bool IsMine { get; }

        public event EventHandler ItemClicked;

        private bool _selected;
        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                if (bubble != null)
                    bubble.BackColor = value ? Color.LightBlue : Color.White;
            }
        }

        public MessageItem(string text, DateTime when, bool isMine)
        {
            OriginalText = text;
            IsMine = isMine;

            // 이 패널은 FlowLayoutPanel 안에서 "한 줄" 컨테이너처럼 사용됨
            AutoSize = false;
            Width = 400;                      // 초기값, 나중에 UpdateContainerWidth로 조정
            Height = 10;
            BackColor = Color.Transparent;
            Margin = new Padding(0, 5, 0, 5);
            Padding = new Padding(0);

            // =============== 말풍선 박스(bubble) ===============
            bubble = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = Color.White,
                Padding = new Padding(8),
                Margin = Padding.Empty
            };

            // =============== 텍스트 라벨 ===============
            lblText = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(260, 0),      // 기본 최대 폭
                Text = text,
                Font = new Font("맑은 고딕", 10f),
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };

            // =============== 시간 라벨 (텍스트 아래) ===============
            lblTime = new Label
            {
                AutoSize = true,
                Text = when.ToString("tt h:mm"),
                Font = new Font("맑은 고딕", 8f),
                ForeColor = Color.Gray,
                BackColor = Color.Transparent
            };

            bubble.Controls.Add(lblText);
            bubble.Controls.Add(lblTime);
            Controls.Add(bubble);

            // bubble 내부 레이아웃 (텍스트 위, 시간 아래)
            bubble.Layout += Bubble_Layout;

            // 클릭 시 선택 이벤트 전달
            this.Click += (s, e) => ItemClicked?.Invoke(this, EventArgs.Empty);
            bubble.Click += (s, e) => ItemClicked?.Invoke(this, EventArgs.Empty);
            lblText.Click += (s, e) => ItemClicked?.Invoke(this, EventArgs.Empty);
            lblTime.Click += (s, e) => ItemClicked?.Invoke(this, EventArgs.Empty);

            Selected = false;
        }

        /// <summary>
        /// FlowLayoutPanel 폭이 바뀔 때 호출해서 이 줄의 가로폭을 맞춰줌
        /// </summary>
        public void UpdateContainerWidth(int width)
        {
            if (width <= 0) return;

            Width = width;

            // bubble 안에서 텍스트 줄바꿈 최대폭도 같이 조정
            int textMax = width - 80;            // 좌우 여백 감안
            if (textMax < 80) textMax = 80;
            lblText.MaximumSize = new Size(textMax, 0);

            PerformLayout();
        }

        /// <summary>
        /// bubble 내부에서 텍스트 위, 시간 아래로 배치
        /// </summary>
        private void Bubble_Layout(object sender, LayoutEventArgs e)
        {
            if (lblText == null || lblTime == null) return;

            lblText.Location = new Point(0, 0);
            lblTime.Location = new Point(0, lblText.Bottom + 2);

            bubble.Height = lblTime.Bottom + 4;
        }

        /// <summary>
        /// 이 한 줄(컨테이너) 안에서 bubble을 왼쪽/오른쪽 정렬
        /// </summary>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            if (bubble == null) return;

            // bubble 내부 먼저 레이아웃
            bubble.PerformLayout();

            // 🔸 정렬 기준 폭: 내 Width가 아니라 부모(FlowLayoutPanel)의 클라이언트 폭 기준
            int containerWidth;

            if (Parent != null)
                containerWidth = Parent.ClientSize.Width;
            else
                containerWidth = this.Width;

            if (containerWidth <= 0)
                containerWidth = this.Width;

            // 한 줄 컨트롤의 Width도 부모 폭에 맞춰 통일
            this.Width = containerWidth;

            int bubbleWidth = bubble.Width;
            int x;

            if (IsMine)
            {
                // 오른쪽 정렬: 우측에서 10px 여백
                x = containerWidth - bubbleWidth - 10;
                if (x < 10) x = 10;    // 혹시 너무 좁아지면 최소 10
            }
            else
            {
                // 왼쪽 정렬
                x = 10;
            }

            bubble.Location = new Point(x, 2);
            Height = bubble.Bottom + 4;
        }

        /// <summary>
        /// 삭제된 메시지 표시로 변경
        /// </summary>
        public void ShowDeleted()
        {
            lblText.Text = "삭제된 메시지입니다";
            lblText.ForeColor = Color.Gray;
        }
    }
}