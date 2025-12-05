using System;
using System.Net.Sockets;
using System.Text;

namespace dbp_Server
{
    internal class ClientHandler
    {
        private Socket _socket;
        public string UserId { get; set; }

        public ClientHandler(Socket socket)
        {
            _socket = socket;
        }

        public void Run()
        {
            byte[] buf = new byte[4096];

            try
            {
                while (true)
                {
                    int len = _socket.Receive(buf);
                    if (len <= 0)
                        break;

                    // ★ 클라이언트와 맞추기 위해 Unicode 사용
                    string s = Encoding.Unicode.GetString(buf, 0, len).Trim('\0');

                    // 패킷이 여러 개 붙어서 오는 경우 대비하여 반복 파싱
                    while (true)
                    {
                        if (s.Length < 4) break;

                        int sp = s.IndexOf(' ');
                        if (sp < 0) break;

                        string mode = s.Substring(0, 3);
                        string lenStr = s.Substring(3, sp - 3);

                        if (!int.TryParse(lenStr, out int bodyLen))
                            break;

                        if (sp + 1 + bodyLen > s.Length)
                            break; // 데이터가 덜 왔음 → 다음 Receive에서 처리

                        string body = s.Substring(sp + 1, bodyLen);
                        string rest = s.Substring(sp + 1 + bodyLen);

                        HandlePacket(mode, body);
                        s = rest;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("클라이언트 수신 예외: " + ex.Message);
            }
            finally
            {
                try { _socket.Shutdown(SocketShutdown.Both); } catch { }
                try { _socket.Close(); } catch { }
                Program.UnregisterClient(this);
            }
        }

        private void HandlePacket(string mode, string data)
        {
            switch (mode)
            {
                case "HEL":
                    Program.RegisterClientId(data, this);
                    break;

                case "USR":
                    {
                        string list = Program.BuildUserList();
                        string packet = "USL" + list.Length + " " + list;
                        Send(packet);
                        break;
                    }

                case "FGL":
                    {
                        if (string.IsNullOrEmpty(UserId)) return;
                        string fav = Program.GetFavoriteList(UserId);
                        string packet = "FLL" + fav.Length + " " + fav;
                        Send(packet);
                        break;
                    }

                case "FAV":
                    {
                        if (string.IsNullOrEmpty(UserId)) return;
                        Program.AddFavorite(UserId, data);
                        string fav = Program.GetFavoriteList(UserId);
                        string packet = "FLL" + fav.Length + " " + fav;
                        Send(packet);
                        break;
                    }

                case "FRE":
                    {
                        if (string.IsNullOrEmpty(UserId)) return;
                        Program.RemoveFavorite(UserId, data);
                        string fav = Program.GetFavoriteList(UserId);
                        string packet = "FLL" + fav.Length + " " + fav;
                        Send(packet);
                        break;
                    }

                case "DMG":
                    {
                        if (string.IsNullOrEmpty(UserId)) return;
                        Program.HandleDirectMessage(UserId, data);
                        break;
                    }

                case "DMH":
                    {
                        if (string.IsNullOrEmpty(UserId)) return;
                        Program.SendHistory(this, data);
                        break;
                    }

                case "DMD":
                    {
                        if (string.IsNullOrEmpty(UserId)) return;
                        Program.EraseDirectMessage(UserId, data);
                        break;
                    }
                case "DNA":    // Direct Notice Add (공지 추가)
                    {
                        if (string.IsNullOrEmpty(UserId)) return;
                        Program.HandleNoticeAdd(UserId, data);
                        break;
                    }

                case "DND":    // Direct Notice Delete (공지 삭제)
                    {
                        if (string.IsNullOrEmpty(UserId)) return;
                        Program.HandleNoticeDelete(UserId, data);
                        break;
                    }

                case "DNL":    // Direct Notice List (공지 목록 요청)
                    {
                        if (string.IsNullOrEmpty(UserId)) return;
                        Program.SendNoticeList(this, data);
                        break;
                    }

                default:
                    Console.WriteLine("알 수 없는 패킷 모드: " + mode);
                    break;
            }
        }

        public void Send(string packet)
        {
            try
            {
                // ★ 클라이언트와 맞추기 위해 Unicode 사용
                byte[] b = Encoding.Unicode.GetBytes(packet);
                _socket.Send(b);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Send 예외: " + ex.Message);
            }
        }
    }
}