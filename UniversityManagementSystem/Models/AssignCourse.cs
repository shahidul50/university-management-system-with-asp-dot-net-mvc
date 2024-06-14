using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AssignCourse
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please! select department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please! select teacher")]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "Please! select course")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public string Action { get; set; }
    }
}