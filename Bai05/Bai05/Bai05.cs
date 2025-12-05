using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Bai05
{
    public partial class Bai05 : Form
    {
        public Bai05()
        {
            InitializeComponent();
            button_login.Click += button_login_Click;
        }

        private async void button_login_Click(object sender, EventArgs e)
        {
            string url = textBox_URL.Text.Trim();
            string username = textBox_username.Text.Trim();
            string password = textBox_pass.Text.Trim();

            richTextBox1.Clear();

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ URL, Username và Password!");
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    MultipartFormDataContent content = new MultipartFormDataContent
            {
                { new StringContent(username), "username" },
                { new StringContent(password), "password" }
            };

                    // Gửi POST
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // Đọc chuỗi JSON trả về
                    string responseString = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(responseString);

                    // Nếu status code không phải 200 → lỗi đăng nhập
                    if (!response.IsSuccessStatusCode)
                    {
                        string detail = json["detail"]?.ToString() ?? "Unknown error";
                        richTextBox1.Text = "Đăng nhập thất bại!\n" + detail;
                        return;
                    }

                    // Thành công → lấy token
                    string tokenType = json["token_type"]?.ToString() ?? "";
                    string accessToken = json["access_token"]?.ToString() ?? "";

                    richTextBox1.Text =
                        "Đăng nhập thành công!\n" +
                        $"token_type: {tokenType}\n" +
                        $"access_token: {accessToken}\n";
                }
                catch (Exception ex)
                {
                    richTextBox1.Text = "Lỗi: " + ex.Message;
                }
            }
        }

    }
}
