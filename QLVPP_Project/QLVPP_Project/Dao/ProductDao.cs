using QLVPP_Project.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace QLVPP_Project.Dao
{
    class ProductDao : ModelDao<Product>
    {
        string connectString = ConnectionManager.getConnectString();

        public List<Product> getAll()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = @"
        SELECT p.ProductId, p.ProductName, p.Description, p.Price, p.Unit, p.ImgUrl, p.CategoryId, c.CategoryName
        FROM Product p 
        JOIN Category c ON p.CategoryId = c.CategoryId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product(
                        reader["ProductId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ProductId"]),
                        reader["ProductName"] == DBNull.Value ? "" : reader["ProductName"].ToString(),
                        reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString(),
                        reader["Price"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["Price"]),
                        reader["Unit"] == DBNull.Value ? "" : reader["Unit"].ToString(),
                        reader["ImgUrl"] == DBNull.Value ? "" : reader["ImgUrl"].ToString(),
                        reader["CategoryId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CategoryId"]),
                        reader["CategoryName"] == DBNull.Value ? "" : reader["CategoryName"].ToString()
                    ));
                }
            }
            return products;
        }

        public DataTable ConvertToDataTable(List<Product> products)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("Price", typeof(double));
            dt.Columns.Add("Unit", typeof(string));
            dt.Columns.Add("CategoryName", typeof(string)); // Đúng là CategoryName
            dt.Columns.Add("Description", typeof(string));

            foreach (var product in products)
            {
                dt.Rows.Add(product.ProductName, product.Price, product.Unit, product.CategoryName, product.Description);
            }

            return dt;
        }



        public Product getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Product model)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product model)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            return false;
        }
    }
}
