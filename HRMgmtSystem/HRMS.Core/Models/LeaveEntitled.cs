using HRMS.Core.Attributes;
using HRMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Models
{
    public class LeaveEntitled
    {
        [Id(IdType.UserDefined, 1)]
        public int PositionId { get; set; }
        [Id(IdType.UserDefined, 2)]
        public int LeaveId { get; set; }
        public int DaysEntitled { get; set; }
    }
}
