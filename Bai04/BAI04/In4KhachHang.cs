using System;
using System.Windows.Forms;

namespace BAI04
{
    public partial class In4KhachHang : Form
    {
        // Hai thuộc tính dùng để trả dữ liệu về Form Chi Tiết
        public string CustomerName { get; set; } = "";
        public string CustomerPhone { get; set; } = "";

        public In4KhachHang()
        {
            InitializeComponent();

            // Gán event cho nút xác nhận
            btnxacnhan.Click += btnxacnhan_Click;
        }

        private void btnxacnhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập tên
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
                return;
            }

            // Kiểm tra nhập SĐT
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                return;
            }

            // Gán lại cho property
            CustomerName = textBox1.Text;
            CustomerPhone = textBox2.Text;

            // Trả kết quả thành công về Form gọi nó
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
