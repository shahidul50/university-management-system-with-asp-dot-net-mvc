using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class EnrollCourse
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please!select your Registration Number")]
        [Display(Name = "Student Reg No")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please!select your Course")]
        [Display(Name = "Select Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please!select Date")]
        public string Date { get; set; }
        public string Action { get; set; }
    }
}