using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace Login
{
    public static class ProfileOverrideHelper
    {
        /// <summary>
        /// OwnerID(나)와 TargetID(상대)에 대해
        /// ChatUserProfileOverride에 저장된 DisplayName, PicturePath를 가져온다.
        /// 없으면 (null, null) 반환
        /// </summary>
        public static (string displayName, string picturePath) GetOverrideProfile(
            string ownerId,
            string targetId)
        {
            if (string.IsNullOrEmpty(ownerId) || string.IsNullOrEmpty(targetId))
                return (null, null);

            using (var conn = new MySqlConnection(register.ConnectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT DisplayName, PicturePath
                    FROM ChatUserProfileOverride
                    WHERE OwnerID = @owner AND TargetID = @target;
                ";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@owner", ownerId);
                    cmd.Parameters.AddWithValue("@target", targetId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader["DisplayName"]?.ToString();
                            string pic = reader["PicturePath"]?.ToString();

                            if (string.IsNullOrWhiteSpace(name)) name = null;
                            if (string.IsNullOrWhiteSpace(pic)) pic = null;

                            return (name, pic);
                        }
                    }
                }
            }

            return (null, null);
        }
    }
}