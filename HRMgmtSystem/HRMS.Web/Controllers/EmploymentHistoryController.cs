using HRMS.Core.Contracts;
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
    public class EmploymentHistoryController : Controller
    {
        private const string notificationSuccess = "EmploymentHistory-success";
        private const string notificationError = "EmploymentHistory-error";
        private const string notificationWarning = "EmploymentHistory-warning";

        public PartialViewResult Create(int empId)
        {
            ViewBag.EmployeeId = empId;
            return PartialView("CreateUpdateEmpHistory");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmploymentHistoryDtl emp)
        {
            string returnUrl = Url.Action("profile", "employee", new { id = emp.EmployeeId }) + "#emp-history";

            if (ModelState.IsValid)
            {
                EmploymentHistory emphist = emp.ToModel();
                var repo = Ioc.Get<IEmploymentHistoryRepository>();
                repo.Create(emphist);

                TempData[notificationSuccess] = "New Employment History successfully created.";
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
            var repo = Ioc.Get<IEmploymentHistoryRepository>();
            EmploymentHistory emp = repo.GetById(id);

            if (emp != null)
            {
                repo.Delete(id);
                TempData[notificationSuccess] = string.Format("'{0}' was successfully deleted.", emp.Employer);
                string returnUrl = Url.Action("profile", "employee", new { id = emp.EmployeeId }) + "#emp-history";
                return Redirect(returnUrl);
            }
            else
            {
                TempData[notificationWarning] = "Oops, the Employment History you wanted to delete no longer exists.";
                return RedirectToAction("index", "employee");
            }
        }

        public JsonResult GetByEmployee(int id)
        {
            var retVal = new List<EmploymentHistoryDtl>();
            var repo = Ioc.Get<IEmploymentHistoryRepository>();

            retVal = repo.GetByEmployeeId(id)
                .Select(a => new EmploymentHistoryDtl(a))
                .ToList();

            return Json(retVal, JsonRequestBehavior.AllowGet);
        }
    }
}