using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AllocateClassroom
    {

        public int Id { get; set; }
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please! select your Department")]
        public int DeprtmentId { get; set; }
        [Display(Name = "Course")]
        [Required(ErrorMessage = "Please! select your course")]
        public int CourseId { get; set; }
        [Display(Name = "Room No")]
        [Required(ErrorMessage = "Please! select your Room")]
        public int RoomId { get; set; }
        [Display(Name = "Day")]
        [Required(ErrorMessage = "Please! select your Day")]
        public int DayId { get; set; }
        [Display(Name = "From")]
        [Required(ErrorMessage = "Please! select your From Tome")]
        public string FromTime { get; set; }
        [Display(Name = "To")]
        [Required(ErrorMessage = "Please! select your To time")]
        public string ToTime { get; set; }
        public string Action { get; set; }
    }
}