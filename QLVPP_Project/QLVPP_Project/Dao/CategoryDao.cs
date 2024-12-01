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
