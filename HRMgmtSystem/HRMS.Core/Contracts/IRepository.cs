using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Contracts
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> Get();
        T Create(T model);
        void Update(T model);
        int Count();
    }
}
