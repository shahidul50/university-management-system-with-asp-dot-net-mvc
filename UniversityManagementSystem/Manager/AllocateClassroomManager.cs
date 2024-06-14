using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class AllocateClassroomManager
    {
        private AllocateClassroomGateway allocateClassroomGateway;

        public AllocateClassroomManager()
        {
            allocateClassroomGateway= new AllocateClassroomGateway();
        }

        public List<Rooms> GetAllRooms()
        {
            return allocateClassroomGateway.GetAllRooms();
        }


        public List<SelectListItem> GetAllRoomForDropdown()
        {
            List<Rooms> roomses = GetAllRooms();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select Room--",
                Value = ""
            });
            foreach (Rooms room in roomses)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = room.RoomNumber;
                selectListItem.Value = room.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }


        public List<Days> GetAllDays()
        {
            return allocateClassroomGateway.GetAllDays();
        }

        public List<SelectListItem> GetAllDayForDropdown()
        {
            List<Days> dayses = GetAllDays();

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select Day--",
                Value = ""
            });
            foreach (Days days in dayses)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = days.Day;
                selectListItem.Value = days.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }
    }
}