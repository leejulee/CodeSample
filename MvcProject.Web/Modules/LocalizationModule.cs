using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace MvcProject.Web.Modules
{
    public class LocalizationModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
        }

        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            //TODO 設定文化資訊
            var app = (HttpApplication)sender;
            var cookie = app.Context.Request.Cookies["UserCulture"];
            //app.Context.Request.UserLanguages
            if (cookie != null)
            {
                string culture = cookie.Value;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            }
        }
    }
}