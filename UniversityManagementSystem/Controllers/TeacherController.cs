using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private TeacherManager teacherManager;
        private DepartmentManager departmentManager;

        public TeacherController()
        {
            teacherManager = new TeacherManager();
            departmentManager = new DepartmentManager();
        }
        //
        // GET: /Teacher/
        [HttpGet]
        public ActionResult Save()
        {
           ViewBag.Designations = teacherManager.GetAllDesignationForDropdown();
           ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();

            return View();
        }
        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                string message = teacherManager.Save(teacher);
                ViewBag.Message = message;
                if (message.Equals("Save Sucessfull"))
                {
                    ModelState.Clear();
                }
            }
            else
            {
                ViewBag.Message = "Modal State is null!"; 
            }

            ViewBag.Designations = teacherManager.GetAllDesignationForDropdown();
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }
	}
}