using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLVPP_Project.Dao;
using QLVPP_Project.Model;

namespace QLVPP_Project.GUI.Staff
{
    public partial class FormThemSP : Form
    {
        private bool isEditing;
        private Product currentProduct;
        public FormThemSP(Product product = null)
        {
            InitializeComponent();
            LoadCategoryNames(); // Tải danh sách loại sản phẩm

            if (product != null)
            {
                // Chế độ chỉnh sửa
                isEditing = true;
                currentProduct = product;

                labelThemSP.Text = "Sửa thông tin Sản Phẩm";

                // Hiển thị thông tin sản phẩm lên giao diện
                textBoxProductName.Text = currentProduct.ProductName;
                textBoxPrice.Text = currentProduct.Price.ToString();
                textBoxUnit.Text = currentProduct.Unit;
                richTextBoxDescription.Text = currentProduct.Description;
                comboBoxCategoryName.SelectedValue = currentProduct.CategoryId;
            }
            else
            {
                // Chế độ thêm mới
                labelThemSP.Text = "Thêm Sản Phẩm";
                isEditing = false;
            }
        }
        private void LoadCategoryNames()
        {
            DataTable categories = CategoryDao.Instance.getAll();
            comboBoxCategoryName.DataSource = categories;
            comboBoxCategoryName.DisplayMember = "CategoryName";
            comboBoxCategoryName.ValueMember = "CategoryId";
        }


        private void buttonHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    if (isEditing)
                    {
                        // Cập nhật sản phẩm
                        currentProduct.ProductName = textBoxProductName.Text;
                        currentProduct.Price = double.Parse(textBoxPrice.Text);
                        currentProduct.Unit = textBoxUnit.Text;
                        currentProduct.Description = richTextBoxDescription.Text;
                        currentProduct.CategoryId = (int)comboBoxCategoryName.SelectedValue;

                        bool isUpdated = ProductDao.Instance.Update(currentProduct);
                        if (isUpdated)
                        {
                            MessageBox.Show("Cập nhật sản phẩm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Thêm mới sản phẩm
                        Product newProduct = new Product
                        {
                            ProductName = textBoxProductName.Text,
                            Price = double.Parse(textBoxPrice.Text),
                            Unit = textBoxUnit.Text,
                            Description = richTextBoxDescription.Text,
                            CategoryId = (int)comboBoxCategoryName.SelectedValue,
                        };

                        bool isInserted = ProductDao.Instance.InsertNewProduct(newProduct);
                        if (isInserted)
                        {
                            MessageBox.Show("Thêm sản phẩm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thêm sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin nhập vào.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(textBoxProductName.Text) ||
                string.IsNullOrEmpty(textBoxPrice.Text) ||
                comboBoxCategoryName.SelectedValue == null ||
                string.IsNullOrEmpty(richTextBoxDescription.Text))
            {
                return false;
            }
            // Kiểm tra định dạng số cho giá sản phẩm
            if (!decimal.TryParse(textBoxPrice.Text, out decimal price) || price <= 0)
            {
                return false;
            }

            return true;
        }

        private void comboBoxCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
