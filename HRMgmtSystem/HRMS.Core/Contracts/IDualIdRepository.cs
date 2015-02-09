using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Contracts
{
    public interface IDualIdRepository<T, TidOne, TidTwo> : IRepository<T> where T: class
    {
        T GetById(TidOne idOne, TidTwo idTwo);
        void Delete(TidOne idOne, TidTwo idTwo);
    }
}
