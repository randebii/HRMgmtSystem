using HRMS.Core.Enums;
using HRMS.Core.Models;
using HRMS.Core.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Display(Name = "Educational Level")]
        public EducationalLevel Type { get; set; }
        [Required]
        [Display(Name = "School Name")]
        public string Name { get; set; }
        [Display(Name = "Degree (if applicable)")]
        public string Degree { get; set; }
        public string Address { get; set; }
        [Required]
        [Display(Name = "Year Attended")]
        public string YearAttended { get; set; }
        [Display(Name = "Contact Number")]
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