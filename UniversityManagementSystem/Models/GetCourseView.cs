using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class GetCourseView
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int StudentId { get; set; }
    }
}