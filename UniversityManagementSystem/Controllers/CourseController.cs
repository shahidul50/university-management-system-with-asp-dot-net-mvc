using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private DepartmentManager departmentManager;
        private CourseManager courseManager;

        public CourseController()
        {
            departmentManager = new DepartmentManager();
            courseManager = new CourseManager();
        }
        //
        // GET: /Course/
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.Semesters = departmentManager.GetAllSemesterForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Course course)
        {
            if (ModelState.IsValid)
            {
                string message = courseManager.Save(course);
                ViewBag.Message = message;
                if (message.Equals("Save Sucessfull"))
                {
                    ModelState.Clear();
                }
            }
            else
            {
                ViewBag.Message = "Modal state is not Valid";
            
            }
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.Semesters = departmentManager.GetAllSemesterForDropdown();
            return View();
        }
        [HttpGet]
        public ActionResult CourseDetails()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }

        public JsonResult CourseDetailsByDepartment(int id)
        {
            List<AssignCourseView> assignCourseViews = courseManager.GetCourseStatics(id);
            return Json(assignCourseViews);
        }
	}
}