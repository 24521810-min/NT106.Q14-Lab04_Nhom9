using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Bai02 : Form
    {
        public Bai02()
        {
            InitializeComponent();
        }


        private void btnDownload_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            string filePath = txtSavePath.Text;

            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("Vui lòng nhập URL và đường dẫn lưu file!");
                return;
            }

            try
            {
                WebClient myClient = new WebClient();

                Stream response = myClient.OpenRead(url);
                StreamReader reader = new StreamReader(response);
                string htmlContent = reader.ReadToEnd();

                File.WriteAllText(filePath, htmlContent);

                rtbContent.Text = htmlContent;

                //myClient.DownloadFile(url, filePath);

                reader.Close();
                response.Close();

                MessageBox.Show("Download thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
