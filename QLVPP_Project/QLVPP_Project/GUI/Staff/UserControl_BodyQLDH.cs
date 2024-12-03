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
    public partial class UserControl_BodyQLDH : UserControl
    {
        ProductDao productDao = new ProductDao();
        
        public UserControl_BodyQLDH()
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
     
    }
}
