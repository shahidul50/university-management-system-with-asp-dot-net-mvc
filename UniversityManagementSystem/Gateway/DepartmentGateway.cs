using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class DepartmentGateway : BaseGateway
    {
        public int Save(Department department)
        {
            string query = "INSERT INTO Department VALUES(@Code,@Name)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Add("@Code", department.Code);
            Command.Parameters.Add("@Name", department.Name);
            Connection.Open();
            int rowaffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffect;
        }

        public List<Department> GetAllDepartments()
        {
            string query = "Select * from Department";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            Department department = null;
            while (Reader.Read())
            {
                department = new Department();
                department.Id = Convert.ToInt32(Reader["Id"]);
                department.Code = Reader["Code"].ToString();
                department.Name = Reader["Name"].ToString();
                departments.Add(department);
            }
            Reader.Close();
            Connection.Close();
            return departments;
        }

        public List<Semester> GetAllSemesters()
        {
            string query = "Select * from Semester";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            Semester semester = null;
            while (Reader.Read())
            {
                semester = new Semester();
                semester.Id = Convert.ToInt32(Reader["Id"]);
                semester.Name = Reader["Name"].ToString();
                semesters.Add(semester);
            }
            Reader.Close();
            Connection.Close();
            return semesters;
        }

        public bool IsExistCode(Department department)
        {
            string query = "Select * from Department where Code='"+department.Code+"'";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }
        public bool IsExistName(Department department)
        {
            string query = "Select * from Department where Name='" + department.Name + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }

        public Department GetDepartmentCodeById(int id)
        {
            string query = "Select * from Department where Id="+id+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Department department = null;
            if (Reader.Read())
            {
                department = new Department();
                department.Code = Reader["Code"].ToString();
            }
            Connection.Close();
            return department;
        }
    }
}