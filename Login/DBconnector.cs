using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG
{
    public class DBconnector
    {
        private static DBconnector _instance = new DBconnector();
        private string constr;

        public static DBconnector getInstance()
        {
            return _instance;
        }

        private DBconnector()
        {

        }

        /* DB connect */
        public void InitServer(string add, int port, string database, string id, string pwd)
        {
            constr = $"Server = {add}; Port = {port}; Database = {database}; User id = {id}; Password = {pwd}";
        }
        public bool CheckLogin()
        {
            try
            {
                using (var conn = new MySqlConnection(constr))
                {
                    conn.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //

        /* Query */
        public DataTable Query(string query)
        {
            using (var conn = new MySqlConnection(constr))
            {
                conn.Open();

                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                var table = new DataTable();
                table.Load(reader);
                return table;
            }
        }
        // 회원가입 시 기본적으로 모든 사람과 대화 할 수 있도록 설정
        public void SetPermission(string senderID, string receiverID)
        {
            string query = "INSERT INTO ChatUserPermission(Send, Receive, Permission) " +
                $"VALUES (\"{senderID}\", \"{receiverID}\", 1);";

            Query(query);
        }
        // 보기 / 대화 권한 조정 
        public void ChangePermission(string senderID, string receiverID, int per)
        {
            string query = $"UPDATE ChatUserPermission SET Permission = {per} " +
                $"WHERE Send = \"{senderID}\" AND Receive = \"{receiverID}\";";

            Query(query);
        }
        // 부서와 팀 배정
        public void SetDepartmentTeam(string userID, string department, string team)
        {
            string query = $"UPDATE ChatUserList SET Department = \"{department}\", Team = \"{team}\" " +
                $"WHERE ID = \"{userID}\";";

            Query(query);
        }
        // userID를 제외한 사람들의 아이디와 이름을 가져옴
        // userID에 " "가 있으면 모든 아이디와 이름을 가져옴
        public DataTable GetUserID(string userID)
        {
            string query = "SELECT ID, Name " +
                "FROM ChatUserList " +
                $"WHERE ID != \"{userID}\";";

            return Query(query);
        }
        // userID의 부서정보를 가져옴
        public DataTable GetDepartment(string userID)
        {
            string query = "SELECT Department " +
                "FROM ChatUserList " +
                $"WHERE ID = \"{userID}\";";

            return Query(query);
        }
        // userID의 팀 정보를 가져옴
        public DataTable GetTeam(string userID)
        {
            string query = "SELECT Team " +
                "FROM ChatUserList " +
                $"WHERE ID = \"{userID}\";";

            return Query(query);
        }
        // 부서의 이름을 변경함
        public void ChangeDepartment(string department, string where)
        {
            string query = $"UPDATE ChatUserDeparment SET Department = \"{where}\" WHERE Department = \"{department}\";";

            Query(query);
        }
        // 팀의 이름을 변경함
        // ChangeDepartment와 같이 실행되며 여기서도 부서의 이름이 변경되는 과정이 있음
        public void ChangeTeam(string department, string team, string whereD, string whereT)
        {
            string query = $"UPDATE ChatUserTeam SET Department = \"{whereD}, Team = \"{team}\" " +
                $"WHERE Department = \"{department}\" AND Team = \"{team}\";";

            Query(query);
        }
        //

        /* Show Information */
        // 모든 유저 정보를 가져옴
        public DataTable ShowChatUserList()
        {
            string query = "SELECT * " +
                "FROM ChatUserList " +
                "ORDER BY Name;";

            return Query(query);
        }
        // 모든 부서정보를 가져옴
        public DataTable ShowChatUserDepartment()
        {
            string query = "SELECT * " +
                "FROM ChatUserDepartment " +
                "ORDER BY Department;";

            return Query(query);
        }
        // 모든 팀 정보를 가져옴
        public DataTable ShowChatUserTeam(string department)
        {
            string query = "SELECT * " +
                "FROM ChatUserTeam " +
                $"WHERE Department = \"{department}\" " +
                "ORDER BY Team;";

            return Query(query);
        }
        // 유저들의 보기 / 대화 권한을 가져옴
        public DataTable ShowChatUserPermission()
        {
            string query = "SELECT * " +
                "FROM ChatUserPermission " +
                "ORDER BY Send ASC;";

            return Query(query);
        }
        // 유저의 로그인 / 로그아웃 시간을 가져옴
        public DataTable ShowChatUserLog(string id)
        {
            string query = "SELECT * " +
                "FROM UserLog " +
                $"WHERE ID = \"{id}\";";

            return Query(query);
        }
        // 특정 유저들 간의 대화 목록을 가져옴
        public DataTable ShowChatUserDM(string sender, string receiver)
        {
            string query = $"SELECT * " +
                "FROM DirectMessage " +
                $"WHERE SenderID = \"{sender}\" AND ReceiverID = \"{receiver}\";";

            return Query(query);
        }
        // 대화 내용을 키워드 별로 가져옴
        public DataTable ShowChatUserDM(string sender, string receiver, string message)
        {
            string query = $"SELECT * " +
                "FROM DirectMessage " +
                $"WHERE SenderID = \"{sender}\" AND ReceiverID = \"{receiver}\" AND Content LIKE \"%{message}%\";";

            return Query(query);
        }
        // 날짜별로 가져옴
        public DataTable ShowChatUserDM2(string sender, string receiver, string date)
        {
            string query = $"SELECT * " +
                "FROM DirectMessage " +
                $"WHERE SenderID = \"{sender}\" AND ReceiverID = \"{receiver}\" AND SendTime LIKE \"%{date}%\";";

            return Query(query);
        }
        // 날짜 + 키워드
        public DataTable ShowChatUserDM2(string sender, string receiver, string message, string date)
        {
            string query = $"SELECT * " +
                "FROM DirectMessage " +
                $"WHERE SenderID = \"{sender}\" AND ReceiverID = \"{receiver}\" AND Content LIKE \"%{message}%\" AND SendTime LIKE \"%{date}%\";";

            return Query(query);
        }
        //
    }
}
