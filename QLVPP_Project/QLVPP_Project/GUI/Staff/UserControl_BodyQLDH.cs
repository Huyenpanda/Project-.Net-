using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLVPP_Project.Dao;
using QLVPP_Project.GUI.Staff;

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
                dataGridViewQLDH.Columns["OrderId"].Width = 100;
                dataGridViewQLDH.Columns["CreateDate"].Width = 150;
                dataGridViewQLDH.Columns["Username"].Width = 150;
                dataGridViewQLDH.Columns["Status"].Width = 80;
                dataGridViewQLDH.Columns["Total"].Width = 150;

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

        private void buttonThemHD_Click(object sender, EventArgs e)
        {
            // Hiển thị FormThemSP với thông tin sản phẩm cần sửa
            FormCapNhatHoaDon formCapNhatHoaDon = new FormCapNhatHoaDon();
            formCapNhatHoaDon.ShowDialog();
            LoadData(); // Tải lại dữ liệu sau khi chỉnh sửa
        }
        private void buttonSuaHD_Click(object sender, EventArgs e)
        {
            // Hiển thị FormThemSP với thông tin sản phẩm cần sửa
            FormCapNhatHoaDon formCapNhatHoaDon = new FormCapNhatHoaDon();
            formCapNhatHoaDon.ShowDialog();
            LoadData(); // Tải lại dữ liệu sau khi chỉnh sửa
        }

        private void buttonXoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách OrderId từ các dòng được chọn
                List<int> selectedOrderIds = new List<int>();
                foreach (DataGridViewRow row in dataGridViewQLDH.SelectedRows)
                {
                    if (row.Cells["OrderId"].Value != null)
                    {
                        selectedOrderIds.Add(Convert.ToInt32(row.Cells["OrderId"].Value));
                    }
                }

                if (selectedOrderIds.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị xác nhận
                DialogResult dialogResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa các đơn hàng đã chọn không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {
                    // Xóa các đơn hàng trong cơ sở dữ liệu
                    bool isDeleted = OrderDao.Instance.DeleteOrders(selectedOrderIds);

                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Tải lại dữ liệu sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
