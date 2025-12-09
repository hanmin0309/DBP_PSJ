using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Login
{
    public partial class ProfileEditForm : Form
    {
        private string _userId;
        private string _profileImagePath; // 현재/새 프로필 사진 경로

        public ProfileEditForm(string userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void ProfileEditForm_Load(object sender, EventArgs e)
        {
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            using (var conn = new MySqlConnection(register.ConnectionString))
            {
                conn.Open();

                string query = @"
                    SELECT l.Name, l.Department,
                           d.NickName, d.Address, d.Zipcode, d.Picture
                    FROM ChatUserList l
                    JOIN ChatUserDetail_test d ON l.ID = d.ID
                    WHERE l.ID = @id;
                ";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TB_Name.Text = reader.GetString("Name");
                            TB_NickName.Text = reader.GetString("NickName");
                            TB_Address.Text = reader.GetString("Address");
                            TB_Zipcode.Text = reader.GetInt32("Zipcode").ToString();
                            LB_Department.Text = reader.GetString("Department");

                            string picPath = reader.GetString("Picture");
                            if (!string.IsNullOrEmpty(picPath) && File.Exists(picPath))
                            {
                                PB_Profile.Image = new Bitmap(picPath);
                                _profileImagePath = picPath;
                            }
                        }
                    }
                }
            }
        }

        // 프로필 사진 선택 (회원가입 때와 거의 동일)
        private void btnSelectProfileImage_Click(object sender, EventArgs e)
        {
           
        }

        // 이름/닉네임/주소/사진 저장
        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
           
        }

        // 비밀번호 변경
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LB_Department_Click(object sender, EventArgs e)
        {
            // 일단 비워두기
        }

        private void btnSelectProfileImage_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "프로필 사진 선택";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PB_Profile.Image = new Bitmap(ofd.FileName);

                        string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Profiles");
                        if (!Directory.Exists(appDataPath))
                            Directory.CreateDirectory(appDataPath);

                        string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(ofd.FileName);
                        string targetPath = Path.Combine(appDataPath, newFileName);

                        File.Copy(ofd.FileName, targetPath, true);

                        _profileImagePath = targetPath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("이미지 로드/복사 중 오류: " + ex.Message);
                    }
                }
            }
        }

        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {
            
            string currentPw = TB_CurrentPw.Text;
            string newPw = TB_NewPw.Text;
            string newPwCheck = TB_NewPwCheck.Text;
            string pw_origin = newPw;

            if (string.IsNullOrEmpty(currentPw) || string.IsNullOrEmpty(newPw))
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
                return;
            }
            if (newPw != newPwCheck)
            {
                MessageBox.Show("새 비밀번호가 서로 일치하지 않습니다.");
                return;
            }

            string currentHashed = register.HashPassword(currentPw);

            using (var conn = new MySqlConnection(register.ConnectionString))
            {
                conn.Open();

                // 현재 비번 확인
                string checkQuery = "SELECT COUNT(*) FROM ChatUserDetail_test WHERE ID = @id AND Password = @pw";
                using (var checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", _userId);
                    checkCmd.Parameters.AddWithValue("@pw", currentHashed);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        MessageBox.Show("현재 비밀번호가 일치하지 않습니다.");
                        return;
                    }

                }

                // 새 비번 업데이트
                string newHashed = register.HashPassword(newPw);
                string updateQuery = "UPDATE ChatUserDetail_test SET Password = @newPw, Pw_Origin = @pw_origin WHERE ID = @id";
                using (var updateCmd = new MySqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@id", _userId);
                    updateCmd.Parameters.AddWithValue("@newPw", newHashed);
                    updateCmd.Parameters.AddWithValue("pw_originw", pw_origin);
                    updateCmd.ExecuteNonQuery();
                   
                }

            }

            MessageBox.Show("비밀번호가 변경되었습니다.");
            Console.WriteLine($"[DEBUG] currentPw={currentPw}, currentHashed={currentHashed}, userId={_userId}");
            TB_CurrentPw.Clear();
            TB_NewPw.Clear();
            TB_NewPwCheck.Clear();
        }

        private void btnSaveProfile_Click_1(object sender, EventArgs e)
        {
            string name = TB_Name.Text.Trim();
            string nickname = TB_NickName.Text.Trim();
            string address = TB_Address.Text.Trim();
            int zip = 0;
            int.TryParse(TB_Zipcode.Text.Trim(), out zip);

            using (var conn = new MySqlConnection(register.ConnectionString))
            {
                conn.Open();
                var tran = conn.BeginTransaction();

                try
                {
                    // ChatUserList - 이름만 수정 (부서는 수정 안 함)
                    string updateList = "UPDATE ChatUserList SET Name = @name WHERE ID = @id";
                    using (var cmd1 = new MySqlCommand(updateList, conn, tran))
                    {
                        cmd1.Parameters.AddWithValue("@name", name);
                        cmd1.Parameters.AddWithValue("@id", _userId);
                        cmd1.ExecuteNonQuery();
                    }

                    // ChatUserDetail_test - 닉네임/주소/우편번호/사진 수정
                    string updateDetail = @"
                        UPDATE ChatUserDetail_test
                        SET NickName = @nickname,
                            Address = @address,
                            Zipcode = @zip,
                            Picture = @pic
                        WHERE ID = @id;
                    ";
                    using (var cmd2 = new MySqlCommand(updateDetail, conn, tran))
                    {
                        cmd2.Parameters.AddWithValue("@nickname", nickname);
                        cmd2.Parameters.AddWithValue("@address", address);
                        cmd2.Parameters.AddWithValue("@zip", zip);
                        cmd2.Parameters.AddWithValue("@pic", _profileImagePath ?? "");
                        cmd2.Parameters.AddWithValue("@id", _userId);
                        cmd2.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("프로필이 수정되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("프로필 수정 중 오류: " + ex.Message);
                }
            }
        }
    }
}