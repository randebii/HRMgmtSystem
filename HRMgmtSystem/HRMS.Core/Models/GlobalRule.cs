﻿using HRMS.Core.Attributes;
using HRMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Models
{
    public class GlobalRule
    {
        [Id(IdType.DatabaseGenerated)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
