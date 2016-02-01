using Microsoft.Security.Application;
using MvcProject.Web.App_GlobalResources;
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

        public ActionResult HtmlEditor()
        {
            ViewBag.UserEditor = "<img alt=\"\" src=\"/Content/EditorImages/images/contact-01.png\" style=\"height:80px; width:80px\" />\r\n<ul>\r\n\t<li>\r\n\t<h1>這是<strong>一筆</strong>測試資料，</h1>\r\n\t</li>\r\n</ul>\r\n&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MTK&nbsp;8-core&nbsp;processor&nbsp;available&nbsp;at&nbsp;1.4GHz&nbsp;or&nbsp;1.7GHz,78%&nbsp;higher&nbsp;processing&nbsp;performance&nbsp;than&nbsp;its&nbsp;predecessor";
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]//若為屬性可用[AllowHtml]
        public ActionResult HtmlEditor(string UserEditor)
        {
            ViewBag.UserEditor = Sanitizer.GetSafeHtmlFragment(UserEditor);
            return View();
        }

        public ActionResult DemoAngular()
        {
            return View();
        }


        public ActionResult GetMockData()
        {
            return Json(new { name = "one" }, JsonRequestBehavior.AllowGet);
        }
    }
}
