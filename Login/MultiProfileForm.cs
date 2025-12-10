using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login
{
    public partial class MultiProfileForm : Form
    {
        private string _ownerId;     // 나(로그인한 사람) ID
        private string _targetId;    // 상대방 ID
        private string _imagePath;   // 상대별 프로필 사진 경로

        public MultiProfileForm(string ownerId, string targetId)
        {
            InitializeComponent();
            _ownerId = ownerId;
            _targetId = targetId;
        }

        private void MultiProfileForm_Load(object sender, EventArgs e)
        {
            LoadMultiProfile();
        }

        // DB에서 기존 상대별 프로필을 읽어오기
        private void LoadMultiProfile()
        {
            using (var conn = new MySqlConnection(register.ConnectionString))
            {
                conn.Open();

                string query = @"
                    SELECT DisplayName, PicturePath
                    FROM ChatUserProfileOverride
                    WHERE OwnerID = @owner AND TargetID = @target;
                ";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@owner", _ownerId);
                    cmd.Parameters.AddWithValue("@target", _targetId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TB_DisplayName.Text = reader["DisplayName"].ToString();

                            string pic = reader["PicturePath"].ToString();
                            if (!string.IsNullOrEmpty(pic) && File.Exists(pic))
                            {
                                PB_Override.Image = new Bitmap(pic);
                                _imagePath = pic;
                            }
                        }
                        else
                        {
                            // 아직 override 없으면 기본값 비워두기
                            // 필요하면 여기서 내 기본 이름/닉네임을 읽어와 넣어도 됨
                        }
                    }
                }
            }
        }

        // 사진 선택
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "상대별 프로필 사진 선택";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PB_Override.Image = new Bitmap(ofd.FileName);

                        string appDataPath = Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            "MultiProfiles"
                        );
                        if (!Directory.Exists(appDataPath))
                            Directory.CreateDirectory(appDataPath);

                        string newFileName =
                            Guid.NewGuid().ToString() + Path.GetExtension(ofd.FileName);
                        string targetPath = Path.Combine(appDataPath, newFileName);

                        File.Copy(ofd.FileName, targetPath, true);

                        _imagePath = targetPath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("이미지 로드/복사 중 오류: " + ex.Message);
                    }
                }
            }
        }

        // 저장 버튼
        private void btnSave_Click(object sender, EventArgs e)
        {
            string dispName = TB_DisplayName.Text.Trim();

            using (var conn = new MySqlConnection(register.ConnectionString))
            {
                conn.Open();

                // 이 OwnerID + TargetID 조합이 이미 있는지 확인
                string checkSql = @"
                    SELECT COUNT(*)
                    FROM ChatUserProfileOverride
                    WHERE OwnerID = @owner AND TargetID = @target;
                ";

                using (var checkCmd = new MySqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@owner", _ownerId);
                    checkCmd.Parameters.AddWithValue("@target", _targetId);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    string sql;
                    if (count > 0)
                    {
                        // UPDATE
                        sql = @"
                            UPDATE ChatUserProfileOverride
                            SET DisplayName = @name,
                                PicturePath = @pic
                            WHERE OwnerID = @owner AND TargetID = @target;
                        ";
                    }
                    else
                    {
                        // INSERT
                        sql = @"
                            INSERT INTO ChatUserProfileOverride
                                (OwnerID, TargetID, DisplayName, PicturePath)
                            VALUES
                                (@owner, @target, @name, @pic);
                        ";
                    }

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@owner", _ownerId);
                        cmd.Parameters.AddWithValue("@target", _targetId);
                        cmd.Parameters.AddWithValue("@name", dispName);
                        cmd.Parameters.AddWithValue("@pic", _imagePath ?? "");

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("상대별 프로필이 저장되었습니다.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}