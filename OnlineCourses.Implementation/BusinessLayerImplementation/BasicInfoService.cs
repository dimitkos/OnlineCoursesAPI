using OnlineCourses.Implementation.Helper;
using OnlineCourses.Interfaces;
using OnlineCourses.Types.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Implementation.BusinessLayerImplementation
{
    public class BasicInfoService : IBasicInfo
    {
        private readonly IService _dbService;

        public BasicInfoService(IService dbService)
        {
            _dbService = dbService;
        }

        public GetFrameworksResponse FetchFrameworks()
        {
            var cache = Cache.Get("frameworks", () => _dbService.GetFrameworks());
            return cache;
        }

        public GetCategoriesResponse FetchCategories()
        {
            var cache = Cache.Get("categories", () => _dbService.GetCategories());
            return cache;
        }
    }
}
