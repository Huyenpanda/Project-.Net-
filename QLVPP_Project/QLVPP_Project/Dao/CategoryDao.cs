using QLVPP_Project.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLVPP_Project.Dao
{
    class CategoryDao : ModelDao<Category>
    {
        string connectString = ConnectionManager.getConnectString();

        public List<Category> getAll()
        {
            List<Category> categories = new List<Category>();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "SELECT * FROM Category";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(new Category(
                        (int)reader["CategoryId"],
                        (string)reader["CategoryName"]
                    ));
                }
                return categories;
            }
        }

        public Category getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Category model)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category model)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            return false;
        }
    }
}
