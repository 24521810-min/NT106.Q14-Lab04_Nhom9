using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bai07
{
    public partial class FrmSignup : Form
    {
        public string RegisteredUsername { get; private set; }

        public FrmSignup()
        {
            InitializeComponent();

            btnSubmit.Click += btnSubmit_Click_1;
            btnClear.Click += btnClear_Click_1;

            if (cboLanguage.Items.Count > 0)
                cboLanguage.SelectedIndex = 0;  
        }

        // HÀM KIỂM TRA DỮ LIỆU
        private bool ValidateInput()
        {
            // USERNAME 
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập Username!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Username chỉ cho phép chữ, số, gạch dưới
            if (!Regex.IsMatch(txtUsername.Text.Trim(), @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Username chỉ được chứa chữ, số và dấu gạch dưới (_).",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // PASSWORD 
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải từ 6 ký tự trở lên!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // EMAIL
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập Email!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // PHONE
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            // Số điện thoại phải đúng 10 chữ số, không có chữ cái
            if (!Regex.IsMatch(phone, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số và không chứa chữ cái!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            return true; // tất cả đều ok
        }

        // ================== NÚT CLEAR ==================
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtFirstname.Clear();
            txtLastname.Clear();
            txtPhone.Clear();
            dtpBirthday.Value = DateTime.Today;
            radMale.Checked = true;
            if (cboLanguage.Items.Count > 0)
                cboLanguage.SelectedIndex = 0;
        }

        // ================== NÚT SUBMIT (ĐĂNG KÝ) ==================
        private async void btnSubmit_Click_1(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu trước
            if (!ValidateInput())
                return;

            // 2. Nếu hợp lệ thì mới lấy dữ liệu và gọi API
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Tạm quy ước: 1 = Nam, 2 = Nữ
            int sexValue = radMale.Checked ? 1 : 2;

            var req = new SignupRequest
            {
                Username = username,
                Password = password,
                Email = email,
                FirstName = txtFirstname.Text.Trim(),
                LastName = txtLastname.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Language = cboLanguage.SelectedItem?.ToString(),   
                Sex = sexValue,
                Birthday = dtpBirthday.Value.ToString("yyyy-MM-dd")
            };

            btnSubmit.Enabled = false;
            try
            {
                await ApiClient.SignupAsync(req);

                MessageBox.Show("Đăng ký thành công! Hãy quay lại màn hình đăng nhập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RegisteredUsername = username;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSubmit.Enabled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}
