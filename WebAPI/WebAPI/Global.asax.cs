using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAPI.Models;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Musterije users = new Musterije("~/App_Data/Musterije.txt");
            Dispeceri disp = new Dispeceri("~/App_Data/Dispeceri.txt");
            Vozaci drivers = new Vozaci("~/App_Data/Vozaci.txt");
            Voznje rides = new Voznje("~/App_Data/Voznje.txt");
           
            // Musterije users = new Musterije(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Musterije.txt");
            //Dispeceri disp = new Dispeceri(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Dispeceri.txt");
            //Vozaci drivers = new Vozaci(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Vozaci.txt");
            //Voznje rides = new Voznje(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Voznje.txt");

        }
    }
}
