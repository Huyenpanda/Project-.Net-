using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVPP_Project
{
    public partial class UserControl_HeaderQLSP : UserControl
    {
        public UserControl_HeaderQLSP()
        {
            InitializeComponent();

            // Tạo TableLayoutPanel
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Đặt Label vào TableLayoutPanel
            tableLayoutPanel.Controls.Add(labelQLSP, 0, 0);
            labelQLSP.Anchor = AnchorStyles.None;

            // Đặt TableLayoutPanel vào UserControl
            this.Controls.Add(tableLayoutPanel);
        }
    }


}
