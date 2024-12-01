using QLVPP_Project.Dao;
using QLVPP_Project.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVPP_Project.GUI.admin
{
    public partial class FrmTrangChu : Form
    {
        private int selectedRowIndex = -1;
        public FrmTrangChu()
        {
            InitializeComponent();
            dataTableGridViewProduct(ProductDao.Instance.getAll());
            dataCbbCategory();
        }
        // DataTable Product
        private void dataTableGridViewProduct(DataTable data)
        {
            dtgrvProduct.DataSource = null;
            dtgrvProduct.DataSource = data;
        }
        // DataCbb Category
        private void dataCbbCategory()
        {
            DataTable data = CategoryDao.Instance.getAll();
            cbbCategory.DataSource = data;
            cbbCategory.DisplayMember = "CategoryName";
            cbbCategory.ValueMember = "CategoryId";
        }

        private void btnQLSP_Click(object sender, EventArgs e)
        {
            panelQLSP.BringToFront();
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            panelQLTK.BringToFront();
        }

        private void btnBCTK_Click(object sender, EventArgs e)
        {
            panelBCTK.BringToFront();
        }

        // Insert Product
        private void btnInsertProduct_Click(object sender, EventArgs e)
        {
            string proName = txtProductName.Text;
            string descrip = rtxtDescription.Text;
            double price = Convert.ToDouble(txtPrice.Text);
            string unit = txtUnit.Text;
            string imgUrl = txtImgUrl.Text;
            int cateId = Convert.ToInt32(cbbCategory.SelectedValue);

            Product newPro = new Product(proName, descrip, price, unit, imgUrl, cateId);

            if (ProductDao.Instance.Insert(newPro))
            {
                MessageBox.Show("Insert Product Success");
                dataTableGridViewProduct(ProductDao.Instance.getAll());
            }
            else
                MessageBox.Show("Insert Product Fail");

        }
        // Bind vào các trường dữ liệu
        private void dtgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgrvProduct.Rows[e.RowIndex];
                selectedRowIndex = e.RowIndex;
                txtProductName.Text = row.Cells["ProductName"].Value?.ToString() ?? "";
                rtxtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
                txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "";
                txtUnit.Text = row.Cells["Unit"].Value?.ToString() ?? "";
                txtImgUrl.Text = row.Cells["ImgUrl"].Value.ToString() ?? "";

                cbbCategory.SelectedValue = row.Cells["CategoryId"].Value ?? 0;

            }
        }
        // Update Product
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if(selectedRowIndex == -1)
            {
                MessageBox.Show("Vui chọn sản phẩm từ bảng để cập nhật");
                return;
            }
            DataGridViewRow row = dtgrvProduct.Rows[selectedRowIndex];
            int proId = Convert.ToInt32(row.Cells["ProductId"].Value);

            string proName = txtProductName.Text;
            string descrip = rtxtDescription.Text;
            double price = Convert.ToDouble(txtPrice.Text);
            string unit = txtUnit.Text;
            string imgUrl = txtImgUrl.Text;
            int cateId = Convert.ToInt32(cbbCategory.SelectedValue);
            Product updatePro = new Product(proId,proName,descrip,price,unit,imgUrl,cateId);
            if(ProductDao.Instance.Update(updatePro))
            {
                MessageBox.Show("Update Product Success");
                dataTableGridViewProduct(ProductDao.Instance.getAll());
            }
            else
                MessageBox.Show("Update Product Fail");

        }
        // Delete Product
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex == -1)
            {
                MessageBox.Show("Vui chọn sản phẩm từ bảng để xóa");
                return;
            }
            
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa sản phẩm này ko ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes) {
                DataGridViewRow row = dtgrvProduct.Rows[selectedRowIndex];
                int proId = Convert.ToInt32(row.Cells["ProductId"].Value);

                if (ProductDao.Instance.Delete(proId)) 
                { 
                    MessageBox.Show("Delete Product Success");
                    dataTableGridViewProduct(ProductDao.Instance.getAll());
                }
                else
                    MessageBox.Show("Delete Product Fail");
            }
        }

        // Insert n Product - DataTable from ImportExcel

        private void insertAllDataTable(DataTable dataExcel)
        {
            if (dataExcel.Rows.Count > 0)
            {
                foreach (DataRow row in dataExcel.Rows) 
                { 
                    string proName = row["ProductName"].ToString();
                    string descrip = row["Description"].ToString();
                    double price = Convert.ToDouble(row["Price"]);
                    string unit = row["Unit"].ToString();
                    string imgUrl = row["ImgUrl"].ToString();
                    int cateId = Convert.ToInt32(row["CategoryId"]);

                    Product newPro = new Product(proName, descrip, price, unit, imgUrl, cateId);
                    bool rs = ProductDao.Instance.Insert(newPro);
                    if (!rs) {
                        MessageBox.Show("Insert Product Fail At : "+proName);

                    }

                }
                MessageBox.Show("Insert Product All Success");
            }
            else
                MessageBox.Show("No data to insert. Please import the Excel file first.");
        }



        // Import Excel Product
        private void btnImportExcelProduct_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                DataTable dataExcel = new ModelExcel().ImportExcel(filePath);
                insertAllDataTable(dataExcel);

                dataTableGridViewProduct(ProductDao.Instance.getAll());
            }
        }



        // Export Excel Product
        private void btnExportExcelProduct_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*xlsx)|*.xlsx";
            saveFileDialog.Title = "Save Excel Product File";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = saveFileDialog.FileName;
                new ModelExcel().ExportExcel(ProductDao.Instance.getAll(), filepath);
                MessageBox.Show("Export Product Excel Success");
            }
        }
        // Tìm kiếm sản phẩm theo tên và giá 
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string proNameToFind = TxtProNameFind.Text;
            double fromPrice = 0;
            double toPrice = 0;
            if (!string.IsNullOrEmpty(TxtFromPrice.Text) && !double.TryParse(TxtFromPrice.Text, out fromPrice))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ cho giá từ.");
                return; 
            }
            if (!string.IsNullOrEmpty(TxtToPrice.Text) && !double.TryParse(TxtToPrice.Text, out toPrice))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ cho giá đến.");
                return; 
            }

            DataTable findDataTable = ProductDao.Instance.searchByNameAndPrice(proNameToFind, fromPrice, toPrice);
            dataTableGridViewProduct(findDataTable);


        }
    }
}
