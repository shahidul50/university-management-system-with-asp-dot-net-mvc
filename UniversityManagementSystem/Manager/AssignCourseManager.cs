using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class AssignCourseManager
    {
        private AssignCourseGateway assignCourseGateway;
        private CourseGateway courseGateway;
        private TeacherGateway teacherGateway;

        public AssignCourseManager()
        {
            assignCourseGateway = new AssignCourseGateway();
            courseGateway = new CourseGateway();
            teacherGateway = new TeacherGateway();
        }

        public string Save(AssignCourse assignCourse)
        {
            if (assignCourseGateway.isExistCourseByTeacher(assignCourse))
            {
                return "Teacher Already Taken This Course";
            }
            else
            {
                int id = assignCourse.CourseId;
                int teacherId = assignCourse.TeacherId;
                float courseCredit = courseGateway.GetCreditByCourseId(id);
                Teacher teacher = teacherGateway.GetTeacherDetailsById(teacherId);
                float creditTobeTaken = teacher.CreditTaken;
                float avilableCredit = teacher.RemainingCredit - courseCredit;
             
                if (avilableCredit > 0)
                {
                    teacher.Id = teacherId;
                    teacher.RemainingCredit = avilableCredit;
                   
                    int rowAffect = assignCourseGateway.Save(assignCourse);
                    if (rowAffect > 0)
                    {
                        teacherGateway.Update(teacher);
                        return "Save Sucessfull";
                    }
                    else
                    {
                        return "Save Faild";
                    }
                }
                else
                {
                    return "Insuddiciant credit";
                }
            }
        }

      
    }
}