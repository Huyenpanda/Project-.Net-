using QLVPP_Project.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVPP_Project.Dao
{
    class ProductDao : ModelDao<Product>
    {
        string connectString = ConnectionManager.getConnectString();
       

        public List<Product> getAll()
        {
            List<Product> pros = new List<Product>();
            using (SqlConnection conn = new SqlConnection(connectString)) 
            { 
                conn.Open();
                string sql = "Select * from Product";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pros.Add(new Product(
                        (int)reader["ProductId"],
                        (string)reader["ProductName"],
                        (string)reader["Description"],
                        (double)reader["Price"],
                        (string)reader["Unit"],
                        (string)reader["ImgUrl"],
                        (int)reader["CategoryId"]
                        ));
                }
                return pros;
            }
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
            // VIet code vao day ;
            return false;
        }
    }
}
