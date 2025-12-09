using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bai07
{
    public static class ApiClient
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://nt106.uitiot.vn/")
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
                var json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Đăng nhập thất bại:\n{json}");

                return JsonConvert.DeserializeObject<LoginResponse>(json);
            }
        }

        // ---------------- SIGNUP ----------------
        public static async Task<bool> SignupAsync(SignupRequest req)
        {
            var json = JsonConvert.SerializeObject(req);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/v1/user/signup", content);

            if (!response.IsSuccessStatusCode)
            {
                var msg = await response.Content.ReadAsStringAsync();
                throw new Exception($"Đăng ký thất bại:\n{msg}");
            }

            return true;
        }

        // ---------------- ADD FOOD ----------------
        public static async Task AddFoodAsync(AddFoodRequest req, string token)
        {
            SetAuth(token);

            var json = JsonConvert.SerializeObject(req);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync("/api/v1/monan/add", content);
            var msg = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new Exception($"Lỗi thêm món ăn:\n{msg}");
        }

        // ---------------- GET ALL FOODS ----------------
        public static async Task<FoodListResponse> GetAllFoodsAsync(int page, int size, string token)
        {
            SetAuth(token);

            var body = new
            {
                page = page,
                size = size
            };

            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // POST đúng theo Swagger
            var res = await _client.PostAsync("/api/v1/monan/all", content);
            var result = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new Exception(result);

            return JsonConvert.DeserializeObject<FoodListResponse>(result);
        }

        // ---------------- GET MY FOODS ----------------
        public static async Task<List<MonAn>> GetMyFoodsAsync(string token)
        {
            SetAuth(token);

            // Body JSON rỗng tránh lỗi FastAPI
            var content = new StringContent("{}", Encoding.UTF8, "application/json");

            var res = await _client.PostAsync("/api/v1/monan/my-dishes", content);
            var json = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new Exception(json);

            var result = JsonConvert.DeserializeObject<MyDishResponse>(json);

            return result.Data;   // ⭐ trả về list
        }




        // ---------------- DELETE FOOD ----------------
        public static async Task DeleteFoodAsync(int id, string token)
        {
            SetAuth(token);

            var res = await _client.DeleteAsync($"/api/v1/mon-an/{id}");
            var msg = await res.Content.ReadAsStringAsync();

            if (!res.IsSuccessStatusCode)
                throw new Exception("Xóa món thất bại:\n" + msg);
        }


        // ---------------- PRIVATE AUTH ----------------
        private static void SetAuth(string token)
        {
            _client.DefaultRequestHeaders.Remove("Authorization");
            _client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }
}
