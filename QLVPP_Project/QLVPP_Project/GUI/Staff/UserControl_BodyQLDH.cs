using System;
using System.Windows.Forms;
using QLVPP_Project.Dao;

namespace QLVPP_Project
{
    public partial class UserControl_BodyQLDH : UserControl
    {
        OrderDao orderDao = new OrderDao();

        public UserControl_BodyQLDH()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridViewQLDH.DataSource = OrderDao.Instance.getAll();

                // Cấu hình hiển thị cho các cột
                dataGridViewQLDH.Columns["OrderId"].HeaderText = "OrderId";
                dataGridViewQLDH.Columns["CreateDate"].HeaderText = "CreateDate";
                dataGridViewQLDH.Columns["Username"].HeaderText = "Username";
                dataGridViewQLDH.Columns["Status"].HeaderText = "Status";
                dataGridViewQLDH.Columns["Total"].HeaderText = "Total";

                // Đặt kích thước cho các cột
                dataGridViewQLDH.Columns["OrderId"].Width = 80;
                dataGridViewQLDH.Columns["CreateDate"].Width = 150;
                dataGridViewQLDH.Columns["Username"].Width = 150;
                dataGridViewQLDH.Columns["Status"].Width = 80;
                dataGridViewQLDH.Columns["Total"].Width = 100;

                // Căn giữa tên các cột
                foreach (DataGridViewColumn column in dataGridViewQLDH.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Căn giữa nội dung các cột
                dataGridViewQLDH.Columns["OrderId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewQLDH.Columns["CreateDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewQLDH.Columns["Username"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewQLDH.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewQLDH.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
