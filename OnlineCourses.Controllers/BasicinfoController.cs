using OnlineCourses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineCourses.Controllers
{
    public class BasicinfoController : ApiController
    {
        
        private readonly IService service;

        public BasicinfoController(IService service)
        {
            this.service = service;
        }
    }
}
