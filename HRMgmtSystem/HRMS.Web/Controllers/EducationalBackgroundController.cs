using HRMS.Core.Enums;
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
        // GET: EducationalBackground
        public ActionResult Index()
        {
            return View();
        }

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
                // todo
                TempData["edu-success"] = "New Education Background successfully created.";
            }
            
            return Redirect(returnUrl);
        }

        public JsonResult GetByEmployee(int id)
        {
            IEnumerable<EducationalBackgroundDtl> retVal = new List<EducationalBackgroundDtl>()
            {
                new EducationalBackgroundDtl() 
                { 
                    Name = "West City Elementaty School",
                    Type = Core.Enums.EducationalLevel.Primary,
                    Address = "Barangay Taclobo, Dumaguete City, Negros Oriental, Philippines 6200",
                    ContactNumber = "225-9834",
                    Id = 1,
                    YearAttended = "1998-2002"
                },
                new EducationalBackgroundDtl() 
                { 
                    Name = "St. Louis School - Don Bosco",
                    Type = Core.Enums.EducationalLevel.Secondary,
                    Address = "North Road, West Bantayan, Dumaguete City, Negros Oriental, Philippines 6200",
                    ContactNumber = "422-0948",
                    Id = 1,
                    YearAttended = "2002-2006"
                },
                new EducationalBackgroundDtl() 
                { 
                    Name = "St. Paul University Dumaguete",
                    Type = Core.Enums.EducationalLevel.Tertiary,
                    Address = "North Road, West Bantayan, Dumaguete City, Negros Oriental, Philippines 6200",
                    ContactNumber = "225-55771",
                    Id = 1,
                    Degree = "Bachelor of Science in Information Technology",
                    YearAttended = "2008-2012"
                },
            };

            return Json(retVal, JsonRequestBehavior.AllowGet);
        }
    }
}