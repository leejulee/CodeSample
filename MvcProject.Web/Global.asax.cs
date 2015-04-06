using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.AutoRegistration;
using Microsoft.Practices.Unity;
using MVCProject.Common;

namespace MvcProject.Web
{
    // 注意: 如需啟用 IIS6 或 IIS7 傳統模式的說明，
    // 請造訪 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IUnityContainer container = UnityHelper.GetUnityContainer();

            container.ConfigureAutoRegistration()
                .ExcludeSystemAssemblies()
                .Include(x => x.Assembly == Assembly.Load("MVCProject.Data")
                    && x.Name.EndsWith("Repository")//這裡是過濾class名稱而非介面名稱
                    , Then.Register().AsAllInterfacesOfType())
                .Include(x => x.Assembly == Assembly.Load("MVCProject.Logic")
                    && x.Name.EndsWith("Business")
                    , Then.Register().AsAllInterfacesOfType())
                .ApplyAutoRegistration();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}