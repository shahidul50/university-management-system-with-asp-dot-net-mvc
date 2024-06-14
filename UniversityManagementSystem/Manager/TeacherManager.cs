using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway;

        public TeacherManager()
        {
            teacherGateway = new TeacherGateway();
        }

        public string Save(Teacher teacher)
        {
            if (teacherGateway.IsExistEmail(teacher))
            {
                return "Email Already Exist!";
            }
            else
            {
                int rowAffect = teacherGateway.Save(teacher);
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

        public List<Designation> GetAllDesignations()
        {
            return teacherGateway.GetAllDesignations();
        }

        public List<SelectListItem> GetAllDesignationForDropdown()
        {
            List<Designation> designations = GetAllDesignations();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (Designation designation in designations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = designation.Name;
                selectListItem.Value = designation.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public List<Teacher> GetAllTeacherById(int departmentId)
        {
            return teacherGateway.GetAllTeacherById(departmentId);
        }

        public Teacher GetTeacherDetailsById(int id)
        {
            return teacherGateway.GetTeacherDetailsById(id);
        }
    }
}