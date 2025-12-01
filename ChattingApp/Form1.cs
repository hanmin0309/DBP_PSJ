using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ChattingApp
{
    public partial class Form1 : Form
    {
        private string lastMessageDate = "";
        private readonly string myName;

        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private Thread recvThread;

        private int nextBubbleTop = 5;

        public Form1(string userName)
        {
            InitializeComponent();
            myName = userName;
            Text = $"채팅창 ({myName})";
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 9000);
                var ns = client.GetStream();
                reader = new StreamReader(ns);
                writer = new StreamWriter(ns) { AutoFlush = true };

                recvThread = new Thread(ReceiveLoop);
                recvThread.IsBackground = true;
                recvThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버 접속 실패: " + ex.Message);
            }
        }

        private void ReceiveLoop()
        {
            try
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null) break;

                    string[] parts = line.Split('|');
                    if (parts.Length < 2) continue;

                    string sender = parts[0];
                    string msg = parts[1];
                    bool isMine = (sender == myName);

                    AddMessageBubble(msg, isMine);
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = textBox1.Text.Trim();
            if (msg.Length == 0) return;

            try
            {
                writer.WriteLine($"{myName}|{msg}");
                textBox1.Clear();
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("전송 실패: " + ex.Message);
            }
        }

        private void AddMessageBubble(string message, bool isMine)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string, bool>(AddMessageBubble), message, isMine);
                return;
            }

            int margin = 8;

            // 📌 날짜 구분선 표시
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            if (today != lastMessageDate)
            {
                lastMessageDate = today;
                Label dateLabel = new Label();
                dateLabel.AutoSize = true;
                dateLabel.Font = new Font("맑은 고딕", 9, FontStyle.Bold);
                dateLabel.ForeColor = Color.Gray;
                dateLabel.Text = $"—  {today}  —";
                dateLabel.Location = new Point((chatPanel.Width - dateLabel.PreferredWidth) / 2, nextBubbleTop);
                chatPanel.Controls.Add(dateLabel);

                nextBubbleTop += dateLabel.Height + 10;
            }

            // 📌 KakaoBubble 컨트롤 생성
            KakaoBubble bubble = new KakaoBubble(message, isMine);
            chatPanel.Controls.Add(bubble);

            bubble.PerformLayout();

            // 📌 말풍선 위치 계산
            int xBubble = isMine
                ? chatPanel.ClientSize.Width - bubble.Width - margin
                : margin;

            bubble.Location = new Point(xBubble, nextBubbleTop);

            // 📌 시간 라벨
            Label timeLabel = new Label();
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("맑은 고딕", 8);
            timeLabel.ForeColor = Color.Gray;
            timeLabel.Text = DateTime.Now.ToString("tt h:mm"); // 오후 6:35
            chatPanel.Controls.Add(timeLabel);

            // 🔥 시간 좌표
            int xTime = isMine
                ? xBubble - timeLabel.PreferredWidth - 4           // 내가 보낸 → 말풍선 왼쪽
                : xBubble + bubble.Width + 4;                      // 상대 → 말풍선 오른쪽

            int yTime = nextBubbleTop + bubble.Height - 16;
            timeLabel.Location = new Point(xTime, yTime);

            // 다음 말풍선 위치 증가
            nextBubbleTop += Math.Max(bubble.Height, timeLabel.Height) + 10;

            // 스크롤
            chatPanel.ScrollControlIntoView(bubble);
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try { recvThread?.Abort(); } catch { }
            try { reader?.Close(); } catch { }
            try { writer?.Close(); } catch { }
            try { client?.Close(); } catch { }
            base.OnFormClosing(e);
        }
    }
}
