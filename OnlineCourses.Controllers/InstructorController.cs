﻿using OnlineCourses.Interfaces;
using OnlineCourses.Types.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineCourses.Controllers
{
    public class InstructorController : ApiController
    {
        private readonly IService service;

        public InstructorController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ActionName("getInstructors")]
        public HttpResponseMessage GetInstructors()
        {
            var response = service.GetInstructors();
            if (response != null)
            {
                return Request.CreateResponse<GetInstructorsResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Instructors");
            }
        }
    }
}
