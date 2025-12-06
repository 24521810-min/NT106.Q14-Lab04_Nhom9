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

            // Chạy form đăng ký trước
            using (var signup = new FrmLogin())
            {
                signup.ShowDialog(); // chờ đăng ký xong
            }

         
        }
    }
}
