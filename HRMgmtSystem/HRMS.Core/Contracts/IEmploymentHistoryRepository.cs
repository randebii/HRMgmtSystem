using HRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Contracts
{
    public interface IEmploymentHistoryRepository : ISingleIdRepository<EmploymentHistory, int>
    {
        IEnumerable<EmploymentHistory> GetByEmployeeId(int id);
    }
}
