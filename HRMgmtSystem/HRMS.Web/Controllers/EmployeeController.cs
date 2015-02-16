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
            return View();
        }

        public JsonResult Query(int draw)
        {
            var model = new {
                draw = draw,
                recordsTotal = 57,
                recordsFiltered = 57,
                data = new [] {
                    new { Name = "Randolph1" },
                    new { Name = "Randolph2" },
                    new { Name = "Randolph3" },
                    new { Name = "Randolph4" }
                }
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }
	}
}