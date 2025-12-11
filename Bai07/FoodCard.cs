using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace Bai07
{
    public partial class FoodCard : UserControl
    {
        public event Action<int> OnDelete;

        private MonAn _food;

        public FoodCard()
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            btnxoa.Click += BtnXoa_Click;
        }

        // ======================== SET DATA ========================
        public void SetData(MonAn food)
        {
            _food = food;

            // Tên món, giá, địa chỉ, người đăng
            label1.Text = "Tên món: " + (food.TenMon ?? "");
            label3.Text = "Giá: " + food.Gia.ToString("N0") + "đ";
            label4.Text = "Địa chỉ: " + (food.DiaChi ?? "");
            label2.Text = "Người đăng: " + (food.NguoiDang ?? "");

            LoadImageAsync(food.HinhAnh);
        }

        // =================== LOAD IMAGE (URL + FILE) ===================
        private async void LoadImageAsync(string pathOrUrl)
        {
            if (string.IsNullOrWhiteSpace(pathOrUrl))
            {
                pictureBox1.Image = null;
                return;
            }

            try
            {
   
                if (File.Exists(pathOrUrl))
                {
                    pictureBox1.Image = Image.FromFile(pathOrUrl);
                    return;
                }
                using (HttpClient http = new HttpClient())
                {
                    http.DefaultRequestHeaders.Add("User-Agent",
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                    var bytes = await http.GetByteArrayAsync(pathOrUrl);
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

        // ======================== BUTTON XOÁ ========================
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

            OnDelete?.Invoke(_food.Id);
        }
    }
}
