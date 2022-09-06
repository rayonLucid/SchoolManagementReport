using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SchoolManagementReport
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(Register);
    }
    protected void Application_PostAuthorizeRequest()
    {
      if (IsWebApiRequest())
      {
        HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
      }
    }
    private bool IsWebApiRequest()
    {
      return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith("~/api");
    }
    public void Register(HttpConfiguration config)
    {

      config.Routes.MapHttpRoute(
              name: "DefaultApi2",
              routeTemplate: "api/{controller}/{action}/{id}",
              defaults: new { id = RouteParameter.Optional, action = RouteParameter.Optional }
          );

      config.Routes.MapHttpRoute(
              name: "DefaultApi3",
              routeTemplate: "api/{controller}/{action}",
              defaults: new { action = RouteParameter.Optional }
          );


    }
  }
}