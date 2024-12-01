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
                List<Product> products = productDao.getAll();
                DataTable productTable = productDao.ConvertToDataTable(products);
                dataGridViewQLSP.DataSource = productTable;

                // Set DataGridView columns
                dataGridViewQLSP.Columns["ProductName"].HeaderText = "Tên Sản Phẩm";
                dataGridViewQLSP.Columns["Price"].HeaderText = "Giá";
                dataGridViewQLSP.Columns["Unit"].HeaderText = "Đơn vị";
                dataGridViewQLSP.Columns["CategoryName"].HeaderText = "Loại Sản Phẩm";
                dataGridViewQLSP.Columns["Description"].HeaderText = "Mô Tả";
                
                // Adjust column widths
                dataGridViewQLSP.Columns["ProductName"].Width = 180;
                dataGridViewQLSP.Columns["Price"].Width = 50;
                dataGridViewQLSP.Columns["Unit"].Width = 80;
                dataGridViewQLSP.Columns["CategoryName"].Width = 150;
                dataGridViewQLSP.Columns["Description"].Width = 250;
                // Center align column headers
                foreach (DataGridViewColumn column in dataGridViewQLSP.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Center align specific columns' content
                dataGridViewQLSP.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewQLSP.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewQLSP.Columns["CategoryName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            }
            catch (Exception ex)
            {
                string errorMessage = $"Error in {nameof(ProductDao)}.{nameof(ProductDao.getAll)}: {ex.Message}\nStack Trace:\n{ex.StackTrace}";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
