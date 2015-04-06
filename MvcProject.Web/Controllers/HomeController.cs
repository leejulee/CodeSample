using MVCProject.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(MVCProjectBusinessFactory.LogBusiness.GetAllData());
        }

    }
}
