using QuanLyThuVien.frm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool userIsLoggedIn = false;

            if (userIsLoggedIn)
            {
                Application.Run(new frmMain());
            }
            else
            {
                frmMain mainForm = new frmMain();
                mainForm.OpenLoginForm();
                Application.Run(mainForm);
            }
        }

    }
}