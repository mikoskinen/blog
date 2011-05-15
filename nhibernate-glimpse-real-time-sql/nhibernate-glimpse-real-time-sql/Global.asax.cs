using System;
using System.Web.Mvc;
using System.Web.Routing;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using nhibernate_glimpse_real_time_sql.Models;

namespace nhibernate_glimpse_real_time_sql
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static ISessionFactory sessionFactory;
        private static Configuration configuration;

        public static ISession CreateSession()
        {
            var session = sessionFactory.OpenSession();
            BuildSchema(configuration, session);

            return session;
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            sessionFactory = CreateSessionFactory();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Client>())
                .Diagnostics(x => x.Enable())
                .ExposeConfiguration(cfg => configuration = cfg)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config, ISession session)
        {
            new SchemaExport(config).Execute(false, true, false, session.Connection, Console.Out);
        }
    }
}