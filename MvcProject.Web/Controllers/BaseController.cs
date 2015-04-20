using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures           
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }

        #region 調整cookie
        public ActionResult CreateCookie(string userCalture = "en-US")
        {
            var cookie = new HttpCookie("UserCulture", userCalture);
            Response.AppendCookie(cookie);
            return Json(true);
        }
        #endregion

        // GET: /Resource/GetResources
        const int durationInSeconds = 2 * 60 * 60;  // 2 hours.

        //[OutputCache(VaryByCustom = "culture", Duration = durationInSeconds)]
        //public JsonResult GetResources()
        //{

        //    return Json(
        //        typeof(Resource)
        //        .GetProperties()
        //        .Where(p => !p.Name.IsLikeAny("ResourceManager", "Culture")) // Skip the properties you don't need on the client side.
        //        .ToDictionary(p => p.Name, p => p.GetValue(null) as string)
        //         , JsonRequestBehavior.AllowGet);

        //    // Or the following 
        //    /*
        //    return Json(new Dictionary<string, string> { 
        //        {"Age", Resource.Age},
        //        {"FirstName", Resource.FirstName},
        //        {"LastName", Resource.LastName},
        //        {"EnterNumber", Resource.EnterNumber}

        //    }, JsonRequestBehavior.AllowGet);
        //    */
        //}
    }
}
