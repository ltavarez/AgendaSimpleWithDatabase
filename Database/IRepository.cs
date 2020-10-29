using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Modelos;

namespace Database
{
    public interface IRepository<T>
    {
         bool Add(T item);
         bool Edit(T item);
         bool Delete(int id);
         DataTable List();
         T GetById(int id);
    }
}
