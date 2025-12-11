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

            // ================= HIỆU ỨNG HOVER =================
            this.BorderStyle = BorderStyle.None;

            // Đăng ký MouseEnter/Leave cho cả card và mọi control con
            this.MouseEnter += FoodCard_MouseEnter;
            this.MouseLeave += FoodCard_MouseLeave;

            foreach (Control c in this.Controls)
            {
                c.MouseEnter += FoodCard_MouseEnter;
                c.MouseLeave += FoodCard_MouseLeave;
            }
        }

        // ======================== SET DATA ========================
        public void SetData(MonAn food)
        {
            _food = food;

            label1.Text = "Tên món: " + (food.TenMon ?? "");
            label3.Text = "Giá: " + food.Gia.ToString("N0") + "đ";
            label4.Text = "Địa chỉ: " + (food.DiaChi ?? "");
            label2.Text = "Người đăng: " + (food.NguoiDang ?? "Ẩn danh");

            LoadImageAsync(food.HinhAnh);
        }

        // =================== LOAD IMAGE (FILE + URL) ===================
        private async void LoadImageAsync(string pathOrUrl)
        {
            if (string.IsNullOrWhiteSpace(pathOrUrl))
            {
                pictureBox1.Image = null;
                return;
            }

            try
            {
                // Ảnh chọn từ máy (đường dẫn local)
                if (File.Exists(pathOrUrl))
                {
                    pictureBox1.Image = Image.FromFile(pathOrUrl);
                    return;
                }

                // Ảnh online (URL)
                using (HttpClient http = new HttpClient())
                {
                    http.DefaultRequestHeaders.Add(
                        "User-Agent",
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64)"
                    );

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

        // ======================== HOVER BORDER ========================
        private void FoodCard_MouseEnter(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void FoodCard_MouseLeave(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
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
                MessageBoxButtons.YesNo
            );

            if (confirm == DialogResult.No)
                return;

            OnDelete?.Invoke(_food.Id);
        }
    }
}
