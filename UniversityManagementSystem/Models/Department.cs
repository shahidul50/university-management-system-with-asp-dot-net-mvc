using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please! input department code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Code must be contains between 2 and 7 characters!")]
        public string Code { get; set; }
         [Required(ErrorMessage = "Please! input department Name")]
        public string Name { get; set; }
    }
}