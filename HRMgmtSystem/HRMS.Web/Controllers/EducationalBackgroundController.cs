using HRMS.Core.Contracts;
using HRMS.Core.Enums;
using HRMS.Core.Models;
using HRMS.Framework;
using HRMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Web.Controllers
{
    public class EducationalBackgroundController : Controller
    {
        private const string notificationSuccess = "EducationalBackground-success";
        private const string notificationError = "EducationalBackground-error";
        private const string notificationWarning = "EducationalBackground-warning";
        
        public PartialViewResult Create(int empId)
        {
            ViewBag.EmployeeId = empId;
            ViewBag.EducationalTypes = Util.GetSelectList<EducationalLevel>();
            return PartialView("CreateUpdateEducBackground");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EducationalBackgroundDtl edu)
        {
            string returnUrl = Url.Action("profile", "employee", new { id = edu.EmployeeId }) + "#edu-background";

            if (ModelState.IsValid)
            {
                EducationalBackground eduback = edu.ToModel();
                var repo = Ioc.Get<IEducationalBackgroundRepository>();
                repo.Create(eduback);

                TempData[notificationSuccess] = "New Education Background successfully created.";
            }
            else
            {
                TempData[notificationError] = "Be sure to input the required fields and in proper format.";
            }
            
            return Redirect(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var repo = Ioc.Get<IEducationalBackgroundRepository>();            
            EducationalBackground edu = repo.GetById(id);
            if (edu != null)
            {
                repo.Delete(id);
                TempData[notificationSuccess] = string.Format("'{0}' was successfully deleted.", edu.Name);
                string returnUrl = Url.Action("profile", "employee", new { id = edu.EmployeeId }) + "#edu-background";
                return Redirect(returnUrl);
            }
            else
            {
                TempData[notificationWarning] = "Oops, the Educational Background you wanted to delete no longer exists.";
                return RedirectToAction("index", "employee");
            }
        }

        public JsonResult GetByEmployee(int id)
        {
            #region dummy data
            //IEnumerable<EducationalBackgroundDtl> retVal = new List<EducationalBackgroundDtl>()
            //{
            //    new EducationalBackgroundDtl() 
            //    { 
            //        Name = "West City Elementaty School",
            //        Type = Core.Enums.EducationalLevel.Primary,
            //        Address = "Barangay Taclobo, Dumaguete City, Negros Oriental, Philippines 6200",
            //        ContactNumber = "225-9834",
            //        Id = 1,
            //        YearAttended = "1998-2002"
            //    },
            //    new EducationalBackgroundDtl() 
            //    { 
            //        Name = "St. Louis School - Don Bosco",
            //        Type = Core.Enums.EducationalLevel.Secondary,
            //        Address = "North Road, West Bantayan, Dumaguete City, Negros Oriental, Philippines 6200",
            //        ContactNumber = "422-0948",
            //        Id = 1,
            //        YearAttended = "2002-2006"
            //    },
            //    new EducationalBackgroundDtl() 
            //    { 
            //        Name = "St. Paul University Dumaguete",
            //        Type = Core.Enums.EducationalLevel.Tertiary,
            //        Address = "North Road, West Bantayan, Dumaguete City, Negros Oriental, Philippines 6200",
            //        ContactNumber = "225-55771",
            //        Id = 1,
            //        Degree = "Bachelor of Science in Information Technology",
            //        YearAttended = "2008-2012"
            //    },
            //};
            #endregion

            var retVal = new List<EducationalBackgroundDtl>();
            var repo = Ioc.Get<IEducationalBackgroundRepository>();

            retVal = repo.GetByEmployeeId(id)
                .Select(a => new EducationalBackgroundDtl(a))
                .ToList();

            return Json(retVal, JsonRequestBehavior.AllowGet);
        }
    }
}