using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            if (DepartmentGateway.IsExistCode(department))
            {
                return "Deprtment code already exist";
            }
            else
            {
                if (DepartmentGateway.IsExistName(department))
                {
                    return "Deprtment name already exist";
                }
                else
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

        public List<Department> GetAllDepartments()
        {
            return DepartmentGateway.GetAllDepartments();
        }

        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            List<Department> departments = GetAllDepartments();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text =  "--Select Department--",
                Value = ""
            });
            foreach (Department department in departments)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = department.Code;
                selectListItem.Value = department.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public List<Semester> GetAllSemesters()
        {
            return DepartmentGateway.GetAllSemesters();
        }

        public List<SelectListItem> GetAllSemesterForDropdown()
        {
            List <Semester> semesters = GetAllSemesters();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (Semester semester in semesters)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = semester.Id.ToString();
                selectListItem.Text = semester.Name;
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        } 
    }
}