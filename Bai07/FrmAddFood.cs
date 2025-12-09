using System;
using System.Windows.Forms;

namespace Bai07
{
    public partial class FrmAddFood : Form
    {
        private readonly string _token;

        public FrmAddFood(string token)
        {
            InitializeComponent();
            _token = token;

            btnAdd.Click += BtnAdd_Click;
            btnClear.Click += BtnClear_Click;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtFoodName.Clear();
            txtPrice.Clear();
            txtAddress.Clear();
            txtImageUrl.Clear();
            txtDescription.Clear();
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFoodName.Text))
                    throw new Exception("Tên món không được để trống!");

                if (!int.TryParse(txtPrice.Text, out int price))
                    throw new Exception("Giá phải là số!");

                var req = new AddFoodRequest
                {
                    TenMon = txtFoodName.Text.Trim(),
                    Gia = price,
                    DiaChi = txtAddress.Text.Trim(),
                    HinhAnh = txtImageUrl.Text.Trim(),
                    MoTa = txtDescription.Text.Trim()
                };

                await ApiClient.AddFoodAsync(req, _token);

                MessageBox.Show("Thêm món ăn thành công!");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm món ăn:\n" + ex.Message);
            }
        }
    }
}
