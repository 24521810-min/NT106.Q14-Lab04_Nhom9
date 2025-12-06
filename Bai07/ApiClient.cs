using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bai07
{
    public static class ApiClient
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://nt106.uitiot.vn")
        };

        // ---------------- LOGIN ----------------
        public static async Task<LoginResponse> LoginAsync(string username, string password)
        {
            
            var form = new Dictionary<string, string>
            {
                ["grant_type"] = "password",  
                ["username"] = username,
                ["password"] = password,
                ["scope"] = "",               
                ["client_id"] = "",           
                ["client_secret"] = ""
            };

            using (var content = new FormUrlEncodedContent(form))
            {
                var response = await _client.PostAsync("/auth/token", content);

                if (!response.IsSuccessStatusCode)
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Đăng nhập thất bại: {response.StatusCode}\n{msg}");
                }

                var json = await response.Content.ReadAsStringAsync();

                var opt = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<LoginResponse>(json, opt);
            }
        }

        // ---------------- SIGNUP ----------------
        public static async Task<bool> SignupAsync(SignupRequest req)
        {
            var json = JsonSerializer.Serialize(req);
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var response = await _client.PostAsync("/api/v1/user/signup", content);

                if (!response.IsSuccessStatusCode)
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Đăng ký thất bại: {response.StatusCode}\n{msg}");
                }

                return true;
            }
        }
    }
}
