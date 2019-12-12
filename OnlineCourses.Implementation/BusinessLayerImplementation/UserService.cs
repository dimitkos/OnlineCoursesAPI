using OnlineCourses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Implementation.BusinessLayerImplementation
{
    public class UserService : IUser
    {
        private readonly IService _dbService;

        public UserService(IService dbService)
        {
            _dbService = dbService;
        }
    }
}
