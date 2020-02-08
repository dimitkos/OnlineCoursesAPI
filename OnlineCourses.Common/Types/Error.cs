using System;

namespace OnlineCourses.Common.Types
{
    public class Error
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string RequestMethod { get; set; }
        public string RequestUri { get; set; }
        public DateTime TimeUtc { get; set; }
    }
}
