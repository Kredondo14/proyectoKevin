using System;
using System.Web;
using System.Web.Routing;

namespace proyectoKevin
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("~/CapaPresentacion/Login.aspx");
        }
    }
}
