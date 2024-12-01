using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVPP_Project.Dao
{
    public interface ModelDao<T>
    {
        List<T> getAll();
        T getById(int id);
        bool Insert(T model);
        bool Update(T model);
        bool Delete(int id);

    }
}
