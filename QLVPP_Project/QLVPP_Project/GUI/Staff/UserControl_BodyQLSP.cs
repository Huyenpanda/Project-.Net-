using QLVPP_Project.Dao;
using QLVPP_Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QLVPP_Project.GUI.Staff;
using System.Drawing;

namespace QLVPP_Project
{
    public partial class UserControl_BodyQLSP : UserControl
    {
        ProductDao productDao = new ProductDao();
        bool isChecked = false;
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
        private void InitializeControls()
        { // Initially enable all controls
          EnableAllControls(); SetForeColor(); 
        }
        private void EnableAllControls()
        {
            labelTenSP.Enabled = true; 
            textBoxTenSP.Enabled = true; 
            labelMaSP.Enabled = true; 
            textBoxMaSP.Enabled = true; 
            labelGiaTu.Enabled = true; 
            textBoxGiaTu.Enabled = true; 
            labelGiaDen.Enabled = true; 
            textBoxGiaDen.Enabled = true;
        }

            private void buttonThem_Click(object sender, EventArgs e)
        {
            // Hiển thị FormThemSP với thông tin sản phẩm cần sửa
            FormThemSP formThemSP = new FormThemSP();
            formThemSP.ShowDialog();
            LoadData(); // Tải lại dữ liệu sau khi chỉnh sửa
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            if (dataGridViewQLSP.SelectedRows.Count == 1)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dataGridViewQLSP.SelectedRows[0];

                // Tạo đối tượng Product từ thông tin dòng được chọn
                Product selectedProduct = new Product
                {
                    ProductId = Convert.ToInt32(selectedRow.Cells["ProductId"].Value),
                    ProductName = selectedRow.Cells["ProductName"].Value.ToString(),
                    Price = Convert.ToDouble(selectedRow.Cells["Price"].Value),
                    Unit = selectedRow.Cells["Unit"].Value.ToString(),
                    Description = selectedRow.Cells["Description"].Value.ToString(),
                    CategoryId = CategoryDao.Instance.GetCategoryIdByName(selectedRow.Cells["CategoryName"].Value.ToString())
                };

                // Hiển thị FormThemSP với thông tin sản phẩm
                FormThemSP formThemSP = new FormThemSP(selectedProduct);
                formThemSP.ShowDialog();

                // Tải lại dữ liệu sau khi sửa
                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            string productName = textBoxTenSP.Text.Trim(); 
            int.TryParse(textBoxMaSP.Text.Trim(), out int productId); 
            double.TryParse(textBoxGiaTu.Text, out double fromPrice); 
            double.TryParse(textBoxGiaDen.Text, out double toPrice); 
            DataTable searchResult = ProductDao.Instance.searchByCriteria(productName, productId, fromPrice, toPrice); 
            dataGridViewQLSP.DataSource = searchResult;
            
            if (radioButtonTheoGia.Checked)
            {
                // Validate price inputs
                if (double.TryParse(textBoxGiaTu.Text, out  fromPrice) &&
                    double.TryParse(textBoxGiaDen.Text, out  toPrice))
                {
                    if (fromPrice >= 0 && toPrice >= fromPrice && fromPrice <= toPrice)
                    {
                        // Search by price range
                         searchResult = ProductDao.Instance.searchByNameAndPrice(null, fromPrice, toPrice);
                        dataGridViewQLSP.DataSource = searchResult;
                    }
                    else
                    {
                        MessageBox.Show("Giá từ phải nhỏ hơn hoặc bằng giá đến.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập giá trị hợp lệ cho khoảng giá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (radioButtonTheoTen.Checked)
            {
                productName = textBoxTenSP.Text.Trim();
                if (!string.IsNullOrEmpty(productName))
                {
                    searchResult = ProductDao.Instance.searchByNameAndPrice(productName, 0, 0); 
                    dataGridViewQLSP.DataSource = searchResult;
                }
                else { 
                    MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            } else
            {

            }    
        }




        private void UserControl_BodyQLSP_Load(object sender, EventArgs e)
        {

        }


        private void radioButtonTatCa_CheckedChanged(object sender, EventArgs e)
        {
            EnableAllControls();
            SetForeColor();
            LoadData();
        }
        private void radioButtonTheoTen_CheckedChanged_1(object sender, EventArgs e)
        {
            isChecked = radioButtonTheoTen.Checked;

            // Enable/Disable controls based on the radio button state
            labelTenSP.Enabled = isChecked;
            textBoxTenSP.Enabled = isChecked;
            labelMaSP.Enabled = !isChecked;
            textBoxMaSP.Enabled = !isChecked;

            labelGiaTu.Enabled = !isChecked;
            textBoxGiaTu.Enabled = !isChecked;
            labelGiaDen.Enabled = !isChecked;
            textBoxGiaDen.Enabled = !isChecked;

            SetForeColor();
        }

        private void radioButtonTheoGia_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = radioButtonTheoGia.Checked;

            // Enable/Disable controls based on the radio button state
            labelTenSP.Enabled = !isChecked;
            textBoxTenSP.Enabled = !isChecked;
            labelMaSP.Enabled = !isChecked;
            textBoxMaSP.Enabled = !isChecked;

            labelGiaTu.Enabled = isChecked;
            textBoxGiaTu.Enabled = isChecked;
            labelGiaDen.Enabled = isChecked;
            textBoxGiaDen.Enabled = isChecked;

            SetForeColor();
        }

        private void radioButtonTheoMa_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = radioButtonTheoMa.Checked;

            // Enable/Disable controls based on the radio button state
            labelTenSP.Enabled = !isChecked;
            textBoxTenSP.Enabled = !isChecked;
            labelMaSP.Enabled = isChecked;
            textBoxMaSP.Enabled = isChecked;

            labelGiaTu.Enabled = !isChecked;
            textBoxGiaTu.Enabled = !isChecked;
            labelGiaDen.Enabled = !isChecked;
            textBoxGiaDen.Enabled = !isChecked;

            SetForeColor();
        }

        private void radioButtonLoc_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = radioButtonLoc.Checked;
            EnableAllControls();
            SetForeColor();

        }

        private void SetForeColor()
        {
            // Set text color based on the enabled state of the controls
            labelTenSP.ForeColor = textBoxTenSP.Enabled ? Color.Black : Color.Gray;
            textBoxTenSP.ForeColor = textBoxTenSP.Enabled ? Color.Black : Color.Gray;
            labelMaSP.ForeColor = textBoxMaSP.Enabled ? Color.Black : Color.Gray;
            textBoxMaSP.ForeColor = textBoxMaSP.Enabled ? Color.Black : Color.Gray;
            labelGiaTu.ForeColor = textBoxGiaTu.Enabled ? Color.Black : Color.Gray;
            textBoxGiaTu.ForeColor = textBoxGiaTu.Enabled ? Color.Black : Color.Gray;
            labelGiaDen.ForeColor = textBoxGiaDen.Enabled ? Color.Black : Color.Gray;
            textBoxGiaDen.ForeColor = textBoxGiaDen.Enabled ? Color.Black : Color.Gray;
        }


    }
}
