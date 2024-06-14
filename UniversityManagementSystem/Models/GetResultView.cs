using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class GetResultView
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string RegistrationNumber { get; set; }
        public string Code { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}