using OnlineCourses.Implementation;
using OnlineCourses.Implementation.BusinessLayerImplementation;
using OnlineCourses.Implementation.DataBaseImplementation;
using OnlineCourses.Implementation.Helper;
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
            container.Register<IUser, UserService>(Lifestyle.Scoped);
            container.Register<IValidation, Validations>(Lifestyle.Scoped);
            container.Register<IInstructor, InstructorService>(Lifestyle.Scoped);
            container.Register<ICourse, CourseService>(Lifestyle.Scoped);
            container.Register<ICsv, CsvService>(Lifestyle.Scoped);
            container.Register<IAuthenticationManager, AuthenticationService>(Lifestyle.Scoped);
            container.Register<ITokenProvider, TokenProvider>(Lifestyle.Scoped);
            container.Register<IPasswordProvider, PasswordProvider>(Lifestyle.Scoped);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);


            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
