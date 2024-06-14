using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class DepartmentManager
    {
        public DepartmentGateway DepartmentGateway { get; set; }

        public DepartmentManager()
        {
            DepartmentGateway = new DepartmentGateway();
        }

        public string Save(Department department)
        {
            int rowAffect = DepartmentGateway.Save(department);
            if (rowAffect > 0)
            {
                return "Save Sucessfull";
            }
            else
            {
                return "Save Faild";
            }
        }
    }
}