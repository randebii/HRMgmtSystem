using HRMS.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL.SQL
{
    public class DualIdRepository<T, TidOne, TidTwo> : Repository<T>, IDualIdRepository<T, TidOne, TidTwo> where T : class, new()
    {
        public DualIdRepository(string table) : base(table) { }

        public T GetById(TidOne idOne, TidTwo idTwo)
        {
            throw new NotImplementedException();
        }

        public void Delete(TidOne idOne, TidTwo idTwo)
        {
            throw new NotImplementedException();
        }
    }
}
