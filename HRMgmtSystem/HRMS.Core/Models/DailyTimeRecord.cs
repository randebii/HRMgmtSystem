﻿using HRMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Models
{
    public class DailyTimeRecord
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? AMIn { get; set; }
        public TimeSpan? AMOut { get; set; }
        public TimeSpan? PMIn { get; set; }
        public TimeSpan? PMOut { get; set; }
        public AbsentType? AbsentType { get; set; }
    }
}
