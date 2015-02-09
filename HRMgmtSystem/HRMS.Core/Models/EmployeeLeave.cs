using HRMS.Core.Attributes;
using HRMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Models
{
    public class EmployeeLeave
    {
        [Id(IdType.DatabaseGenerated)]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int EquivalentDays { get; set; }
        public string Remarks { get; set; }
    }
}
