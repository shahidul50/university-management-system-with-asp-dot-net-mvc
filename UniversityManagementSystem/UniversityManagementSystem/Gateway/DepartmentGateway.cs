using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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
    
}
}