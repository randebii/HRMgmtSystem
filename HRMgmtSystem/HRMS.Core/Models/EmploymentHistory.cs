using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Models
{
    public class EmploymentHistory
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Employer { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public double YearsOfService { get; set; }
    }
}
