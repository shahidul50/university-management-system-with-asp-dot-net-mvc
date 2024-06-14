using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please!Input your name!")]
        public string Name { get; set; }
         [Required(ErrorMessage = "Please!Input your email!")]
        [EmailAddress(ErrorMessage = "Please! Input a Valided Email")]
        public string Email { get; set; }
         [Required(ErrorMessage = "Please!Input your Contact Number!")]
         [Display(Name = "Contact No")]
        [Range(0,10000000000,ErrorMessage = "Must be 11 Number")]
        public string ContactNo { get; set; }
         [Required(ErrorMessage = "Please!Input Current Date!")]
       
        public string Date { get; set; }
         [Required(ErrorMessage = "Please!Input your Address!")]
        public string Address { get; set; }
        [Display(Name = "Department")]
         [Required(ErrorMessage = "Please!select your Department!")]
        public int DepartmentId { get; set; }
        public string RegistrationNumber { get; set; }
    }
}