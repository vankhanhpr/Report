using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ModelClassLibrary.connection;
using ModelClassLibrary.imlp;
using ModelClassLibrary.interfaces;
using REPORT.service;
using REPORT.service.auth;
using REPORT.service.auth.impl;
using REPORT.service.impl;
using REPORT.service.user;
using REPORT.service.user.impl;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace REPORT.di
{
    public class Register
    {
        public static void builder()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            //builder.RegisterType<StoreDbContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<ReportImpl>().As<IReport>().InstancePerRequest();
            builder.RegisterType<AuthImpl>().As<IAuth>().WithParameter("context",new DataContext());
            builder.RegisterType<UserImpl>().As<IUser>().WithParameter("context",new DataContext());
            builder.RegisterType<HashPass>().As<IHashPass>().InstancePerRequest();


            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

        }
    }
}