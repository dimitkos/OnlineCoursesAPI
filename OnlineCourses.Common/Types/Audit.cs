using System;

namespace OnlineCourses.Common.Types
{
    public class Audit
    {
        public Guid Id { get; set; }
        public string Host { get; set; }
        public string Headers { get; set; }
        public string StatusCode { get; set; }
        public string RequestBody { get; set; }
        public string RequestedMethod { get; set; }
        public string UserHostAddress { get; set; }
        public string Useragent { get; set; }
        public string AbsoluteUri { get; set; }
        public string RequestType { get; set; }
        public DateTime Time { get; set; }
    }
}
