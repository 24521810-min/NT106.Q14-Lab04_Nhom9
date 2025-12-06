using System;
using System.Windows.Forms;

namespace BAI04
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());   // <-- FORM CHÍNH Ở ĐÂY
        }
    }
}
