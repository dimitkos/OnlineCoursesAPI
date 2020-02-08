using OnlineCourses.Common.DBCommon;
using OnlineCourses.Common.Types;
using System;
using System.Web.Http.ExceptionHandling;

namespace OnlineCourses.Common.ErrorLogging
{
    public class ApiExceptionLogging : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var ex = context.Exception;

            var logText = HandleLogText(ex);
            var requestedURi = (string)context.Request.RequestUri.AbsoluteUri;
            var requestMethod = context.Request.Method.ToString();
            var timeUtc = DateTime.Now;

            Error apiError = new Error
            {
                Message = logText,
                RequestUri = requestedURi,
                RequestMethod = requestMethod,
                TimeUtc = DateTime.Now
            };

            try
            {
                DatabaseLogging.LogError(apiError);
            }
            catch (Exception)
            {
                throw;
            }                       
        }

        private string HandleLogText(Exception ex)
        {
            string logText = "";

            logText += Environment.NewLine + "Source ---\n{0}" + ex.Source;
            logText += Environment.NewLine + "StackTrace ---\n{0}" + ex.StackTrace;
            logText += Environment.NewLine + "TargetSite ---\n{0}" + ex.TargetSite;//maybe not

            if (ex.InnerException != null)
            {
                logText += Environment.NewLine + "Inner Exception is {0}" + ex.InnerException;//error prone
            }
            if (ex.HelpLink != null)
            {
                logText += Environment.NewLine + "HelpLink ---\n{0}" + ex.HelpLink;//maybe not
            }

            return logText;
        }
    }
}
