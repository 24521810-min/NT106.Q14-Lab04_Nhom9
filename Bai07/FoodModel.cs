using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bai07
{
    // BODY gửi khi thêm món ăn
    public class AddFoodRequest
    {
        [JsonProperty("ten_mon_an")]
        public string TenMon { get; set; }

        [JsonProperty("gia")]
        public double Gia { get; set; }

        [JsonProperty("dia_chi")]
        public string DiaChi { get; set; }

        [JsonProperty("hinh_anh")]
        public string HinhAnh { get; set; }

        [JsonProperty("mo_ta")]
        public string MoTa { get; set; }
    }

    // Món ăn trả về từ API
    public class MonAn
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("ten_mon_an")]
        public string TenMon { get; set; }

        [JsonProperty("gia")]
        public double Gia { get; set; }

        [JsonProperty("dia_chi")]
        public string DiaChi { get; set; }

        [JsonProperty("hinh_anh")]
        public string HinhAnh { get; set; }

        [JsonProperty("mo_ta")]
        public string MoTa { get; set; }

        [JsonProperty("nguoi_dang")]
        public string NguoiDang { get; set; }
      
    }

    // Kết quả trả về khi gọi /monan/all
    public class FoodListResponse
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("data")]
        public List<MonAn> Items { get; set; }
    }

    // Kết quả trả về khi gọi /monan/my-dishes
    public class MyDishResponse
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("data")]
        public List<MonAn> Data { get; set; }
    }
}
