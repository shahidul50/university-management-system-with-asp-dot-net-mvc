using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class CourseGateway: BaseGateway
    {
        public int Save(Course course)
        {
            string query = "INSERT INTO Course VALUES(@Code,@Name,@Credit,@Description,@DepartmentId,@SemesterId)";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.Add("@Code", course.Code);
            Command.Parameters.Add("@Name", course.Name);
            Command.Parameters.Add("@Credit", course.Credit);
            Command.Parameters.Add("@Description", course.Description);
            Command.Parameters.Add("@DepartmentId", course.DepartmentId);
            Command.Parameters.Add("@SemesterId", course.SemesterId);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsExistCourseCode(Course course)
        {
            string query = "select * from Course where Code = '"+course.Code+"'";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Boolean isExist = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return isExist;
        }

        public bool IsExistCourseName(Course course)
        {
            string query = "select * from  Course where Name ='"+course.Name+"' and DepartmentId = "+course.DepartmentId+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Boolean isExist = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return isExist;
        }

        public List<Course> GetAllCourseByDepartmentId(int departmentId)
        {
            string query = "Select * from Course where DepartmentId=" + departmentId;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            Course course = null;
            while (Reader.Read())
            {
                course = new Course();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Name = Reader["Name"].ToString();
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public Course GetCourseDetailsId(int id)
        {
            string query = "Select * from Course where Id=" + id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Course course = null;
            if(Reader.Read())
            {
                course = new Course();
                course.Credit = Convert.ToInt32(Reader["Credit"]);
                course.Name = Reader["Name"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return course;
        }

        public float GetCreditByCourseId(int id)
        {
            string query = "Select Credit from Course where Id=" + id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Course course = null;
            if(Reader.Read())
            {
                course = new Course();
                course.Credit = Convert.ToInt32(Reader["Credit"]);
            }
            Reader.Close();
            Connection.Close();
            float credit = course.Credit;
            return credit;
        }


        public List<AssignCourseView> GetCourseStatics(int departmentId)
        {
            string query = "select * from AssignCourseView where DepartmentId = " + departmentId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AssignCourseView> assignCourseViews = new List<AssignCourseView>();
            AssignCourseView assignCourseView = null;
            while (Reader.Read())
            {
                assignCourseView = new AssignCourseView();
                assignCourseView.Code = Reader["Code"].ToString();
                assignCourseView.Name = Reader["Name"].ToString();
                assignCourseView.Semester = Reader["Semester"].ToString();
                assignCourseView.TeacherName = Reader["TeacherName"].ToString();
                assignCourseViews.Add(assignCourseView);
            }
            Reader.Close();
            Connection.Close();
            return assignCourseViews;
        }
    }
}