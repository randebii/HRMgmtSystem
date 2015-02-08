using HRMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeType Type { get; set; }
        public int? MonthsBeforePromotion { get; set; }

        public IEnumerable<LeaveEntitled> LeavesEntitled { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
