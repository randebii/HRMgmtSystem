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
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Departments = Ioc.Get<IDepartmentRepository>().GetIdValuePair().ToSelectList();
            ViewBag.Positions = Ioc.Get<IPositionRepository>().GetIdValuePair().ToSelectList();
            ViewBag.Genders = Util.GetSelectList<Gender>();
            ViewBag.CivilStatuses = Util.GetSelectList<CivilStatus>();
            ViewBag.BloodTypes = Util.GetSelectList<BloodType>();
            ViewBag.Relations = Util.GetSelectList<Relation>();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(EmployeeDtl model)
        {
            if (ModelState.IsValid)
            {
                Employee emp = model.ToModel();
                var repo = Ioc.Get<IEmployeeRepository>();
                emp = repo.Create(emp);

                TempData["Success"] = "New employee successfully created.";

                return RedirectToAction("profile", new { id = emp.Id });
            }

            ViewBag.Departments = Ioc.Get<IDepartmentRepository>().GetIdValuePair().ToSelectList(model.DepartmentId);
            ViewBag.Positions = Ioc.Get<IPositionRepository>().GetIdValuePair().ToSelectList(model.PositionId);
            ViewBag.Genders = Util.GetSelectList<Gender>();
            ViewBag.CivilStatuses = Util.GetSelectList<CivilStatus>();
            ViewBag.BloodTypes = Util.GetSelectList<BloodType>();
            ViewBag.Relations = Util.GetSelectList<Relation>();

            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            var employee = Ioc.Get<IEmployeeRepository>().GetById(id);
            EmployeeDtl model = new EmployeeDtl(employee);
            
            ViewBag.Departments = Ioc.Get<IDepartmentRepository>().GetIdValuePair().ToSelectList(model.DepartmentId);
            ViewBag.Positions = Ioc.Get<IPositionRepository>().GetIdValuePair().ToSelectList(model.PositionId);
            ViewBag.Genders = Util.GetSelectList<Gender>(model.Gender);
            ViewBag.CivilStatuses = Util.GetSelectList<CivilStatus>(model.CivilStatus);
            ViewBag.BloodTypes = Util.GetSelectList<BloodType>(model.BloodType);
            ViewBag.Relations = Util.GetSelectList<Relation>(model.ContactPersonRelation);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(int id, EmployeeDtl model)
        {
            if (ModelState.IsValid)
            {
                Employee emp = model.ToModel();
                var repo = Ioc.Get<IEmployeeRepository>();
                repo.Update(emp);

                TempData["Success"] = "Employee info successfully updated.";

                return RedirectToAction("profile", new { id = emp.Id });
            }

            ViewBag.Departments = Ioc.Get<IDepartmentRepository>().GetIdValuePair().ToSelectList(model.DepartmentId);
            ViewBag.Positions = Ioc.Get<IPositionRepository>().GetIdValuePair().ToSelectList(model.PositionId);
            ViewBag.Genders = Util.GetSelectList<Gender>(model.Gender);
            ViewBag.CivilStatuses = Util.GetSelectList<CivilStatus>(model.CivilStatus);
            ViewBag.BloodTypes = Util.GetSelectList<BloodType>(model.BloodType);
            ViewBag.Relations = Util.GetSelectList<Relation>(model.ContactPersonRelation);

            return View(model);
        }

        public ActionResult Profile(int id)
        {
            var employee = Ioc.Get<IEmployeeRepository>().GetById(id);
            EmployeeDtl model = new EmployeeDtl(employee);

            return View(model);
        }

        public JsonResult Query()
        {
            var employees = Ioc.Get<IEmployeeRepository>().GetForListItems()
                .Select(a => new EmployeeListItem(a))
                .ToList();
            return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
        }
	}
}