﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property)]
    public class DbIgnoreAttribute : Attribute
    {
    }
}
