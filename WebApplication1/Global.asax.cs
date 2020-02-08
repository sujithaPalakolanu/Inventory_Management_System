using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Models.DB;
using WebApplication1.Models.EntityManager;
using WebApplication1.Services;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InventoryDBEntities2 context = new InventoryDBEntities2();
            StockDetailsManager SDM = new StockDetailsManager(context);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           
        }
    }
}
