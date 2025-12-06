using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace BAI04
{
    public partial class MovieItem : UserControl
    {
        public string DetailUrl { get; set; }   // Lưu link chi tiết để mở form 2

        public MovieItem()
        {
            InitializeComponent();

            // Gán click cho tất cả control → click đâu cũng mở form chi tiết
            this.Click += MovieItem_Click;
            picPoster.Click += MovieItem_Click;
            lblName.Click += MovieItem_Click;
            linkDetail.Click += MovieItem_Click;
        }

        /// <summary>
        /// Nhận dữ liệu từ form chính và hiển thị lên item phim
        /// </summary>
        public void SetData(string name, string imageUrl, string detailUrl)
        {
            lblName.Text = name;
            DetailUrl = detailUrl;

            // Hiển thị chữ "Xem chi tiết" làm link
            linkDetail.Text = "Xem chi tiết";

            // Load ảnh từ URL vào PictureBox
            try
            {
                using (var client = new WebClient())
                {
                    byte[] data = client.DownloadData(imageUrl);
                    using (var ms = new MemoryStream(data))
                    {
                        picPoster.Image = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                picPoster.Image = null;
            }
        }

        /// <summary>
        /// Khi click → mở form chi tiết phim
        /// </summary>
        private void MovieItem_Click(object sender, EventArgs e)
        {
            Chitietphim f = new Chitietphim();
            f.SetData(lblName.Text, picPoster.Image, DetailUrl);
            f.ShowDialog();
        }
    }
}
