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


                dataGridViewQLSP.DataSource = ProductDao.Instance.getAll();


            }
            catch (Exception ex)
            {
                string errorMessage = $"Error in {nameof(ProductDao)}.{nameof(ProductDao.getAll)}: {ex.Message}\nStack Trace:\n{ex.StackTrace}";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewQLSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
