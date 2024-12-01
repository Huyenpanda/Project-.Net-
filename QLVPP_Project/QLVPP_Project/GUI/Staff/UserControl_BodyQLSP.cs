using QLVPP_Project.Dao;
using QLVPP_Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QLVPP_Project
{
    public partial class UserControl_BodyQLSP : UserControl
    {
        ProductDao productDao = new ProductDao();

        public UserControl_BodyQLSP()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {


                dataGridViewQLSP.DataSource = ProductDao.Instance.getAllAndCategoryName();
                //dataGridViewQLSP.DataSource = productTable;
                // Cấu hình hiển thị cho các cột
                dataGridViewQLSP.Columns["ProductId"].HeaderText = "ProductId";
                dataGridViewQLSP.Columns["ProductName"].HeaderText = "ProductName";
                dataGridViewQLSP.Columns["Price"].HeaderText = "Price";
                dataGridViewQLSP.Columns["Unit"].HeaderText = "Unit";
                dataGridViewQLSP.Columns["CategoryName"].HeaderText = "CategoryName";
                dataGridViewQLSP.Columns["Description"].HeaderText = "Description";

                // Đặt kích thước cho các cột
                dataGridViewQLSP.Columns["ProductId"].Width = 80;
                dataGridViewQLSP.Columns["ProductName"].Width = 150;
                dataGridViewQLSP.Columns["Price"].Width = 50;
                dataGridViewQLSP.Columns["Unit"].Width = 100;
                dataGridViewQLSP.Columns["CategoryName"].Width = 150;
                dataGridViewQLSP.Columns["Description"].Width = 250;
                // Căn giữa tên các cột
                foreach (DataGridViewColumn column in dataGridViewQLSP.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Căn giữa nội dung các cột Giá, Đơn Vị và Loại Sản Phẩm
                dataGridViewQLSP.Columns["ProductId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewQLSP.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewQLSP.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                /*dataGridViewQLSP.Columns["CategoryName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;*/

            }
            catch (Exception ex)
            {
                string errorMessage = $"Error in {nameof(ProductDao)}.{nameof(ProductDao.getAll)}: {ex.Message}\nStack Trace:\n{ex.StackTrace}";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void buttonThem_Click(object sender, EventArgs e)
        {

        }

        private void buttonSua_Click(object sender, EventArgs e)
        {

        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewQLSP.SelectedRows.Count > 0)
            {
                // Lấy ProductId của hàng được chọn
                int selectedRowIndex = dataGridViewQLSP.SelectedRows[0].Index;
                int productId = Convert.ToInt32(dataGridViewQLSP.Rows[selectedRowIndex].Cells["ProductId"].Value);

                // Hiển thị hộp thoại xác nhận
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Xóa sản phẩm khỏi cơ sở dữ liệu
                    bool isDeleted = productDao.Delete(productId);
                    if (isDeleted)
                    {
                        // Xóa hàng từ DataGridView
                        dataGridViewQLSP.Rows.RemoveAt(selectedRowIndex);
                        MessageBox.Show("Sản phẩm đã được xóa thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
