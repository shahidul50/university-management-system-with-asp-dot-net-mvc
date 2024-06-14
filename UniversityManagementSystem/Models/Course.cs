using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please! input course code")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Code must be least 5 characters!")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please! input course name")]
        public string Name { get; set; }
         [Required(ErrorMessage = "Please! input course credit")]
        [Range(0.5,5.0,ErrorMessage = "Credit must be between 0.5 to 5.0 ")]
        public float Credit { get; set; }
        [Required(ErrorMessage = "Please! input course description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please! select department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please! select semester")]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
    }
}