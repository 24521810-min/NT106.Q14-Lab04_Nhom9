using System.Text.Json.Serialization;

namespace Bai07
{
    // Kết quả trả về khi login /auth/token
    public class LoginResponse
    {
        // FastAPI OAuth2 Password thường trả:
        // { "access_token": "...", "token_type": "bearer" }
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
    }

    // Body gửi khi đăng ký /api/v1/user/signup
    public class SignupRequest
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        // sex: số nguyên (Swagger ví dụ 0)
        [JsonPropertyName("sex")]
        public int Sex { get; set; }

        // birthday: chuỗi "yyyy-MM-dd"
        [JsonPropertyName("birthday")]
        public string Birthday { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    }
}
