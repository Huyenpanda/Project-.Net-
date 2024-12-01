using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLVPP_Project
{
    public partial class UserControl_SideBar : UserControl
    {
        private static List<Form> openForms = new List<Form>();

        public UserControl_SideBar()
        {
            InitializeComponent();
        }


        private void buttonQuanLySanPham_Click(object sender, EventArgs e)
        {
            if (FormQuanLySanPham.IsFormOpen)
            {
                // Nếu form đã mở, đưa form lên phía trước
                FormQuanLySanPham.Instance.BringToFront();
            }
            else
            {
                // Nếu chưa mở, tạo và hiển thị form mới
                FormQuanLySanPham formQuanLySanPham = new FormQuanLySanPham();
                formQuanLySanPham.Show();
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
