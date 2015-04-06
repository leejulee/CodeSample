using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCProject.Logic
{
    public interface IBaseBusiness<T>
    {
        bool Delete(string id);

        bool Add(T entity);

        T GetData(string id);

        bool Update(T entity);

        IEnumerable<T> GetAllData();
    }
}
