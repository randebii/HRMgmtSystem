using HRMS.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace HRMS.DAL.SQL
{
    public abstract class DualIdRepository<T, TidOne, TidTwo> : Repository<T>, IDualIdRepository<T, TidOne, TidTwo> where T : class, new()
    {
        public DualIdRepository(string table) : base(table) { }

        public T GetById(TidOne idOne, TidTwo idTwo)
        {
            T retVal = null;

            using (IDbConnection conn = GetOpenConnection())
            {
                string sql = string.Format(SqlGetByIdFormat, Table);
                var param = new DynamicParameters();
                param.Add(IdPropInfos.ElementAt(0).Name, idOne);
                param.Add(IdPropInfos.ElementAt(1).Name, idTwo);
                retVal = conn.Query<T>(sql, param).FirstOrDefault();
            }

            return retVal;
        }

        public void Delete(TidOne idOne, TidTwo idTwo)
        {
            using (IDbConnection conn = GetOpenConnection())
            {
                string sql = string.Format(SqlDeleteFormat, Table);
                var param = new DynamicParameters();
                param.Add(IdPropInfos.ElementAt(0).Name, idOne);
                param.Add(IdPropInfos.ElementAt(1).Name, idTwo);
                conn.Execute(sql, param);
            }
        }
    }
}
