using OnlineCourses.Implementation;
using OnlineCourses.Implementation.BusinessLayerImplementation;
using OnlineCourses.Implementation.DataBaseImplementation;
using OnlineCourses.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace OnlineCourses
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<IService, OnCoursesImplementation>(Lifestyle.Scoped);
            container.Register<IBasicInfo, BasicInfoService>(Lifestyle.Scoped);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);


            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
