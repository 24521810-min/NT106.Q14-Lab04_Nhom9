using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace Bai07
{
    public partial class FoodCard : UserControl
    {
        private int _foodId;

        // Event gửi ID món về FrmMain để xử lý xóa
        public event Action<int> OnDelete;

        public FoodCard()
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Gắn sự kiện nút Xóa
            btnxoa.Click += btnxoa_Click;
        }

        // ---------------- SET DATA ----------------
        public void SetData(MonAn food)
        {
            Console.WriteLine(">>> ID nhận được: " + food.Id);

            label1.Text = "Tên món: " + food.TenMon;
            label3.Text = "Giá: " + food.Gia + "đ";
            label4.Text = "Địa chỉ: " + food.DiaChi;
            label2.Text = "Người đăng: " + food.NguoiDang;

            LoadImageAsync(food.HinhAnh);

            this.Tag = food.Id; // lưu ID để xoá
        }

        // ---------------- LOAD IMAGE ----------------
        private async void LoadImageAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                pictureBox1.Image = null;
                return;
            }

            try
            {
                using (HttpClient http = new HttpClient())
                {
                    // Giả lập user-agent để server cho download
                    http.DefaultRequestHeaders.Add("User-Agent",
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                    var bytes = await http.GetByteArrayAsync(url);
                    using (var ms = new MemoryStream(bytes))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        // ---------------- DELETE BUTTON ----------------
        private void btnxoa_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có chắc muốn xoá món này?",
                "Xác nhận xoá",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                // Gửi event cho FrmMain xử lý
                OnDelete?.Invoke(_foodId);
            }
        }
    }
}
