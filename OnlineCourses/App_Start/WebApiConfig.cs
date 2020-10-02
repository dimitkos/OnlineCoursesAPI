using OnlineCourses.Common.Auditing;
using OnlineCourses.Common.ErrorLogging;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace OnlineCourses
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Replace(typeof(IExceptionLogger), new ApiExceptionLogging());
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new AuditHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
