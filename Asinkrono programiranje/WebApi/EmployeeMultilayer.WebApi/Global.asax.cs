using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using EmployeeMultilayer.Service;
using EmployeeMultilayer.Service.Common;
using EmployeeMultilayer.Repository;
using EmployeeMultilayer.Repository.Common;
using System.Reflection;

namespace EmployeeMultilayer.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new DIServiceModule());
            builder.RegisterModule(new DIRepositoryModule());

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
