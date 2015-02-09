using HRMS.Core.Contracts;
using HRMS.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL.SQL
{
    public abstract class SingleIdRepository<T, Tid> : Repository<T>, ISingleIdRepository<T, Tid> where T: class, new()
    {
        public SingleIdRepository(string table) : base(table) { }

        public T GetById(Tid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Tid id)
        {
            throw new NotImplementedException();
        }
    }
}
