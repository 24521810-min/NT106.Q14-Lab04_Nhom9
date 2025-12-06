using System;
using System.Drawing;
using System.Windows.Forms;

namespace BAI04
{
    public partial class Chitietphim : Form
    {
        private string detailUrl = "";

        public Chitietphim()
        {
            InitializeComponent();

            // Gán event cho nút đặt vé
            btndat.Click += btndat_Click;
            btnXem.Click += btnXem_Click;
        }

        // Hàm nhận dữ liệu từ MovieItem
        public void SetData(string name, Image poster, string url)
        {
            lblName.Text = name;
            picPoster.Image = poster;
            detailUrl = url;

            // ================= THÔNG TIN PHIM ======================
            switch (name)
            {
                case "Zootopia 2":
                    lblDirector.Text = "Đạo diễn: Jared Bush, Trent Correy";
                    lblActors.Text = "Diễn viên: Ginnifer Goodwin, Jason Bateman";
                    lblGenre.Text = "Thể loại: Hoạt hình, Hài, Phiêu lưu";
                    lblDuration.Text = "Thời lượng: 110 phút";
                    textBox1.Text = "Judy và Nick tiếp tục nhiệm vụ mới tại thành phố động vật Zootopia với nhiều kẻ thù và bí ẩn mới.";
                    break;

                case "Jujutsu Kaisen The Movie: Biến Cố Shibuya x Tử Diệt Hồi Du":
                    lblDirector.Text = "Đạo diễn: Sunghoo Park";
                    lblActors.Text = "Diễn viên: Yuichi Nakamura, Junya Enoki";
                    lblGenre.Text = "Thể loại: Hành động, Siêu nhiên";
                    lblDuration.Text = "Thời lượng: 128 phút";
                    textBox1.Text = "Sự kiện Shibuya hỗn loạn khi các chú thuật sư đối đầu nguy cơ bị nguyền tàn diệt toàn bộ.";
                    break;

                case "5 Centimet Trên Giây":
                    lblDirector.Text = "Đạo diễn: Makoto Shinkai";
                    lblActors.Text = "Diễn viên: Kenji Mizuhashi, Yoshimi Kondou";
                    lblGenre.Text = "Thể loại: Tình cảm, Drama";
                    lblDuration.Text = "Thời lượng: 63 phút";
                    textBox1.Text = "Câu chuyện nhẹ nhàng nhưng day dứt về khoảng cách và thời gian giữa hai người thương nhau.";
                    break;

                case "Anh Trai Say Xe":
                    lblDirector.Text = "Đạo diễn: Kim Jung Hoon";
                    lblActors.Text = "Diễn viên: Cha Eun Woo, Kim Young Kwang";
                    lblGenre.Text = "Thể loại: Hài, Lãng mạn";
                    lblDuration.Text = "Thời lượng: 118 phút";
                    textBox1.Text = "Một nhóm bạn trai hợp sức 'cứu' anh bạn hay say xe trong hành trình tình yêu đầy rắc rối.";
                    break;

                case "Chainsaw Man The Movie: Chương Reze":
                    lblDirector.Text = "Đạo diễn: Tatsuya Kitani";
                    lblActors.Text = "Diễn viên: Kikunosuke Toya, Tomori Kusunoki";
                    lblGenre.Text = "Thể loại: Hành động, Kinh dị";
                    lblDuration.Text = "Thời lượng: 115 phút";
                    textBox1.Text = "Denji gặp Reze – cô gái bí ẩn mang đến bi kịch và những trận chiến ác liệt chưa từng có.";
                    break;

                default:
                    lblDirector.Text = "Đạo diễn: Chưa có dữ liệu";
                    lblActors.Text = "Diễn viên: Chưa có dữ liệu";
                    lblGenre.Text = "Thể loại: Chưa có dữ liệu";
                    lblDuration.Text = "Thời lượng: Chưa có dữ liệu";
                    textBox1.Text = "Mô tả phim đang được cập nhật...";
                    break;
            }

            // Giá vé
            lblgia.Text = "Giá vé: 75.000 đ";
        }


        // Nút xem chi tiết mở trang web theo URL
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(detailUrl))
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = detailUrl,
                    UseShellExecute = true
                });
        }

        // Nút đặt vé → mở Form nhập khách hàng
        private void btndat_Click(object sender, EventArgs e)
        {
            In4KhachHang f = new In4KhachHang();

            if (f.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    $"Khách hàng: {f.CustomerName}\n" +
                    $"SĐT: {f.CustomerPhone}\n" +
                    $"Phim: {lblName.Text}\n" +
                    $"Giá vé: 75.000đ\n\n" +
                    "Đặt vé thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information
                );
            }
        }
    }
}
