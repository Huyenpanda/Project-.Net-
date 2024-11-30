using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVPP_Project
{
    public partial class FormQuanLySanPham : Form
    {
        public static bool IsFormOpen { get; private set; } = false;
        public static FormQuanLySanPham Instance { get; private set; }
        public FormQuanLySanPham()
        {
            InitializeComponent();
            Instance = this;
            IsFormOpen = true;
            this.FormClosed += (s, args) => IsFormOpen = false;

            // Cấu hình Form không cho phóng to
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            InitializeUserControls();
        }

        private void InitializeUserControls()
        {
            // Sử dụng SplitContainer để chia vùng cho SideBar và Main
            SplitContainer splitContainer = new SplitContainer();
            splitContainer.Dock = DockStyle.Fill;

            // Thiết lập kích thước tối thiểu cho hai panel
            splitContainer.Panel1MinSize = 300; // Chiều rộng tối thiểu của SideBar
            splitContainer.Panel2MinSize = 50; // Chiều rộng tối thiểu của Header + Body
            splitContainer.SplitterWidth = 1;   // Chiều rộng của splitter
            splitContainer.FixedPanel = FixedPanel.Panel1;

            // Xử lý sự kiện Load để đảm bảo kích thước chính xác
            this.Load += (sender, e) =>
            {
                // Đảm bảo chiều rộng form đủ lớn
                if (this.ClientSize.Width < splitContainer.Panel1MinSize + splitContainer.Panel2MinSize)
                {
                    MessageBox.Show(
                        $"Form cần chiều rộng tối thiểu {splitContainer.Panel1MinSize + splitContainer.Panel2MinSize}px để hiển thị đúng.",
                        "Lỗi kích thước",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Đặt SplitterDistance hợp lệ
                splitContainer.SplitterDistance = splitContainer.Panel1MinSize;
            };

            // Thêm UserControl_SideBar vào Panel1
            UserControl_SideBar sideBar = new UserControl_SideBar();
            sideBar.Dock = DockStyle.Fill;
            splitContainer.Panel1.Controls.Add(sideBar);

            // Tạo TableLayoutPanel cho vùng Header và Body
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F)); // Header cố định 60px
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Body chiếm phần còn lại

            // Thêm UserControl_HeaderQLSP vào TableLayoutPanel
            UserControl_HeaderQLSP headerQLSP = new UserControl_HeaderQLSP();
            headerQLSP.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(headerQLSP, 0, 0);

            // Thêm UserControl_BodyQLSP vào TableLayoutPanel
            UserControl_BodyQLSP bodyQLSP = new UserControl_BodyQLSP();
            bodyQLSP.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(bodyQLSP, 0, 1);

            // Thêm TableLayoutPanel vào Panel2 của SplitContainer
            splitContainer.Panel2.Controls.Add(tableLayoutPanel);

            // Thêm SplitContainer vào Form
            this.Controls.Add(splitContainer);
        }



    }

}
