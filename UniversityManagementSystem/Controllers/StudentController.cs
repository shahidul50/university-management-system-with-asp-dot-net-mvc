using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private StudentManager studentManager;
        private DepartmentManager departmentManager;

        public StudentController()
        {
            studentManager = new StudentManager();
            departmentManager = new DepartmentManager();
        }
        //
        // GET: /Student/
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Student student)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = studentManager.Save(student);
                ViewBag.StudentDetails = studentManager.GetStudent(student);
                ModelState.Clear();
            }
            else
            {
                ViewBag.Meassage = "ModalState is Invalid!";
            }
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }



        //Enroll Course Start----------
        [HttpGet]
        public ActionResult EnrollCourse()
        {
            ViewBag.RegistrationNum = studentManager.GetAllRegistrationForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult EnrollCourse(EnrollCourse enrollCourse)
        {
            if (ModelState.IsValid)
            {
                enrollCourse.Action = "Insert";
                ViewBag.Message = studentManager.SaveEnrollCourse(enrollCourse);
                ModelState.Clear();

            }
            else
            {
                ViewBag.Message = "Model State is Invalid";
            }
            ViewBag.RegistrationNum = studentManager.GetAllRegistrationForDropdown();
            return View();
        }

        public JsonResult GetStudentDetailsById(int id)
        {
            GetDetailsStudentView getDetailsStudent = studentManager.GetAllStudentDetails(id);
            return Json(getDetailsStudent);
        }

        public JsonResult GetAllCourseByStudentId(int id)
        {
            List<GetCourseView> getCourseViews = studentManager.GetAllCourseByStudentId(id);
            return Json(getCourseViews);
        }

        //Student Result-----

        [HttpGet]
        public ActionResult StudentResult()
        {
           
            ViewBag.RegistrationNum = studentManager.GetRegistrationForDropdown();
            ViewBag.GradeLetters = studentManager.GetGradeLetterForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult StudentResult(Result result)
        {
            if (ModelState.IsValid)
            {
                result.Action = "Insert";
                ViewBag.Message = studentManager.SaveResult(result);
                ModelState.Clear();
            }
            else
            {
                ViewBag.Message = "Model State is Invalid!";
            }
            ViewBag.RegistrationNum = studentManager.GetRegistrationForDropdown();
            ViewBag.GradeLetters = studentManager.GetGradeLetterForDropdown();
            return View();
        }

        public JsonResult GetStudentById(int id)
        {
            GetResultView getResultView = studentManager.GetStudentDetails(id);
            return Json(getResultView);
        }

        public JsonResult GetCourseByStudentId(int id)
        {
            List<GetResultView> getResultViews = studentManager.GetCourseByStudentId(id);
            return Json(getResultViews);
        }
        //Result View---------
        [HttpGet]
        public ActionResult ResultView()
        {
            ViewBag.RegistrationNum = studentManager.GetRegistrationNumberForDropdown();
            return View();
        }
        
        public JsonResult GetResultView(int studentId)
        {
            List<ResultView> resultViews = studentManager.GetDetailsStudentResult(studentId);
            return Json(resultViews);
        }

        public JsonResult GetOneResultView(int studentId)
        {
            ResultView resultView = studentManager.GetOneStudentResult(studentId);
            return Json(resultView);
        }
    }
}