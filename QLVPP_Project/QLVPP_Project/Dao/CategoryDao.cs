using QLVPP_Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QLVPP_Project.Dao
{
    class CategoryDao : ModelDao<Category>
    {
        string connectString = ConnectionManager.getConnectString();

        private static CategoryDao instance;

        internal static CategoryDao Instance 
        {
            get { if (instance == null) instance = new CategoryDao(); return CategoryDao.instance; }
            private set { CategoryDao.instance = value; }
        }

        public CategoryDao() { }

        public DataTable getAll()
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "Select * from Category";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(data);
                conn.Close();
            }
            return data;
        }
        public int GetCategoryIdByName(string categoryName)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "SELECT CategoryId FROM Category WHERE CategoryName = @CategoryName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                object result = cmd.ExecuteScalar();
                conn.Close();

                return result != null ? Convert.ToInt32(result) : -1; // Trả về -1 nếu không tìm thấy
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
