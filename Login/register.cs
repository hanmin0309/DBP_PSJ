using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net.Http;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Linq;

namespace Login
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        public const string ConnectionString = "Server=223.130.151.111;Port=3306;Database=s5701514;Uid=s5701514;Pwd=s5701514;";
        private void register_Load(object sender, EventArgs e)
        {
            LoadApartmentData();
        }

        //폼 위치 이동 관련
        private bool _dragging = false;
        private Point _offset;
        private void register_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragging = true;
                _offset = new Point(e.Location.X, e.Location.Y);
            }
        }
        private void register_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point currentScreenPos = Cursor.Position;
                this.Location = new Point(currentScreenPos.X - _offset.X, currentScreenPos.Y - _offset.Y);
            }
        }
        private void register_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }
        //아이디 중복 체크
        private void TB_id_LostFocus(object sender, EventArgs e)
        {
            string id = TB_id.Text.Trim();

            if (string.IsNullOrEmpty(id))
            {
                return;
            }
            if (IsIdDuplicated(id))
            {
                LB_id_duped.Text = "이미 사용 중인 ID입니다";
                TB_id.Focus();
            }
            else
            {
                LB_id_duped.ForeColor = Color.SkyBlue;
                LB_id_duped.Text = "사용 가능한 ID입니다";
            }
        }
        private bool IsIdDuplicated(string id)
        {
            bool duplicated = false;
            string selectQuery = $"SELECT COUNT(*) FROM ChatUserList WHERE ID = @id";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        duplicated = count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ID 중복 확인 중 오류 발생: " + ex.Message);
                    return true;
                }
            }
            return duplicated;
        }
        //해쉬, PW체크
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void TB_pw_check_TextChanged(object sender, EventArgs e)
        {
            if (TB_pw.Text != TB_pw_check.Text)
            {
                LB_pw_check.Visible = true;
            }
            else
            {
                LB_pw_check.Visible = false;
            }
        }
        //프로필사진
        private string _profileImagePath = null;
        private void pictureBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "프로필 사진 선택";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (sender is PictureBox pictureBox)
                        {
                            pictureBox.Image = new Bitmap(ofd.FileName);
                        }

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
                        MessageBox.Show("이미지 로드 또는 복사 중 오류 발생: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //주소API
        private async void BT_find_zipCode_Click(object sender, EventArgs e)
        {
            string searchKeyword = Interaction.InputBox("주소 검색어를 입력하세요 (예: 강남대로 390):", "주소 검색", "");

            if (string.IsNullOrWhiteSpace(searchKeyword)) return;


            string API_KEY = "devU01TX0FVVEgyMDI1MTEyNjE3MjIyNjExNjQ5OTA=";
            string apiBaseUrl = "https://www.juso.go.kr/addrlink/addrLinkApi.do";


            var parameters = new Dictionary<string, string>
    {
        {"confmKey", API_KEY},
        {"currentPage", "1"},
        {"countPerPage", "1"},
        {"keyword", searchKeyword},
        {"resultType", "json"}
    };

            string queryString = string.Join("&", parameters.Select(kv => $"{kv.Key}={Uri.EscapeDataString(kv.Value)}"));
            string fullUrl = $"{apiBaseUrl}?{queryString}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(fullUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    using (JsonDocument document = JsonDocument.Parse(responseBody))
                    {
                        var root = document.RootElement;
                        var results = root.GetProperty("results");
                        var common = results.GetProperty("common");

                        if (common.GetProperty("errorCode").GetString() != "0")
                        {
                            MessageBox.Show($"주소 검색 실패: {common.GetProperty("errorMessage").GetString()}", "API 오류");
                            return;
                        }

                        var jusoArray = results.GetProperty("juso");

                        if (jusoArray.GetArrayLength() > 0)
                        {
                            var firstJuso = jusoArray[0];

                            string zipNo = firstJuso.GetProperty("zipNo").GetString();
                            string roadAddr = firstJuso.GetProperty("roadAddr").GetString();

                            TB_zipCode.Text = $"({zipNo}) {roadAddr}";

                            MessageBox.Show($"주소 검색 완료!\nTB_zipCode에 {TB_zipCode.Text}가 입력되었습니다.\n\n나머지 상세 주소(동호수 등)를 직접 추가 입력해주세요.", "검색 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("검색 결과가 없습니다. 검색어를 다시 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"주소 검색 중 예상치 못한 오류 발생: {ex.Message}", "시스템 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //부서정보불러오기
        public void LoadApartmentData()
        {
            CB_apartment.Items.Clear();
            string selectQuery = "SELECT Department FROM ChatUserDepartment ORDER BY Department";
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CB_apartment.Items.Add(reader.GetString("Department"));
                        }
                        if (CB_apartment.Items.Count > 0)
                        {
                            CB_apartment.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("DB에서 부서 정보를 불러오지 못했습니다. 테이블을 확인해주세요.", "경고");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("부서 정보 로드 중 오류 발생: " + ex.Message);
                }
            }
        }
        //최종가입
        public static void AddNewAccount(string id, string hashedPassword, string name, string address, string nickname, string department, int zipCode, string profilePath)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string listInsertQuery = "INSERT INTO ChatUserList(ID, Name, Department) " +
                                             "VALUES (@id, @name, @dept);";

                    using (MySqlCommand listCommand = new MySqlCommand(listInsertQuery, connection, transaction))
                    {
                        listCommand.Parameters.AddWithValue("@id", id);
                        listCommand.Parameters.AddWithValue("@name", name);
                        listCommand.Parameters.AddWithValue("@dept", department);
                        listCommand.ExecuteNonQuery();
                    }

                    //테스트용 ChatUserDetail_test테이블 사용중 수정 필요
                    string detailInsertQuery = "INSERT INTO ChatUserDetail_test(ID, Password, NickName, Address, Zipcode, Picture) " +
                                               "VALUES (@id, @pw, @nickname, @address, @zipcode, @picture);";

                    using (MySqlCommand detailCommand = new MySqlCommand(detailInsertQuery, connection, transaction))
                    {
                        detailCommand.Parameters.AddWithValue("@id", id);
                        detailCommand.Parameters.AddWithValue("@pw", hashedPassword);
                        detailCommand.Parameters.AddWithValue("@nickname", nickname);
                        detailCommand.Parameters.AddWithValue("@address", address);
                        detailCommand.Parameters.AddWithValue("@zipcode", zipCode);
                        detailCommand.Parameters.AddWithValue("@picture", profilePath ?? "");
                        detailCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("회원가입이 완료되었습니다.");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    MessageBox.Show("회원가입 실패: DB 오류. " + e.Message);
                    Console.WriteLine(e.ToString());
                }
            }
        }
        private void BT_signUp_Click(object sender, EventArgs e)
        {
            string id = TB_id.Text.Trim();
            string password = TB_pw.Text;
            string passwordCheck = TB_pw_check.Text;
            string name = TB_name.Text.Trim();
            string fullAddress = TB_zipCode.Text.Trim();
            string detailAddressInput = TB_address_detail.Text.Trim();
            string nickname = TB_nickname.Text.Trim();
            string department = CB_apartment.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(passwordCheck) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(fullAddress))
            {
                MessageBox.Show("필수 정보를 입력해주세요.");
                return;
            }

            if (IsIdDuplicated(id))
            {
                MessageBox.Show("ID 중복이 확인되었습니다. ID를 변경하거나 확인해주세요.", "가입 실패");
                TB_id.Focus();
                return;
            }
            if (password != passwordCheck)
            {
                MessageBox.Show("입력된 비밀번호가 일치하지 않습니다.", "가입 실패");
                TB_pw_check.Focus();
                LB_pw_check.Visible = true;
                return;
            }
            string hashedPassword = HashPassword(password);

            string zipCodeStr = "0";
            string baseAddress = fullAddress;

            if (fullAddress.StartsWith("(") && fullAddress.Contains(")"))
            {
                int start = fullAddress.IndexOf('(') + 1;
                int end = fullAddress.IndexOf(')');
                if (end > start)
                {
                    zipCodeStr = fullAddress.Substring(start, end - start).Trim();
                    baseAddress = fullAddress.Substring(end + 1).Trim();
                }
            }
            int zipCode = int.TryParse(zipCodeStr, out int zc) ? zc : 0;
            string finalAddressToSave = baseAddress + " " + detailAddressInput;

            AddNewAccount(id, hashedPassword, name, finalAddressToSave, nickname, department, zipCode, _profileImagePath);
            this.Close();
        }
        //BT_close
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LB_pw_check_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void CB_apartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
