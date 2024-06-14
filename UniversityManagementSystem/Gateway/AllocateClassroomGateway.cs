using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class AllocateClassroomGateway: BaseGateway
    {
        public List<Rooms> GetAllRooms()
        {
            string query = "Select * from Rooms";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Rooms> roomses = new List<Rooms>();
            Rooms room = null;
            while (Reader.Read())
            {
                room = new Rooms();
                room.Id = Convert.ToInt32(Reader["Id"]);
                room.RoomNumber = Reader["RoomNumber"].ToString();
                roomses.Add(room);
            }
            Reader.Close();
            Connection.Close();
            return roomses;
        }

        public List<Days> GetAllDays()
        {
            string query = "Select * from Days";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Days> dayses = new List<Days>();
            Days days = null;
            while (Reader.Read())
            {
                days = new Days();
                days.Id = Convert.ToInt32(Reader["Id"]);
                days.Day = Reader["Day"].ToString();
                dayses.Add(days);
            }
            Reader.Close();
            Connection.Close();
            return dayses;
        }
    }
}