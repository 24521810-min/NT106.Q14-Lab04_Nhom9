using Newtonsoft.Json;

namespace Bai07
{
    // Kết quả trả về khi login /auth/token
    public class LoginResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }

    // Body gửi khi đăng ký /api/v1/user/signup
    public class SignupRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        // sex: số nguyên (Swagger ví dụ 0)
        [JsonProperty("sex")]
        public int Sex { get; set; }

        // birthday: chuỗi "yyyy-MM-dd"
        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
