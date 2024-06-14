using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class AssignCourseController : Controller
    {
        private AssignCourseManager assignCourseManager;
        private DepartmentManager departmentManager;
        private TeacherManager teacherManager;
        private CourseManager courseManager;


        public AssignCourseController()
        {
            assignCourseManager = new AssignCourseManager();
            departmentManager = new DepartmentManager();
            teacherManager = new TeacherManager();
            courseManager = new CourseManager();
        }
        //
        // GET: /AssignCourse/
        [HttpGet]
        public ActionResult Save()
        {
           ViewBag.Departments =  departmentManager.GetAllDepartmentForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(AssignCourse assignCourse)
        {
            if (ModelState.IsValid)
            {
                assignCourse.Action = "Insert";
                string message = assignCourseManager.Save(assignCourse);
                ViewBag.Message = message;
                if (ViewBag.Message.Equals("Save Sucessfull"))
                {
                    ModelState.Clear();
                }
                else if (ViewBag.Message.Equals("Teacher Already Taken This Course"))
                {
                    ModelState.Clear();
                }
            }
            else
            {
                ViewBag.Message = "ModelState is Invalid";
            }
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }

        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            List<Teacher> teachers = teacherManager.GetAllTeacherById(departmentId);
            List<Course> courses = courseManager.GetAllCourseByDepartmentId(departmentId);
            return Json(teachers);
        }

        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            List<Course> courses = courseManager.GetAllCourseByDepartmentId(departmentId);
            return Json(courses);
        }

        public JsonResult GetCourseDetailsById(int id)
        {
            Course course = courseManager.GetCourseDetailsId(id);
            return Json(course);
        }

        public JsonResult GetTeacherDetailsById(int id)
        {
            Teacher teacher = teacherManager.GetTeacherDetailsById(id);
            return Json(teacher);
        }
	}
}