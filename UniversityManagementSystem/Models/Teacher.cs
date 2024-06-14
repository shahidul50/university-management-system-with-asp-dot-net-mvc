using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace UniversityManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Input your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Input your address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Input your valided email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address! Enter correct Email address!")]
        public string Eamil { get; set; }
        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "Please Input your contact number")]
        [Range(0,10000000000,ErrorMessage = "must be 11 number!")]
      
        public string ContactNo { get; set; }
        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Please select your designation")]
        public int DesignationId { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please select your department")]
        public int DepartmentId { get; set; }
        [Display(Name = "Credit to be taken")]
        [Range(0, 50, ErrorMessage = "Please! input positive number between 0 to 50")]
        [Required(ErrorMessage = "Please Input credit")]
        public float CreditTaken { get; set; }
        public float RemainingCredit { get; set; }
    }
}