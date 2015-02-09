﻿using HRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Contracts
{
    public interface IDepartmentRepository : IRepository<Department>, ISingleIDRepository<Department, int>
    {
    }
}
