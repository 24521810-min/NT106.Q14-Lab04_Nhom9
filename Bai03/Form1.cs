using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace Bai03
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _http = new HttpClient();

        public Form1()
        {
            InitializeComponent();

            // Gắn event
            this.Load += Form1_Load;
            btnGo.Click += BtnGo_Click;
            btnReload.Click += BtnReload_Click;
            btnDownHtml.Click += BtnDownHtml_Click;
            btnDownResources.Click += BtnDownResources_Click;
        }

        // ================== HÀM HỖ TRỢ ==================

        // Chuẩn hoá URL: nếu không có http/https thì tự thêm
        private string NormalizeUrl(string url)
        {
            url = (url ?? "").Trim();

            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = "https://" + url;
            }

            return url;
        }

        private string MakeAbsoluteUrl(string baseUrl, string resourceUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(resourceUrl))
                    return null;

                Uri baseUri = new Uri(baseUrl);
                Uri fullUri = new Uri(baseUri, resourceUrl);
                return fullUri.ToString();
            }
            catch
            {
                return null;
            }
        }

        // ================== EVENT HANDLERS ==================

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                await webView2.EnsureCoreWebView2Async(null);
                txtUrl.Text = "https://uit.edu.vn";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo WebView2: " + ex.Message);
            }
        }

        // Nút Load: load website vào WebView2
        private void BtnGo_Click(object sender, EventArgs e)
        {
            try
            {
                string url = NormalizeUrl(txtUrl.Text);
                txtUrl.Text = url; 

                webView2.Source = new Uri(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("URL không hợp lệ: " + ex.Message);
            }
        }

        // Nút reload
        private void BtnReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (webView2.CoreWebView2 != null)
                {
                    webView2.CoreWebView2.Reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message);
            }
        }

        // Nút Down Files: download HTML của trang hiện tại
        private async void BtnDownHtml_Click(object sender, EventArgs e)
        {
            try
            {
                string url = NormalizeUrl(txtUrl.Text);

                // 1. Lấy HTML từ server
                string html = await _http.GetStringAsync(url);

                // 2. Chọn nơi lưu
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "HTML file (*.html)|*.html|All files (*.*)|*.*";
                    sfd.FileName = "page.html";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, html);
                        MessageBox.Show("Đã lưu HTML vào:\n" + sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải HTML: " + ex.Message);
            }
        }

        // Nút Down Resources: tải các hình ảnh trên website
        private async void BtnDownResources_Click(object sender, EventArgs e)
        {
            try
            {
                string url = NormalizeUrl(txtUrl.Text);

                // 1. Tải HTML về
                string html = await _http.GetStringAsync(url);

                // 2. Phân tích HTML bằng HtmlAgilityPack
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                // Lấy tất cả thẻ <img src="...">
                var imgNodes = doc.DocumentNode.SelectNodes("//img[@src]");

                if (imgNodes == null || imgNodes.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hình ảnh nào để tải.");
                    return;
                }

                // 3. Chọn thư mục lưu resource
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Chọn thư mục để lưu hình ảnh";

                    if (fbd.ShowDialog() != DialogResult.OK)
                        return;

                    string folder = fbd.SelectedPath;
                    int count = 0;

                    // 4. Lần lượt tải từng hình
                    foreach (var node in imgNodes)
                    {
                        string src = node.GetAttributeValue("src", null);
                        string fullUrl = MakeAbsoluteUrl(url, src);

                        if (string.IsNullOrEmpty(fullUrl))
                            continue;

                        try
                        {
                            byte[] data = await _http.GetByteArrayAsync(fullUrl);

                            // Lấy tên file từ URL
                            string fileName = Path.GetFileName(new Uri(fullUrl).LocalPath);
                            if (string.IsNullOrWhiteSpace(fileName))
                                fileName = "image_" + count + ".jpg";

                            string savePath = Path.Combine(folder, fileName);

                            File.WriteAllBytes(savePath, data);
                            count++;
                        }
                        catch
                        {
                            // Nếu 1 file lỗi thì bỏ qua, không crash chương trình
                        }
                    }

                    MessageBox.Show($"Đã tải xong {count} hình ảnh vào thư mục:\n{folder}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải resource: " + ex.Message);
            }
        }

        private void btnGo_Click_1(object sender, EventArgs e)
        {

        }
    }
}
