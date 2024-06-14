using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class TeacherGateway : BaseGateway
    {
        public int Save(Teacher teacher)
        {
            string query = "INSERT INTO Teacher VALUES(@Name,@Address,@Email,@ContactNo,@DesignationId,@DepartmentId,@CreditTaken,@RemainingCredit)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Add("@Name", teacher.Name);
            Command.Parameters.Add("@Address", teacher.Address);
            Command.Parameters.Add("@Email", teacher.Eamil);
            Command.Parameters.Add("@ContactNo", teacher.ContactNo);
            Command.Parameters.Add("@DesignationId", teacher.DesignationId);
            Command.Parameters.Add("@DepartmentId", teacher.DepartmentId);
            Command.Parameters.Add("@CreditTaken", teacher.CreditTaken);
            Command.Parameters.Add("@RemainingCredit", teacher.CreditTaken);
            Connection.Open();
            int rowaffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffect;
        }

        public List<Designation> GetAllDesignations()
        {
            string query = "Select * from Designation";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            Designation designation = null;
            while (Reader.Read())
            {
                designation = new Designation();
                designation.Id = Convert.ToInt32(Reader["Id"]);
                designation.Name = Reader["Name"].ToString();
                designations.Add(designation);
            }
            Reader.Close();
            Connection.Close();
            return designations;
        }

        public bool IsExistEmail(Teacher teacher)
        {
            string query = "select * from Teacher where Email ='" + teacher.Eamil + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return isExist;
        }

        public List<Teacher> GetAllTeacherById(int departmentId)
        {
            string query = "Select * from Teacher where DepartmentId="+departmentId;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            Teacher teacher = null;
            while (Reader.Read())
            {
                teacher = new Teacher();
                teacher.Id = Convert.ToInt32(Reader["Id"]);
                teacher.Name = Reader["Name"].ToString();
                teachers.Add(teacher);
            }
            Reader.Close();
            Connection.Close();
            return teachers;
        }

        public Teacher GetTeacherDetailsById(int id)
        {
            string query = "Select * from Teacher where id=" + id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Teacher teacher = null;
            if(Reader.Read())
            {
                teacher = new Teacher();
                teacher.CreditTaken = Convert.ToInt32(Reader["CreditTaken"]);
                teacher.RemainingCredit = Convert.ToInt32(Reader["RemainingCredit"]);
            }
            Reader.Close();
            Connection.Close();
            return teacher;
        }

        public int Update(Teacher teacher)
        {
            string query = "UPDATE Teacher SET RemainingCredit = "+teacher.RemainingCredit+" where id="+teacher.Id+"";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            int rowaffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffect;
        }
    }
}