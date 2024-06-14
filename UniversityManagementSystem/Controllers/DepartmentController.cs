using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {

        //
        // GET: /Department/
        private DepartmentManager departmentManager;

        public DepartmentController()
        {
            departmentManager = new DepartmentManager();
        }
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Department department)
        {
            if (ModelState.IsValid)
            {
                string message = departmentManager.Save(department);
                ViewBag.Message = message;
                if (message.Equals("Save Sucessfull"))
                {
                    ModelState.Clear();
                }
                
            }
            else
            {
                ViewBag.Message = "Modal Sate is not valid!";
            }
           
            return View();
        }

        public ActionResult GetDepartments()
        {
          ViewBag.Departments =  departmentManager.GetAllDepartments();
            return View();
        }
	}
}