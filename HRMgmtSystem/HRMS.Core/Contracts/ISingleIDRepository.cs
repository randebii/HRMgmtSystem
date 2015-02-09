using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Contracts
{
    public interface ISingleIdRepository<T, Tid> : IRepository<T> where T : class
    {
        T GetById(Tid id);
        void Delete(Tid id);
    }
}
