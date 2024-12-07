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
                dataGridViewQLDH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Tuỳ chọn: Căn chỉnh nội dung cột nếu cần
                foreach (DataGridViewColumn column in dataGridViewQLDH.Columns)
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

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
            if (dataGridViewQLDH.SelectedRows.Count > 0)
            {
                int selectedOrderId = Convert.ToInt32(dataGridViewQLDH.SelectedRows[0].Cells["OrderId"].Value);
                FormCapNhatHoaDon formCapNhatHoaDon = new FormCapNhatHoaDon(true, selectedOrderId);
                formCapNhatHoaDon.ShowDialog();
                LoadData(); // Tải lại dữ liệu sau khi chỉnh sửa
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void buttonLamMoiHD_Click(object sender, EventArgs e)
        {
            LoadData(); // Tải lại dữ liệu 
        }

        private void buttonXemChiTietHD_Click(object sender, EventArgs e)
        {
            if (dataGridViewQLDH.SelectedRows.Count > 0)
            {
                int orderId = (int)dataGridViewQLDH.SelectedRows[0].Cells["OrderId"].Value;
                FormChiTietHoaDon formChiTietHoaDon = new FormChiTietHoaDon(orderId);
                formChiTietHoaDon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order to view details.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
