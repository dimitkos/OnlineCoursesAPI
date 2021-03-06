﻿using System.Runtime.Serialization;

namespace OnlineCourses.Types.Requests
{
    [DataContract]
    public class SearchCoursesRequest
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "upRating")]
        public decimal? UpRating { get; set; }

        [DataMember(Name = "downRating")]
        public decimal? DownRating { get; set; }

        [DataMember(Name = "upPrice")]
        public decimal? UpPrice { get; set; }

        [DataMember(Name = "downPrice")]
        public decimal? DownPrice { get; set; }

        [DataMember(Name = "instructorName")]
        public string InstructorName { get; set; }

        [DataMember(Name = "categoryName")]
        public string CategoryName { get; set; }

        [DataMember(Name = "frameworkName")]
        public string FrameworkName { get; set; }
    }
}
