using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace Bai07
{
    public partial class FoodCard : UserControl
    {
        // ==== SỰ KIỆN GỬI ID MÓN VỀ FrmMain ====
        public event Action<int> OnDelete;

        private MonAn _food;

        public FoodCard()
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Gắn sự kiện nút Xoá
            btnxoa.Click += BtnXoa_Click;
        }

        // ======================================================
        // SET DATA
        // ======================================================
        public void SetData(MonAn food)
        {
            _food = food;

            label1.Text = "Tên món: " + food.TenMon;
            label3.Text = "Giá: " + food.Gia + "đ";
            label4.Text = "Địa chỉ: " + food.DiaChi;
            label2.Text = "Người đăng: " + food.NguoiDang;

            LoadImageAsync(food.HinhAnh);
        }

        // ======================================================
        // LOAD IMAGE ASYNC
        // ======================================================
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

        // ======================================================
        // BUTTON XOÁ
        // ======================================================
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_food == null)
            {
                MessageBox.Show("Không tìm thấy món để xoá!");
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc muốn xoá món này?",
                "Xác nhận",
                MessageBoxButtons.YesNo);

            if (confirm == DialogResult.No)
                return;

            // Gọi sự kiện về FrmMain
            OnDelete?.Invoke(_food.Id);
        }
    }
}
