using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai04
{
    public partial class FrmChonGhe : Form
    {
        public string GheDaChon { get; private set; } = "";

        public FrmChonGhe()
        {
            InitializeComponent();
            GanSuKienChoGhe();
            button16.Click += BtnXacNhan_Click; // gán event nút xác nhận
        }

        private void GanSuKienChoGhe()
        {
            // Gán sự kiện click cho tất cả Button trong panelSeats
            foreach (Control ctrl in panelSeats.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.LightGray;
                    btn.Click += Ghe_Click;
                }
            }
        }

        private void Ghe_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // Lưu tên ghế đã chọn
            GheDaChon = btn.Text;

            // Reset màu tất cả ghế
            foreach (Control ctrl in panelSeats.Controls)
            {
                if (ctrl is Button b)
                    b.BackColor = Color.LightGray;
            }

            // Tô màu ghế được chọn
            btn.BackColor = Color.LightGreen;
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GheDaChon))
            {
                MessageBox.Show("Vui lòng chọn 1 ghế trước khi xác nhận!");
                return;
            }

            // Trả kết quả về form cha
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
