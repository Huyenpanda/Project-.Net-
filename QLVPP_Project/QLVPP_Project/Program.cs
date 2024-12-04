using QLVPP_Project.GUI.admin;
using QLVPP_Project.GUI.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVPP_Project
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
            Application.Run(new FormQuanLySanPham());
            //Application.Run(new FrmLogin());
            //Application.Run(new FrmTrangChu());
            //Application.Run(new FormCapNhatHoaDon());
        }
    }
}
