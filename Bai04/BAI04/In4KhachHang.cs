using Bai04;
using System;
using System.Windows.Forms;

namespace BAI04
{
    public partial class In4KhachHang : Form
    {
        // Thuộc tính trả dữ liệu về Form chính
        public string CustomerName { get; set; } = "";
        public string CustomerPhone { get; set; } = "";
        public string SelectedSeat { get; set; } = ""; // ghế đã chọn

        public In4KhachHang()
        {
            InitializeComponent();

            // Gán event cho nút
            btnxacnhan.Click += btnxacnhan_Click;
            button1.Click += BtnChonGhe_Click; // nút CHỌN GHẾ
        }

        // =============================
        //  NÚT CHỌN GHẾ
        // =============================
        private void BtnChonGhe_Click(object sender, EventArgs e)
        {
            FrmChonGhe f = new FrmChonGhe();

            if (f.ShowDialog() == DialogResult.OK)
            {
                SelectedSeat = f.GheDaChon;

                // Nếu bạn có label hiển thị ghế, thì hiển thị luôn
                // lblGhe.Text = "Ghế: " + SelectedSeat;

                MessageBox.Show("Bạn đã chọn ghế: " + SelectedSeat);
            }
        }

        // =============================
        //  NÚT XÁC NHẬN
        // =============================
        private void btnxacnhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
                return;
            }

            // Kiểm tra SĐT
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                return;
            }

            // Kiểm tra ghế đã chọn
            if (string.IsNullOrWhiteSpace(SelectedSeat))
            {
                MessageBox.Show("Vui lòng chọn ghế trước khi xác nhận!");
                return;
            }

            // Gán giá trị trả về
            CustomerName = textBox1.Text;
            CustomerPhone = textBox2.Text;

            // Trả kết quả về form gọi nó
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
