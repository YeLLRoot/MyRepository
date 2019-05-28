using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Service
{
    public interface IService<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Add(T model);
        T GetById(int id);
    }
}
