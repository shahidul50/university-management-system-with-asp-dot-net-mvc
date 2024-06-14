using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityManagementSystem.Gateway
{
    public class BaseGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        public BaseGateway()
        {
            string constring = WebConfigurationManager.ConnectionStrings["UniversityManagementSystemDB"].ConnectionString;
            Connection = new SqlConnection(constring);
        }
    }
}