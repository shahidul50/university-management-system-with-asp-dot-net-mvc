using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class StudentGateway:BaseGateway
    {
        public int Save(Student student)
        {
            string query = "INSERT INTO Student VALUES(@Name,@Email,@ContactNo,@Date,@Address,@DepartmentId,@RegistrationNumber)";
            Command = new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@Name", student.Name);
            Command.Parameters.AddWithValue("@Email", student.Email);
            Command.Parameters.AddWithValue("@ContactNo", student.ContactNo);
            Command.Parameters.AddWithValue("@Date", student.Date);
            Command.Parameters.AddWithValue("@Address", student.Address);
            Command.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);
            Command.Parameters.AddWithValue("@RegistrationNumber", student.RegistrationNumber);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public string GetLastAddStudentReg(string key)
        {
            string query = "SELECT * FROM Student  WHERE RegistrationNumber LIKE '%"+key+"%' and Id=(select Max(Id) FROM Student WHERE RegistrationNumber LIKE '%"+key+"%' )";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Student student = null;
            string regNo = null;
            Reader= Command.ExecuteReader();
            if (Reader.Read())
            {
                student = new Student();
                student.Id = Convert.ToInt32(Reader["Id"].ToString());
                student.Name = Reader["Name"].ToString();
                student.RegistrationNumber = Reader["RegistrationNumber"].ToString();
                student.Email = Reader["Email"].ToString();
                student.ContactNo = Reader["ContactNo"].ToString();
                regNo = student.RegistrationNumber;
            }
            Reader.Close();
            Connection.Close();
            return regNo;
        }

        public bool IsExistEmailByStudent(Student student)
        {
            string query = "select * from Student where Email = '"+student.Email+"'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return isExist;
        }

        //Enroll Course-----
        public List<Student> GetAllRegistrtionNumber()
        {
            string query = "select Id,RegistrationNumber from Student";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<Student> students = new List<Student>();
            Student student = null;
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                student = new Student();
                student.Id = Convert.ToInt32(Reader["Id"].ToString());
                student.RegistrationNumber = Reader["RegistrationNumber"].ToString();
                students.Add(student);
            }
            Reader.Close();
            Connection.Close();
            return students; 
        }

      

        public int SaveEnrollCourse(EnrollCourse enrollCourse)
        {
            string query = "insert into EnrollCourse values(@StudentId,@CourseId,@Date,@Action)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@StudentId", enrollCourse.StudentId);
            Command.Parameters.AddWithValue("@CourseId", enrollCourse.CourseId);
            Command.Parameters.AddWithValue("@Date", enrollCourse.Date);
            Command.Parameters.AddWithValue("@Action", enrollCourse.Action);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }



        public GetDetailsStudentView GetAllStudentDetails(int id)
        {
            string query = "select * from GetDetailsStudentView where id = " + id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            GetDetailsStudentView student = null;
            Reader = Command.ExecuteReader();
            if(Reader.Read())
            {
                student = new GetDetailsStudentView();
                student.Name = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
                student.Code = Reader["Code"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return student;
        }

        public List<GetCourseView> GetAllCourseByStudentId(int id)
        {
            string query = "select * from GetCourseView where StudentId="+id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<GetCourseView> getCourseViews = new List<GetCourseView>();
            GetCourseView getCourseView = null;
            Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                getCourseView = new GetCourseView();
                getCourseView.CourseId = Convert.ToInt32(Reader["CourseId"].ToString());
                getCourseView.CourseName = Reader["CourseName"].ToString();
                getCourseViews.Add(getCourseView);
            }
            Reader.Close();
            Connection.Close();
            return getCourseViews;
        }

        public bool IsExistCourseByStudent(EnrollCourse enrollCourse)
        {
            string query = "select * from EnrollCourse where studentid ="+enrollCourse.StudentId+" and CourseId="+enrollCourse.CourseId+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return isExist;
        }

        //Student Result--------


        public int SaveResult(Result result)
        {
            string query = "insert into Result values(@StudentId,@CourseId,@GradeId,@Action)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@StudentId", result.StudentId);
            Command.Parameters.AddWithValue("@CourseId", result.CourseId);
            Command.Parameters.AddWithValue("@GradeId", result.GradeId);
            Command.Parameters.AddWithValue("@Action", result.Action);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsExistCourseResultByStudent(Result result)
        {
            string query = "select * from Result where StudentId="+result.StudentId+" and CourseId="+result.CourseId+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return isExist;
        }
        public List<GetResultView> GetRegistrtionNumber()
        {
            string query = "select DISTINCT StudentId,RegistrationNumber from GetResultView";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<GetResultView> students = new List<GetResultView>();
            GetResultView student = null;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                student = new GetResultView();
                student.StudentId = Convert.ToInt32(Reader["studentId"].ToString());
                student.RegistrationNumber = Reader["RegistrationNumber"].ToString();
                students.Add(student);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }

        public GetResultView GetStudentDetails(int id)
        {
            string query = "select * from GetResultView where StudentId = " + id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            GetResultView student = null;
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                student = new GetResultView();
                student.StudentName = Reader["StudentName"].ToString();
                student.Email = Reader["Email"].ToString();
                student.Code = Reader["Code"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return student;
        }


        public List<GetResultView> GetCourseByStudentId(int id)
        {
            string query = "select * from GetResultView where StudentId=" + id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<GetResultView> getCourseViews = new List<GetResultView>();
            GetResultView getCourseView = null;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                getCourseView = new GetResultView();
                getCourseView.CourseId = Convert.ToInt32(Reader["CourseId"].ToString());
                getCourseView.CourseName = Reader["CourseName"].ToString();
                getCourseViews.Add(getCourseView);
            }
            Reader.Close();
            Connection.Close();
            return getCourseViews;
        }

        public List<GradeLetter> GetGradeLetters()
        {
            string query = "select * from GradeLetter";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<GradeLetter> gradeLetters = new List<GradeLetter>();
            GradeLetter grade = null;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                grade = new GradeLetter();
                grade.Id = Convert.ToInt32(Reader["Id"].ToString());
                grade.Name = Reader["Name"].ToString();
                gradeLetters.Add(grade);
            }
            Reader.Close();
            Connection.Close();
            return gradeLetters;
        }
          
        //Result View -------------

        public List<ResultView> RegistrtionNumberForResultViews()
        {
            string query = "select Distinct StudentId,RegistrationNumber from ResultView";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<ResultView> resultViews = new List<ResultView>();
            ResultView resultView = null;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                resultView = new ResultView();
                resultView.StudentId = Convert.ToInt32(Reader["studentId"].ToString());
                resultView.RegistrationNumber = Reader["RegistrationNumber"].ToString();
                resultViews.Add(resultView);
            }
            Reader.Close();
            Connection.Close();
            return resultViews;
        }

        public List<ResultView> GetDetailsStudentResult(int id)
        {
            string query = "select *  from ResultView where studentId="+id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<ResultView> resultViews = new List<ResultView>();
            ResultView resultView = null;
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                resultView = new ResultView();
                resultView.CourseCode = Reader["CourseCode"].ToString();
                resultView.CourseName = Reader["CourseName"].ToString();
                resultView.Grade = Reader["Grade"].ToString();
                resultViews.Add(resultView);
            }
            Reader.Close();
            Connection.Close();
            return resultViews;
        }

        public ResultView GetOneStudentResult(int id)
        {
            string query = "select *  from ResultView where studentId=" + id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            ResultView resultView = null;
            Reader = Command.ExecuteReader();
            if(Reader.Read())
            {
                resultView = new ResultView();
                resultView.StudentName = Reader["studentName"].ToString();
                resultView.Email = Reader["Email"].ToString();
                resultView.DepartmentCode = Reader["DepartmentCode"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return resultView;
        }
    }
}