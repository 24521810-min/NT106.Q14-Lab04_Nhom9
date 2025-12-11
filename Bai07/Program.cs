using System;
using System.Windows.Forms;

namespace Bai07
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (FrmLogin login = new FrmLogin())
            {
                // Nếu login đóng mà không đăng nhập thành công → thoát
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Mở MainForm
                    Application.Run(new FrmMain(Session.AccessToken));

                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
