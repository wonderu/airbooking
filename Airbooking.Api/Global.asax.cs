using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Airbooking.Data;
using Airbooking.Utils.Logging;

namespace Airbooking.Api
{
    /// <summary>
    /// MvcApplication
    /// </summary>
    /// <seealso cref="System.Web.HttpApplication" />
    public class MvcApplication : HttpApplication
    {
        private ILoggingService _logger;
        /// <summary>
        /// Application_s the start.
        /// </summary>
        protected void Application_Start()
        {
            AntiForgeryConfig.SuppressIdentityHeuristicChecks = true;

            _logger = new LoggingService<MvcApplication>();
            _logger.Info("Application start");
            System.Data.Entity.Database.SetInitializer(new AirbookingSeedData());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootStrapper.Run();
            
        }

        /// <summary>
        /// Application_s the begin request.
        /// </summary>
        protected void Application_BeginRequest()
        {
            HttpContext.Current.Items.Add("RequestId",
                $"{Guid.NewGuid()} ip={HttpContext.Current.Request.ServerVariables["remote_addr"]} url={HttpContext.Current.Request.Url}");
        }

        /// <summary>
        /// Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            _logger?.Error(exc, "Application Error");
            Server.ClearError();
        }
    }
}
