using HRMS.Core.Models;
using HRMS.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.Models
{
    public class DepartmentDtl
    {
        public DepartmentDtl() { }
        public DepartmentDtl(Department dep)
        {
            if (dep != null)
            {
                dep.Convert<DepartmentDtl>(this);
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public Department ToModel()
        {
            return this.Convert<Department>();
        }
    }
}