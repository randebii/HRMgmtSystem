using HRMS.Core.Contracts;
using HRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace HRMS.DAL.SQL
{
    public class DepartmentRepository : SingleIdRepository<Department, int>, IDepartmentRepository
    {
        public DepartmentRepository() : base("Departments") { }

        public IEnumerable<IdValuePair<int>> GetIdValuePair()
        {
            var retVal = new List<IdValuePair<int>>();

            using (IDbConnection conn = GetOpenConnection())
            {
                string sql = string.Format("SELECT Id, Abbreviation as [Value] FROM {0}", Table);
                retVal = conn.Query<IdValuePair<int>>(sql).ToList();
            }

            return retVal;
        }
    }
}
