using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GuestbookASPNET
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            var culture = new CultureInfo(Thread.CurrentThread.CurrentCulture.ToString())
            {
                DateTimeFormat =
                {
                    ShortDatePattern = "dd-MM-yyyy",
                    LongTimePattern = "HH:mm:ss"
                }
            };
            Thread.CurrentThread.CurrentCulture = culture;
            // modify datetime.tostring formating in estonian locale
            // default format is: ShortDatePattern + ' ' + LongTimePattern
            //if (CultureInfo.CurrentCulture.Name.StartsWith("et"))
            //{
            //    var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            //    culture.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            //    Thread.CurrentThread.CurrentCulture = culture;
            //}
        }
    }
}
