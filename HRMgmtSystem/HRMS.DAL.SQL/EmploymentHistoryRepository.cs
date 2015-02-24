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
    public class EmploymentHistoryRepository : SingleIdRepository<EmploymentHistory, int>, IEmploymentHistoryRepository
    {
        public EmploymentHistoryRepository() : base("EmploymentHistory") { }

        public IEnumerable<EmploymentHistory> GetByEmployeeId(int id)
        {
            var retVal = new List<EmploymentHistory>();
            string sql = string.Format("SELECT * FROM [{0}] WHERE EmployeeId = @EmployeeId", Table);

            using (IDbConnection conn = GetOpenConnection())
            {
                retVal = conn.Query<EmploymentHistory>(sql, new { EmployeeId = id }).ToList();
            }

            return retVal;
        }
    }
}
