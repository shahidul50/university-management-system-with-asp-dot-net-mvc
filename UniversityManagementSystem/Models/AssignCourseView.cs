﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AssignCourseView
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string TeacherName { get; set; }
        public int DepartmentId { get; set; }
    }
}