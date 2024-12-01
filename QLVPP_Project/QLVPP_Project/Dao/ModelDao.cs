using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVPP_Project.Dao
{
    public interface ModelDao<T>
    {
        DataTable getAll();
        T getById(int id);
        bool Insert(T model);
        bool Update(T model);
        bool Delete(int id);

    }
}
