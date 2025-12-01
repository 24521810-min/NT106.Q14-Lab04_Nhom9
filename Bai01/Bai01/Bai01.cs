using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Bai01 : Form
    {
        public Bai01()
        {
            InitializeComponent();
            button_get.Click += button_get_Click;
        }

        private string getHTML(string szURL)
        {
            try
            {
                WebRequest request = WebRequest.Create(szURL);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return responseFromServer;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        private void button_get_Click(object sender, EventArgs e)
        {
            string url = textBox_link.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL!");
                return;
            }

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "http://" + url;

            string html = getHTML(url);
            richTextBox_nd.Text = html;
        }
    }
}
