using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Login
{
    internal static class Program
    {
        // 채팅 서버와 연결되는 소켓
        public static Socket ChatSocket;

        // 현재 로그인한 사용자 ID (UserInformation.Identity 등)
        public static string CurrentUserId;

        // 로그인 시 가져온 유저 정보(DataTable) 그대로 저장하고 싶으면 사용
        public static DataTable CurrentUserTable;

        // 메인 폼(대화상대/채팅방 관리)
        public static ContactMainForm ContactMain;

        // 1:1 채팅창 목록 (상대ID -> DirectChatForm)
        public static Dictionary<string, DirectChatForm> DirectChats =
            new Dictionary<string, DirectChatForm>();

        public static bool IsDarkTheme = true;   // 기본: 다크 모드


        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 엔트리 포인트는 login 폼 (login.cs는 수정 금지)
            // login.cs 안에서 로그인 성공 시:
            //   table = Login(userId, userPw);
            //   ContactMainForm main = new ContactMainForm(table);
            //   main.Show();
            //   this.Hide();
            Application.Run(new login());
        }

        /// <summary>
        /// 로그인 성공 후 ContactMainForm에서 호출.
        /// 서버에 연결하고 헬로/유저목록/즐겨찾기 요청, 수신 스레드 시작.
        /// </summary>
        public static void StartChat()
        {
            // 이미 연결된 상태면 다시 연결하지 않음
            if (ChatSocket != null)
                return;

            if (string.IsNullOrEmpty(CurrentUserId))
            {
                MessageBox.Show("현재 로그인한 사용자 ID가 설정되지 않았습니다.");
                return;
            }

            try
            {
                ChatSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ChatSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
            }
            catch (SocketException ex)
            {
                ChatSocket = null;
                MessageBox.Show(
                    "채팅 서버(127.0.0.1:9999)에 연결할 수 없습니다.\n\n" +
                    "- 서버 프로그램이 실행 중인지\n" +
                    "- 포트 번호(9999)가 서버와 같은지\n\n" +
                    "를 확인한 뒤 다시 실행해 주세요.\n\n" +
                    "자세한 오류: " + ex.Message,
                    "서버 연결 실패",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // 내 ID를 서버에 알림
            SendPacket("HEL", CurrentUserId);

            // 전체 유저 목록 요청
            SendPacket("USR", "");

            // 즐겨찾기 목록 요청
            SendPacket("FGL", "");

            // 수신 스레드 시작
            Thread t = new Thread(ReceiveLoop);
            t.IsBackground = true;
            t.Start();
        }

        /// <summary>
        /// 공통 패킷 전송 함수
        /// 형식: "MOD" + data.Length + " " + data
        /// 예: "HEL5 user1"
        /// </summary>
        public static void SendPacket(string mode, string data)
        {
            if (ChatSocket == null) return;
            if (data == null) data = "";

            string packet = mode + data.Length + " " + data;
            byte[] buf = Encoding.Unicode.GetBytes(packet);
            ChatSocket.Send(buf);
        }

        /// <summary>
        /// 서버로부터 오는 데이터를 계속 읽어서 패킷 단위로 분리하고 처리.
        /// </summary>
        private static void ReceiveLoop()
        {
            byte[] buf = new byte[4096];

            try
            {
                while (true)
                {
                    int len = ChatSocket.Receive(buf);
                    if (len <= 0) continue;

                    string s = Encoding.Unicode.GetString(buf, 0, len).Trim('\0');

                    // 한 번에 여러 패킷이 붙어서 올 수 있으므로 반복 파싱
                    while (s.Length >= 4)
                    {
                        string mode = s.Substring(0, 3);
                        int sp = s.IndexOf(' ');
                        if (sp < 0) break;

                        string lenStr = s.Substring(3, sp - 3);
                        if (!int.TryParse(lenStr, out int dataLen)) break;

                        if (sp + 1 + dataLen > s.Length)
                            break;      // 데이터가 덜 온 경우

                        string data = s.Substring(sp + 1, dataLen);
                        string rest = s.Substring(sp + 1 + dataLen);

                        HandleFromServer(mode, data);
                        s = rest;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버와의 연결이 끊어졌습니다.\n" + ex.Message);
            }
        }

        /// <summary>
        /// 서버 → 클라이언트 패킷 모드별 처리
        /// USL: 전체 유저 리스트
        /// FLL: 즐겨찾기 리스트
        /// DMG: 1:1 메시지
        /// DML: 1:1 히스토리
        /// DMR: 메시지 삭제 반영
        /// </summary>
        private static void HandleFromServer(string mode, string data)
        {
            if (ContactMain == null) return;

            if (mode == "USL")   // 전체 유저 리스트
            {
                ContactMain.Invoke(new Action(() =>
                {
                    ContactMain.SetUserTree(data);
                }));
            }
            else if (mode == "FLL")  // 즐겨찾기 리스트
            {
                ContactMain.Invoke(new Action(() =>
                {
                    ContactMain.SetFavoriteList(data);
                }));
            }
            else if (mode == "DMG")  // 1:1 메시지 수신
            {
                // data = "보낸ID 메시지내용"
                int sp = data.IndexOf(' ');
                if (sp <= 0) return;

                string senderId = data.Substring(0, sp);
                string msg = data.Substring(sp + 1);

                // ★ 내가 보낸 메시지는 이미 DirectChatForm에서 AppendMessage 했으므로
                //    서버가 echo로 보내준 DMG는 무시 (채팅창 2개 뜨는 것 방지)
                if (senderId == CurrentUserId)
                    return;

                // 여기서 senderId 는 "상대방"이고, 나는 메시지를 받은 사람
                string partnerId = senderId;

                ContactMain.Invoke(new Action(() =>
                {
                    // 상대ID 기준으로 채팅창 생성/재사용
                    DirectChatForm chat = GetOrCreateDirectChat(partnerId, partnerId);
                    chat.AppendMessage(senderId, msg);
                    chat.Show();
                    chat.Activate();
                    ContactMain.UpdateChatList();
                }));
            }
            else if (mode == "DML")  // 대화 히스토리
            {
                // data = "partnerId\n시간|보낸ID|내용\n..."
                int nl = data.IndexOf('\n');
                if (nl <= 0) return;

                string partnerId = data.Substring(0, nl);
                string history = data.Substring(nl + 1);

                ContactMain.Invoke(new Action(() =>
                {
                    DirectChatForm chat = GetOrCreateDirectChat(partnerId, partnerId);
                    chat.SetHistory(history);
                    chat.Show();
                    chat.Activate();
                    ContactMain.UpdateChatList();
                }));
            }
            else if (mode == "DMR")  // 메시지 삭제 반영
            {
                // data = "상대ID|원본메시지"
                int sp = data.IndexOf('|');
                if (sp <= 0) return;

                string otherId = data.Substring(0, sp);
                string msgText = data.Substring(sp + 1);

                ContactMain.Invoke(new Action(() =>
                {
                    DirectChatForm chat = GetOrCreateDirectChat(otherId, otherId);
                    chat.MarkMessageDeleted(msgText);
                }));
            }
            else if (mode == "DNL")  // 공지 전체 리스트
            {
                // data = "partnerId\nnoticeId|ownerId|content\n..."
                int nl = data.IndexOf('\n');
                if (nl <= 0) return;

                string partnerId = data.Substring(0, nl);

                ContactMain.Invoke(new Action(() =>
                {
                    var chat = GetOrCreateDirectChat(partnerId, partnerId);
                    chat.SetNoticeList(data);   // data 전체 넘겨서 내부에서 파싱
                }));
            }
            else if (mode == "DNN")  // 새 공지 1개 추가
            {
                // data = "partnerId|noticeId|ownerId|content"
                string[] parts = data.Split('|');
                if (parts.Length < 4) return;

                string partnerId = parts[0];
                if (!int.TryParse(parts[1], out int noticeId)) return;
                string ownerId = parts[2];
                string content = parts[3];

                ContactMain.Invoke(new Action(() =>
                {
                    var chat = GetOrCreateDirectChat(partnerId, partnerId);
                    chat.AddNoticeFromServer(noticeId, ownerId, content);
                }));
            }
            else if (mode == "DNR")  // 공지 삭제
            {
                // data = "partnerId|noticeId"
                string[] parts = data.Split('|');
                if (parts.Length < 2) return;

                string partnerId = parts[0];
                if (!int.TryParse(parts[1], out int noticeId)) return;

                ContactMain.Invoke(new Action(() =>
                {
                    var chat = GetOrCreateDirectChat(partnerId, partnerId);
                    chat.RemoveNoticeFromServer(noticeId);
                }));
            }
        }

        /// <summary>
        /// 상대 ID 기준으로 DirectChatForm을 생성하거나 이미 있는 창 재사용.
        /// </summary>
        public static DirectChatForm GetOrCreateDirectChat(string targetId, string displayName)
        {
            if (!DirectChats.TryGetValue(targetId, out DirectChatForm form) ||
                form == null || form.IsDisposed)
            {
                form = new DirectChatForm(targetId, displayName);
                DirectChats[targetId] = form;
            }
            return form;
        }
    }
}