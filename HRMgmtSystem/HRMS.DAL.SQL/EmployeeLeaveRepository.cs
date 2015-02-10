using HRMS.Core.Contracts;
using HRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL.SQL
{
    public class EmployeeLeaveRepository : SingleIdRepository<EmployeeLeave, int>, IEmployeeLeaveRepository
    {
        public EmployeeLeaveRepository() : base("EmployeeLeaves") { }
    }
}
