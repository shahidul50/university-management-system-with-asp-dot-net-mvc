using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Result
    {
        public int Id { get; set; }
        [Display(Name = "Student Reg. No.")]
        [Required(ErrorMessage = "Select Your Registration Number")]
        public int StudentId { get; set; }
        [Display(Name = "Select Course")]
        [Required(ErrorMessage = "Please! select your Course")]
        public int CourseId { get; set; }
        [Display(Name = "Select Greade Letter")]
        [Required(ErrorMessage = "Please! select your Grade")]
        public string GradeId { get; set; }
        public string Action { get; set; }
    }
}