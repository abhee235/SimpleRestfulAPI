using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace TeamScaleTest.App_Start
{
    public class DiConfig
    {
        public static void RegisterDependency()
        {
            var config = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            builder.RegisterModule<WebDiModule>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}