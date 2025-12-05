using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MySql.Data.MySqlClient;

namespace dbp_Server
{
    internal class Program
    {
        // ★ 네 환경에 맞게 수정할 것!
        public const string ConnectionString =
            "Server=223.130.151.111;Port=3306;Database=s5701514;Uid=s5701514;Pwd=s5701514;";

        private static Socket _listener;

        // 현재 접속 중인 클라이언트 목록 (UserId -> Handler)
        private static readonly Dictionary<string, ClientHandler> Clients =
            new Dictionary<string, ClientHandler>();

        private static readonly object ClientsLock = new object();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _listener.Bind(new IPEndPoint(IPAddress.Any, 9999));
                _listener.Listen(100);

                Console.WriteLine("=== Chat Server Started (port 9999) ===");
            }
            catch (SocketException ex)
            {
                Console.WriteLine("서버 시작 실패: " + ex.Message);
                Console.WriteLine("포트 9999 사용 여부를 확인하세요.");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                try
                {
                    Socket sock = _listener.Accept();
                    Console.WriteLine("[접속] 새 클라이언트 연결됨.");

                    ClientHandler handler = new ClientHandler(sock);
                    var t = new System.Threading.Thread(handler.Run);
                    t.IsBackground = true;
                    t.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Accept 예외: " + ex.Message);
                }
            }
        }

        // ======================= 클라이언트 등록/관리 =======================

        internal static void RegisterClientId(string userId, ClientHandler handler)
        {
            lock (ClientsLock)
            {
                Clients[userId] = handler;
            }
            handler.UserId = userId;
            Console.WriteLine($"[HEL] 클라이언트 등록: {userId}");
        }

        internal static void UnregisterClient(ClientHandler handler)
        {
            lock (ClientsLock)
            {
                if (!string.IsNullOrEmpty(handler.UserId))
                {
                    if (Clients.ContainsKey(handler.UserId))
                    {
                        Clients.Remove(handler.UserId);
                        Console.WriteLine($"[BYE] 클라이언트 제거: {handler.UserId}");
                    }
                }
            }
        }

        internal static ClientHandler FindClient(string userId)
        {
            lock (ClientsLock)
            {
                Clients.TryGetValue(userId, out var h);
                return h;
            }
        }

        // ======================= 권한 체크 (ChatUserPermission) =======================

        /// <summary>
        /// ChatUserPermission 테이블에서 (sender -> receiver) 권한 확인.
        /// - row 없으면 기본적으로 허용(true)
        /// - Permission = 1 이면 허용, 0 이면 차단
        /// </summary>
        internal static bool CanChat(string sender, string receiver)
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql =
                    @"SELECT Permission
                      FROM ChatUserPermission
                      WHERE Send = @s AND Receive = @r
                      LIMIT 1";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@s", sender);
                        cmd.Parameters.AddWithValue("@r", receiver);

                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            // 권한 정보가 없으면 기본 허용
                            return true;
                        }

                        return Convert.ToInt32(result) == 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[CanChat] DB 예외: " + ex.Message);
                // DB 에러 시에는 일단 허용으로 둠(원하는 대로 바꿔도 됨)
                return true;
            }
        }

        // ======================= 1) 전체 유저 목록 (USR → USL) =======================

        /// <summary>
        /// ChatUserDetail_test 에서 부서/닉네임/ID 가져와서
        /// "부서|닉네임(ID)|ID\n" 형식으로 반환
        /// </summary>
        internal static string BuildUserList()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql =
                    @"SELECT department, NickName, ID
                      FROM ChatUserDetail_test
                      ORDER BY department, NickName";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            string dept = rd.GetString("department");
                            string nick = rd.GetString("NickName");
                            string id = rd.GetString("ID");

                            sb.Append(dept).Append("|")
                              .Append($"{nick}({id})").Append("|")
                              .Append(id).Append("\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[BuildUserList] DB 예외: " + ex.Message);
            }

            return sb.ToString();
        }

        // ======================= 2) 즐겨찾기 (FGL/FAV/FRE → FLL) =======================

        internal static string GetFavoriteList(string owner)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql =
                    @"SELECT f.TargetId,
                             CONCAT(u.NickName,'(',u.ID,')') AS DisplayName
                      FROM FavoriteContact f
                      JOIN ChatUserDetail_test u ON f.TargetId = u.ID
                      WHERE f.OwnerId = @o";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@o", owner);

                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                string tid = rd.GetString("TargetId");
                                string disp = rd.GetString("DisplayName");

                                sb.Append(tid).Append("|").Append(disp).Append("\n");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[GetFavoriteList] DB 예외: " + ex.Message);
            }

            return sb.ToString();
        }

        internal static void AddFavorite(string owner, string target)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql =
                    @"INSERT IGNORE INTO FavoriteContact(OwnerId, TargetId)
                      VALUES(@o, @t)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@o", owner);
                        cmd.Parameters.AddWithValue("@t", target);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[AddFavorite] DB 예외: " + ex.Message);
            }
        }

        internal static void RemoveFavorite(string owner, string target)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql =
                    @"DELETE FROM FavoriteContact
                      WHERE OwnerId=@o AND TargetId=@t";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@o", owner);
                        cmd.Parameters.AddWithValue("@t", target);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[RemoveFavorite] DB 예외: " + ex.Message);
            }
        }

        // ======================= 3) DM 저장 + 전송 (DMG) =======================

        internal static void HandleDirectMessage(string senderId, string data)
        {
            int idx = data.IndexOf(' ');
            if (idx <= 0) return;

            string receiverId = data.Substring(0, idx);
            string msg = data.Substring(idx + 1);

            // ★ 권한 체크
            if (!CanChat(senderId, receiverId))
            {
                Console.WriteLine($"[권한차단] {senderId} -> {receiverId} : {msg}");

                string sysMsg = "[시스템] 상대방과 채팅할 권한이 없습니다.";
                string payload = senderId + " " + sysMsg;
                string packet = "DMG" + payload.Length + " " + payload;

                FindClient(senderId)?.Send(packet);
                return;
            }

            // DB 저장 (isErased = 0)
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql =
                    @"INSERT INTO DirectMessage
                      (SenderId, ReceiverId, Content, SendTime, isErased)
                      VALUES(@s, @r, @c, NOW(), 0)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@s", senderId);
                        cmd.Parameters.AddWithValue("@r", receiverId);
                        cmd.Parameters.AddWithValue("@c", msg);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[HandleDirectMessage] DB 예외: " + ex.Message);
                return;
            }

            // 두 클라이언트에 DMG 패킷 전송
            string payload2 = senderId + " " + msg;
            string packet2 = "DMG" + payload2.Length + " " + payload2;

            FindClient(senderId)?.Send(packet2);
            FindClient(receiverId)?.Send(packet2);
        }

        // ======================= 4) DM 히스토리 (DMH → DML) =======================

        internal static void SendHistory(ClientHandler requester, string partnerId)
        {
            string myId = requester.UserId;

            // 권한 체크
            if (!CanChat(myId, partnerId))
            {
                Console.WriteLine($"[히스토리권한차단] {myId} <-> {partnerId}");

                DateTime now = DateTime.Now;
                string time = now.ToString("yyyy-MM-dd HH:mm");
                string msg = "권한이 없어 이 대화를 열 수 없습니다.";

                string body = partnerId + "\n" +
                              time + "|" + myId + "|" + msg + "\n";

                string packet = "DML" + body.Length + " " + body;
                requester.Send(packet);
                return;
            }

            StringBuilder sb = new StringBuilder();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql =
                    @"SELECT SenderId, Content, SendTime, isErased
                      FROM DirectMessage
                      WHERE (SenderId=@me AND ReceiverId=@t)
                         OR (SenderId=@t AND ReceiverId=@me)
                      ORDER BY SendTime";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@me", myId);
                        cmd.Parameters.AddWithValue("@t", partnerId);

                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                string sid = rd.GetString("SenderId");
                                DateTime t = rd.GetDateTime("SendTime");

                                string msg = rd.GetInt32("isErased") == 1
                                    ? "삭제된 메시지입니다"
                                    : rd.GetString("Content");

                                string time = t.ToString("yyyy-MM-dd HH:mm");

                                sb.Append(time).Append("|")
                                  .Append(sid).Append("|")
                                  .Append(msg).Append("\n");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[SendHistory] DB 예외: " + ex.Message);
            }

            string body2 = partnerId + "\n" + sb.ToString();
            string packet2 = "DML" + body2.Length + " " + body2;

            requester.Send(packet2);
        }

        // ======================= 5) 메시지 삭제 (DMD → DMR) =======================

        internal static void EraseDirectMessage(string requesterId, string data)
        {
            string[] parts = data.Split('|');
            if (parts.Length < 2) return;

            string partnerId = parts[0];
            string content = parts[1];
            int changed = 0;

            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql =
                    @"UPDATE DirectMessage
                      SET isErased = 1
                      WHERE SenderId=@s AND ReceiverId=@r
                        AND Content=@c AND isErased = 0
                      ORDER BY SendTime DESC
                      LIMIT 1";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@s", requesterId);
                        cmd.Parameters.AddWithValue("@r", partnerId);
                        cmd.Parameters.AddWithValue("@c", content);

                        changed = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[EraseDirectMessage] DB 예외: " + ex.Message);
            }

            if (changed <= 0) return;

            string reqData = partnerId + "|" + content;
            string reqPacket = "DMR" + reqData.Length + " " + reqData;
            FindClient(requesterId)?.Send(reqPacket);

            string parData = requesterId + "|" + content;
            string parPacket = "DMR" + parData.Length + " " + parData;
            FindClient(partnerId)?.Send(parPacket);
        }

        // ======================= 6) 공지사항(DirectNotice) 처리 =======================

        private static string GetChatKey(string user1, string user2)
        {
            return (string.CompareOrdinal(user1, user2) < 0)
                ? user1 + "|" + user2
                : user2 + "|" + user1;
        }

        /// <summary>
        /// DNA: 공지 추가 요청
        /// data = "상대ID|메시지내용"
        /// </summary>
        public static void HandleNoticeAdd(string senderId, string data)
        {
            int sp = data.IndexOf('|');
            if (sp <= 0) return;

            string partnerId = data.Substring(0, sp);   // 보내는 사람이 생각하는 "상대 ID"
            string content = data.Substring(sp + 1);

            string chatKey = GetChatKey(senderId, partnerId);
            int newId = 0;

            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(
                        "INSERT INTO DirectNotice(ChatKey, OwnerId, Content, CreatedAt, IsDeleted) " +
                        "VALUES(@ck, @owner, @content, NOW(), 0); SELECT LAST_INSERT_ID();",
                        conn))
                    {
                        cmd.Parameters.AddWithValue("@ck", chatKey);
                        cmd.Parameters.AddWithValue("@owner", senderId);
                        cmd.Parameters.AddWithValue("@content", content);
                        newId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[HandleNoticeAdd] DB 예외: " + ex.Message);
                return;
            }

            // 기존에는 한 payload 를 양쪽에 똑같이 보냈는데
            //     → 받는 쪽 입장에서 partnerId 가 자기 자신이 되어버려서 폼 키가 꼬였음
            // 수정: 각 클라이언트 입장에서 "상대 ID"가 되도록 따로 구성

            // 1) 공지 올린 사람에게 보내는 payload (partnerId = 상대 ID)
            string bodySender = $"{partnerId}|{newId}|{senderId}|{content}";
            string packetSender = "DNN" + bodySender.Length + " " + bodySender;
            FindClient(senderId)?.Send(packetSender);

            // 2) 상대방에게 보내는 payload (partnerId = 공지 올린 사람 ID)
            string bodyReceiver = $"{senderId}|{newId}|{senderId}|{content}";
            string packetReceiver = "DNN" + bodyReceiver.Length + " " + bodyReceiver;
            FindClient(partnerId)?.Send(packetReceiver);
        }


        /// <summary>
        /// DND: 공지 삭제 요청
        /// data = "상대ID|noticeId"
        /// </summary>
        public static void HandleNoticeDelete(string senderId, string data)
        {
            int sp = data.IndexOf('|');
            if (sp <= 0) return;

            string partnerId = data.Substring(0, sp);   // 보내는 사람이 생각하는 "상대 ID"
            if (!int.TryParse(data.Substring(sp + 1), out int noticeId))
                return;

            string ownerId = null;

            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(
                        "SELECT OwnerId FROM DirectNotice WHERE Id=@id AND IsDeleted=0",
                        conn))
                    {
                        cmd.Parameters.AddWithValue("@id", noticeId);
                        object o = cmd.ExecuteScalar();
                        if (o == null) return;
                        ownerId = (string)o;
                    }

                    // 올린 사람만 삭제 가능
                    if (ownerId != senderId)
                        return;

                    using (var cmd = new MySqlCommand(
                        "UPDATE DirectNotice SET IsDeleted=1 WHERE Id=@id",
                        conn))
                    {
                        cmd.Parameters.AddWithValue("@id", noticeId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[HandleNoticeDelete] DB 예외: " + ex.Message);
                return;
            }

            // 기존: payload 하나를 양쪽에 똑같이 {"partnerId|noticeId"} 로 보냄
            // 수정: 각 클라이언트 입장 기준으로 partnerId 를 "상대 ID" 로 맞춰서 전송

            // 1) 삭제 요청한 사람에게 보내는 payload (partnerId = 상대 ID)
            string bodySender = $"{partnerId}|{noticeId}";
            string packetSender = "DNR" + bodySender.Length + " " + bodySender;
            FindClient(senderId)?.Send(packetSender);

            // 2) 상대방에게 보내는 payload (partnerId = 삭제한 사람 ID)
            string bodyReceiver = $"{senderId}|{noticeId}";
            string packetReceiver = "DNR" + bodyReceiver.Length + " " + bodyReceiver;
            FindClient(partnerId)?.Send(packetReceiver);
        }


        /// <summary>
        /// DNL: 공지 목록 요청
        /// data = "상대ID"
        /// 응답 body 형식:
        ///   partnerId\n
        ///   noticeId|ownerId|content\n...
        /// </summary>
        public static void SendNoticeList(ClientHandler client, string partnerId)
        {
            string senderId = client.UserId;
            string chatKey = GetChatKey(senderId, partnerId);

            var sb = new StringBuilder();
            sb.Append(partnerId).Append('\n');

            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(
                        "SELECT Id, OwnerId, Content " +
                        "FROM DirectNotice " +
                        "WHERE ChatKey=@ck AND IsDeleted=0 " +
                        "ORDER BY CreatedAt",
                        conn))
                    {
                        cmd.Parameters.AddWithValue("@ck", chatKey);

                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                int id = r.GetInt32(0);
                                string owner = r.GetString(1);
                                string text = r.GetString(2);

                                sb.Append(id).Append('|')
                                  .Append(owner).Append('|')
                                  .Append(text).Append('\n');
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[SendNoticeList] DB 예외: " + ex.Message);
            }

            string body = sb.ToString();
            string packet = "DNL" + body.Length + " " + body;
            client.Send(packet);
        }
    }
}