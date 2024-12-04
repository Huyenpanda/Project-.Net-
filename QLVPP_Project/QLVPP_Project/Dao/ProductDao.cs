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
            get { if (instance == null) instance = new ProductDao(); return ProductDao.instance; }
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
        public string getProductNameById(int productId)
        {
            string productName = null;
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "SELECT ProductName FROM Product WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    productName = reader["ProductName"].ToString();
                }
                conn.Close();
            }
            return productName;
        }

        public bool Insert(Product model)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Product (ProductName, Price, Description, ImgUrl, CategoryId, Unit) " +
                                 "VALUES (@ProductName, @Price, @Description, @ImgUrl, @CategoryId, @Unit)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ProductName", model.ProductName);
                    cmd.Parameters.AddWithValue("@Price", model.Price);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@ImgUrl", model.ImgUrl);
                    cmd.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                    cmd.Parameters.AddWithValue("@Unit", model.Unit);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erorr ProductDao: {ex.Message}");
                    return false;
                }
            }
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

        public bool Update(Product model)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE Product SET ProductName = @ProductName, Price = @Price, Description = @Description, " +
                                 " CategoryId = @CategoryId, Unit = @Unit WHERE ProductId = @ProductId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ProductName", model.ProductName);
                    cmd.Parameters.AddWithValue("@Price", model.Price);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    //cmd.Parameters.AddWithValue("@ImgUrl", model.ImgUrl);
                    cmd.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                    cmd.Parameters.AddWithValue("@Unit", model.Unit);
                    cmd.Parameters.AddWithValue("@ProductId", model.ProductId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error ProductDao: {ex.Message}");
                    return false;
                }
            }
        }

        public bool InsertNewProduct(Product product)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Product (ProductName, Price, Unit, Description, CategoryId) VALUES (@ProductName, @Price, @Unit, @Description, @CategoryId)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@Unit", product.Unit);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0; // Nếu có ít nhất một dòng được thêm vào, trả về true
                }
            }
            catch (Exception ex)
            {
                // Lỗi kết nối hoặc truy vấn sẽ được ném ra ngoài
                throw new Exception("Đã xảy ra lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }


        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM Product WHERE ProductId = @ProductId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ProductId", id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error ProductDao: {ex.Message}");
                    return false;
                }
            }
        }

        public DataTable searchByNameAndPrice(string proName, double fromPrice, double toPrice)
        {
            string query = "SELECT * FROM Product WHERE 1=1";
            if (!string.IsNullOrEmpty(proName))
            {
                query += " AND ProductName LIKE @ProductName";
            }
            if (fromPrice > 0)
            {
                query += " AND Price >= @FromPrice";
            }
            if (toPrice > 0 && toPrice > fromPrice)
            {
                query += " AND Price <= @ToPrice";
            }
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                if (!string.IsNullOrEmpty(proName))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@ProductName", "%" + proName + "%");
                }
                if (fromPrice > 0)
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@FromPrice", fromPrice);
                }
                if (toPrice > 0 && toPrice > fromPrice)
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@ToPrice", toPrice);
                }
                conn.Open();
                adapter.Fill(dt);
            }

            return dt;
        }
        public DataTable searchByCriteria(string productName, int productId, double fromPrice, double toPrice)
        {
            string query = "SELECT * FROM Product WHERE 1=1";
            if (!string.IsNullOrEmpty(productName))
            {
                query += " AND ProductName LIKE @ProductName";
            }
            if (productId > 0)
            {
                query += " AND ProductId = @ProductId";
            }
            if (fromPrice > 0)
            {
                query += " AND Price >= @FromPrice";
            }
            if (toPrice > 0 && toPrice > fromPrice)
            {
                query += " AND Price <= @ToPrice";
            }
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                if (!string.IsNullOrEmpty(productName))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@ProductName", "%" + productName + "%");
                }
                if (productId > 0)
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@ProductId", productId);
                }
                if (fromPrice > 0)
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@FromPrice", fromPrice);
                }
                if (toPrice > 0 && toPrice > fromPrice)
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@ToPrice", toPrice);
                }
                conn.Open();
                adapter.Fill(dt);
            }

            return dt;
        }


        public Product getById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
