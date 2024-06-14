using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
        private DepartmentGateway departmentGateway;

        public StudentManager()
        {
            studentGateway = new StudentGateway();
            departmentGateway = new DepartmentGateway();
        }
        public string Save(Student student)
        {
            

            if (studentGateway.IsExistEmailByStudent(student))
            {
                return "Email Already Exist";
            }
            else
            {

                int count = 0;
                Department department = departmentGateway.GetDepartmentCodeById(student.DepartmentId);
                string key = department.Code + "-" + DateTime.Now.Year + "-";
                string lastAddRegNo = studentGateway.GetLastAddStudentReg(key);
                if (lastAddRegNo == null)
                {
                    student.RegistrationNumber = key + "001";
                }
                if (lastAddRegNo != null)
                {
                    string tempId = lastAddRegNo.Substring((lastAddRegNo.Length - 3), 3);
                    count = Convert.ToInt32(tempId);
                    string studentSerialNumber = (count + 1).ToString();


                    if (studentSerialNumber.Length == 1)
                    {

                        student.RegistrationNumber = key + "00" + studentSerialNumber;

                    }
                    else if (studentSerialNumber.Count() == 2)
                    {

                        student.RegistrationNumber = key + "0" + studentSerialNumber;
                    }
                    else
                    {

                        student.RegistrationNumber = key + studentSerialNumber;
                    }

                }

                int rowAffect = studentGateway.Save(student);
                if (rowAffect > 0)
                {
                    GetStudent(student);
                    return "Save Sucessfull";
                }
                else
                {
                    return "Save Faild!";
                }
            }
        }

        public Student GetStudent(Student student)
        {
            return student;
        }

        public List<Student> GetAllRegistrtionNumber()
        {
            return studentGateway.GetAllRegistrtionNumber();
        }

        public List<SelectListItem> GetAllRegistrationForDropdown()
        {
            List<Student> students = GetAllRegistrtionNumber();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select RegNo--",
                Value = ""
            });
            foreach (Student student in students)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = student.RegistrationNumber;
                selectListItem.Value = student.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }


        public string SaveEnrollCourse(EnrollCourse enrollCourse)
        {
            if (studentGateway.IsExistCourseByStudent(enrollCourse))
            {
                return "Student Already Taken This Course";
            }
            else
            {
                int rowAffect = studentGateway.SaveEnrollCourse(enrollCourse);
                if (rowAffect > 0)
                {
                    return "Save Sucessfull";
                }
                else
                {
                    return "Save Faild!";
                }
            }
        }


        public GetDetailsStudentView GetAllStudentDetails(int id)
        {
            return studentGateway.GetAllStudentDetails(id);
        }

        public List<GetCourseView> GetAllCourseByStudentId(int id)
        {
            return studentGateway.GetAllCourseByStudentId(id);
        }


        //Student Result---------

        public string SaveResult(Result result)
        {

            if (studentGateway.IsExistCourseResultByStudent(result))
            {
                return "This student taken his Course Grade Already!";
            }
            else
            {
                int rowAffect = studentGateway.SaveResult(result);
                if (rowAffect > 0)
                {
                    return "Save Sucessfull";
                }
                else
                {
                    return "Save Faild!";
                }
            }
           
        }


        public List<GetResultView> GetRegistrtionNumber()
        {
            return studentGateway.GetRegistrtionNumber();
        }

        public List<SelectListItem> GetRegistrationForDropdown()
        {
            List<GetResultView> students = GetRegistrtionNumber();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select RegNo--",
                Value = ""
            });
            foreach (GetResultView student in students)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = student.RegistrationNumber;
                selectListItem.Value = student.StudentId.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public GetResultView GetStudentDetails(int id)
        {
            return studentGateway.GetStudentDetails(id);
        }

        public List<GetResultView> GetCourseByStudentId(int id)
        {
            return studentGateway.GetCourseByStudentId(id);
        }


        public List<GradeLetter> GetGradeLetters()
        {
            return studentGateway.GetGradeLetters();
        }


        public List<SelectListItem> GetGradeLetterForDropdown()
        {
            List<GradeLetter> gradeLetters = GetGradeLetters();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select Grade--",
                Value = ""
            });
            foreach (GradeLetter grade in gradeLetters)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = grade.Name;
                selectListItem.Value = grade.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
        //Result View-------------

        public List<ResultView> RegistrtionNumberForResultViews()
        {
            return studentGateway.RegistrtionNumberForResultViews();
        }

        public List<SelectListItem> GetRegistrationNumberForDropdown()
        {
            List<ResultView> resultViews = RegistrtionNumberForResultViews();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select Reg No--",
                Value = ""
            });
            foreach (ResultView resultView in resultViews)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = resultView.RegistrationNumber;
                selectListItem.Value = resultView.StudentId.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public List<ResultView> GetDetailsStudentResult(int id)
        {
            return studentGateway.GetDetailsStudentResult(id);
        }

        public ResultView GetOneStudentResult(int id)
        {
            return studentGateway.GetOneStudentResult(id);
        }
    }
}