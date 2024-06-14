using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class CourseManager
    {
        private CourseGateway courseGateway;

        public CourseManager()
        {
            courseGateway = new CourseGateway();
        }

        public string Save(Course course)
        {
            if (courseGateway.IsExistCourseCode(course))
            {
                return "Course Code Already Exist!";
            }
            else
            {
                if (courseGateway.IsExistCourseName(course))
                {
                    return "This Department Course Name is Already Exist!";
                }
                else
                {
                    int rowAffect = courseGateway.Save(course);
                    if (rowAffect > 0)
                    {
                        return "Save Sucessfull";
                    }
                    else
                    {
                        return "Save Faild!!";
                    }
                }
            }
        }

        public List<Course> GetAllCourseByDepartmentId(int departmentId)
        {
            return courseGateway.GetAllCourseByDepartmentId(departmentId);
        }

        public Course GetCourseDetailsId(int id)
        {
            return courseGateway.GetCourseDetailsId(id);
        }

        public List<AssignCourseView> GetCourseStatics(int departmentId)
        {
            return courseGateway.GetCourseStatics(departmentId);
        }
    }
}