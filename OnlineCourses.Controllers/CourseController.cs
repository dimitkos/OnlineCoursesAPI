using OnlineCourses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineCourses.Controllers
{
    public class CourseController : ApiController
    {
        private readonly IService service;

        public CourseController(IService service)
        {
            this.service = service;
        }
    }
}
