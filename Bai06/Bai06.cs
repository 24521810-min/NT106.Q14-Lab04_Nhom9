using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Bai06
{
    public partial class Bai06 : Form
    {
        public Bai06()
        {
            InitializeComponent();
        }

        private async void btnGetUserInfo_Click(object sender, EventArgs e)
        {
            string tokenType = txtTokenType.Text.Trim();
            string accessToken = txtAccessToken.Text.Trim();

            if (string.IsNullOrEmpty(tokenType) || string.IsNullOrEmpty(accessToken))
            {
                MessageBox.Show("Vui lòng nhập Token Type và Access Token!",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(tokenType, accessToken);

                    var getUserUrl = "https://nt106.uitiot.vn/api/v1/user/me";

                    var getUserResponse = await client.GetAsync(getUserUrl);
                    var getUserResponseString = await getUserResponse.Content.ReadAsStringAsync();

                    if (!getUserResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Lỗi: " + getUserResponseString);
                        return;
                    }

                    JObject data = JObject.Parse(getUserResponseString);

                    // Gán dữ liệu vào giao diện
                    txtID.Text = data["id"]?.ToString();
                    txtUsername.Text = data["username"]?.ToString();
                    txtEmail.Text = data["email"]?.ToString();
                    txtFirstname.Text = data["first_name"]?.ToString();
                    txtLastname.Text = data["last_name"]?.ToString();
                    txtPhone.Text = data["phone"]?.ToString();
                    txtLanguage.Text = data["language"]?.ToString();
                    int sex = data["sex"]?.ToObject<int>() ?? 0;
                    cbSex.SelectedIndex = (sex == 0 ? 0 : 1);

                    string birthday = data["birthday"]?.ToString();
                    if (!string.IsNullOrEmpty(birthday))
                    {
                        dateTimePicker1.Value = DateTime.Parse(birthday);
                    }

                    MessageBox.Show("Lấy thông tin thành công!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }
    }
}
