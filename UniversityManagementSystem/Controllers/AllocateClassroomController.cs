using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class AllocateClassroomController : Controller
    {
        private DepartmentManager departmentManager;
        private CourseManager courseManager;
        private AllocateClassroomManager allocateClassroomManager;

        public AllocateClassroomController()
        {
            departmentManager = new DepartmentManager();
            courseManager = new CourseManager();
            allocateClassroomManager = new AllocateClassroomManager();
        }

        //
        // GET: /AllocateClassroom/
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.Rooms = allocateClassroomManager.GetAllRoomForDropdown();
            ViewBag.Days = allocateClassroomManager.GetAllDayForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(AllocateClassroom allocateClassroom)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {
                ViewBag.Message = "ModelState is Invalid!";
            }

            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.Rooms = allocateClassroomManager.GetAllRoomForDropdown();
            ViewBag.Days = allocateClassroomManager.GetAllDayForDropdown();
            return View();
        }

        public JsonResult GetAllCourseByDepartmentId(int departmentId)
        {
            List<Course> courses = courseManager.GetAllCourseByDepartmentId(departmentId);
            return Json(courses);
        }


        //View Class Schedule-------

        public ActionResult ViewClassSchedule()
        {
            return View();
        }
	}
}