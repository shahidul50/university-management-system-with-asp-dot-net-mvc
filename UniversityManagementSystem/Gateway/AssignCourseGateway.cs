using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class AssignCourseGateway: BaseGateway
    {
        public int Save(AssignCourse assignCourse)
        {
            string query = "Insert into AssignCourse values(@DepartmentId,@TeacherId,@CourseId,@Action)";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@DepartmentId", assignCourse.DepartmentId);
            Command.Parameters.AddWithValue("@TeacherId", assignCourse.TeacherId);
            Command.Parameters.AddWithValue("@CourseId", assignCourse.CourseId);
            Command.Parameters.AddWithValue("@Action", assignCourse.Action);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool isExistCourseByTeacher(AssignCourse assignCourse)
        {
            string query = "select * from AssignCourse Where DepartmentId= " + assignCourse.DepartmentId + " and TeacherId=" + assignCourse.TeacherId + " and CourseId="+assignCourse.CourseId+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return isExist;
        }

       

    }
}