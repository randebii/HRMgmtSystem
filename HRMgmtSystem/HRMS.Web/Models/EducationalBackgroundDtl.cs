using HRMS.Core.Enums;
using HRMS.Core.Models;
using HRMS.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.Models
{
    public class EducationalBackgroundDtl
    {
        public EducationalBackgroundDtl() { }
        public EducationalBackgroundDtl(EducationalBackground edu)
        {
            if (edu != null)
            {
                edu.Convert<EducationalBackgroundDtl>(this);
            }
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public EducationalLevel Type { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public string Address { get; set; }
        public string YearAttended { get; set; }
        public string ContactNumber { get; set; }

        public string TypeDisplay
        {
            get { return Type.ToString(); }
        }

        public EducationalBackground ToModel()
        {
            return this.Convert<EducationalBackground>();
        }
    }
}