using HRMS.Core.Models;
using HRMS.Core.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.Web.Models
{
    public class EmploymentHistoryDtl
    {
        public EmploymentHistoryDtl() { }
        public EmploymentHistoryDtl(EmploymentHistory emp)
        {
            if (emp != null)
            {
                emp.Convert<EmploymentHistoryDtl>(this);
            }
        }
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]        
        public string Employer { get; set; }
        public string Address { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        [Display(Name = "Years of Service")]
        public double YearsOfService { get; set; }

        public string YearsOfServiceDisplay 
        {
            get
            {
                string retVal = string.Empty;
                if (YearsOfService == 1)
                {
                    retVal = YearsOfService + " year";
                }
                else if (YearsOfService > 1)
                {
                    retVal = YearsOfService + " years";
                }
                else
                {
                    retVal = "Less than 1 year";
                }
                return retVal;
            }
        }

        public EmploymentHistory ToModel()
        {
            return this.Convert<EmploymentHistory>();
        }
    }
}