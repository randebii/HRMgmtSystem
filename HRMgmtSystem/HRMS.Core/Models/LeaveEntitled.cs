using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Models
{
    public class LeaveEntitled
    {
        public int PositionId { get; set; }
        public int LeaveId { get; set; }
        public int DaysEntitled { get; set; }
    }
}
