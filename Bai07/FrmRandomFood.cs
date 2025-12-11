using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using System.Drawing;

namespace Bai07
{
    public partial class FrmRandomFood : Form
    {
        public FrmRandomFood(MonAn food)
        {
            InitializeComponent();

            lblName.Text = food.TenMon ?? "";
            lblPrice.Text = food.Gia.ToString("N0") + "đ";
            lblAddress.Text = food.DiaChi ?? "";
            lblUser.Text = food.NguoiDang ?? "";

            LoadImage(food.HinhAnh);
            btnOK.Click += btnOK_Click;
        }

        private async void LoadImage(string pathOrUrl)
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
