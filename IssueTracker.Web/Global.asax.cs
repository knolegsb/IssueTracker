﻿using IssueTracker.Web.Infrastructure;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IssueTracker.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyResolver.SetResolver(new StructureMapDependencyResolver());

            //ObjectFactory.Configure(cfg =>
            //{
            //    cfg.Scan(scan =>
            //    {
            //        scan.TheCallingAssembly();
            //        scan.WithDefaultConventions()
            //    });
            //});
        }
    }
}
