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

        public DataTable getAll()
        {
            DataTable data = new DataTable();
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
