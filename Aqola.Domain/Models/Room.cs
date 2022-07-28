using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Models
{
    public class Room
    {
        public int RoomNo { get; private set; }
        public Floor Floor { get; private set; }
        public string RoomName { get; private set; }

        public Room(int roomNo, Floor floor)
        {
            this.RoomNo = roomNo;
            this.Floor = floor;
            this.RoomName = $"{Floor.FloorNo}{RoomNo:00}";
        }
    }
}
