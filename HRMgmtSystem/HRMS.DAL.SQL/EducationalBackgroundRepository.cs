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
    public class EducationalBackgroundRepository: SingleIdRepository<EducationalBackground, int>, IEducationalBackgroundRepository
    {
        public EducationalBackgroundRepository() : base("EducationalBackgrounds") { }

        public IEnumerable<EducationalBackground> GetByEmployeeId(int id)
        {
            var retVal = new List<EducationalBackground>();            
            string sql = string.Format("SELECT * FROM [{0}] WHERE EmployeeId = @EmployeeId", Table);

            using (IDbConnection conn = GetOpenConnection())
            {
                retVal = conn.Query<EducationalBackground>(sql, new { EmployeeId = id }).ToList();
            }

            return retVal;
        }
    }
}
