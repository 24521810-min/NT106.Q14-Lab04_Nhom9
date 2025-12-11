using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bai07
{
    public partial class FrmAddFood : Form
    {
        private readonly string _token;

        // Lưu đường dẫn ảnh người dùng chọn
        private string _localImagePath = "";

        public FrmAddFood(string token)
        {
            InitializeComponent();
            _token = token;

            btnAdd.Click += BtnAdd_Click;
            btnClear.Click += BtnClear_Click;
            btnChooseImage.Click += BtnChooseImage_Click_1;
        }

        // ==============================
        // CLEAR FORM
        // ==============================
        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtFoodName.Clear();
            txtPrice.Clear();
            txtAddress.Clear();
            txtImageUrl.Clear();
            txtDescription.Clear();
            _localImagePath = "";
        }

        // ==============================
        // CHỌN ẢNH TỪ MÁY
        // ==============================
        private void BtnChooseImage_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _localImagePath = ofd.FileName;
                    txtImageUrl.Text = _localImagePath;
                }
            }
        }

        // ==============================
        // NÚT "THÊM MÓN"
        // ==============================
        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // ==== Validate dữ liệu ====
                if (string.IsNullOrWhiteSpace(txtFoodName.Text))
                    throw new Exception("Tên món không được để trống!");

                if (!double.TryParse(txtPrice.Text, out double price))
                    throw new Exception("Giá phải là số!");

                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                    throw new Exception("Địa chỉ không được để trống!");

                if (string.IsNullOrWhiteSpace(txtImageUrl.Text))
                    throw new Exception("Bạn phải chọn hoặc nhập đường dẫn hình!");

                // ==== COPY ẢNH NẾU LÀ ẢNH LOCAL ====
                string finalImagePath = txtImageUrl.Text.Trim();

                if (File.Exists(_localImagePath))
                {
                    string folder = Application.StartupPath + @"\Images\";

                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    string fileName = Guid.NewGuid().ToString() +
                                      Path.GetExtension(_localImagePath);

                    finalImagePath = Path.Combine(folder, fileName);

                    File.Copy(_localImagePath, finalImagePath, true);
                }

                // ==== TẠO REQUEST ====
                var req = new AddFoodRequest
                {
                    TenMon = txtFoodName.Text.Trim(),
                    Gia = price,
                    DiaChi = txtAddress.Text.Trim(),
                    HinhAnh = finalImagePath,  
                    MoTa = txtDescription.Text.Trim()
                };

                // ==== GỌI API ====
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
