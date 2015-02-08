using HRMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Models
{
    public class EducationalBackground
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EducationalLevel Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string YearAttended { get; set; }
        public string ContactNumber { get; set; }
    }
}
