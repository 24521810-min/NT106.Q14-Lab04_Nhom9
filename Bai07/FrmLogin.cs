using System;
using System.Windows.Forms;

namespace Bai07
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            btnLogin.Click += btnLogin_Click_1;
            lnkSigup.LinkClicked += LnkSigup_LinkClicked;
        }

        private void LnkSigup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var f = new FrmSignup())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(f.RegisteredUsername))
                    {
                        txtUsername.Text = f.RegisteredUsername;
                        txtPassword.Focus();
                    }
                }
            }
        }

        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            btnLogin.Enabled = false;

            try
            {
                var login = await ApiClient.LoginAsync(username, password);

                Session.AccessToken = login.AccessToken;
                Session.Username = username;


                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;  // ⭐ QUAN TRỌNG
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }


        private void lblTitle_Click(object sender, EventArgs e)
        {
        }

        private void lnkSigup_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            using (var f = new FrmSignup())
            {
                f.ShowDialog();  
            }
            this.Show();
        }
    }
}
