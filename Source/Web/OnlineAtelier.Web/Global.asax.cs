﻿namespace OnlineAtelier.Web
{
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Infrastructure.Mapping;
    using OnlineAtelier.Data.Migrations;
    using System.Data.Entity.Migrations;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var migrator = new DbMigrator(new Configuration());
            //migrator.Update();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var autoMapperConfig = new AutoMapperConfig(Assembly.Load("OnlineAtelier.Web.Models"));
            autoMapperConfig.Execute();
        }
    }
}