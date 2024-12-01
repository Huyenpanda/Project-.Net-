using QLVPP_Project.Model;
using System;
using System.Data.SqlClient;
using System.Data;

namespace QLVPP_Project.Dao
{
    class ProductDao : ModelDao<Product>
    {
        string connectString = ConnectionManager.getConnectString();

        private static ProductDao instance;

        public static ProductDao Instance 
        {
            get {if (instance == null) instance = new ProductDao(); return ProductDao.instance; }
            private set { ProductDao.instance = value; }
            
        }
        public ProductDao() { }

        public DataTable getAll()
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "Select * from Product";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(data);
                conn.Close();
            }
            return data;
        }
        public DataTable getAllAndCategoryName()
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = @"
            SELECT 
                p.ProductId, 
                p.ProductName, 
                p.Price, 
                p.Unit, 
                c.CategoryName, 
                p.Description
            FROM Product p
            JOIN Category c ON p.CategoryId = c.CategoryId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(data);
                conn.Close();
            }
            return data;
        }


        public Product getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Product model)
        {
            return false;
        }

        public bool Update(Product model)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "DELETE FROM Product WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ProductId", id);

                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                // Kiểm tra nếu xóa thành công
                return rows > 0;
            }
        }

    }
}
