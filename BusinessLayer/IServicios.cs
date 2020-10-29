using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    interface IServicios<T>
    {
        bool Add(T item);
        bool Edit(T item);
        bool Delete(int id);
        T GetById(int id);
        DataTable GetAll();
    }
}
