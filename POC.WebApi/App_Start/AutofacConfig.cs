using Autofac;
using Autofac.Integration.WebApi;
using POC.DIModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace POC.WebApi.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(config);
            
            builder.RegisterModule(new RegisterDependancyInjectionModules());

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}