using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Models
{
    public class Room
    {
        private const int DefaultKeycardNo = -1;
        public int RoomNo { get; private set; }
        public Floor Floor { get; private set; }
        public string RoomName { get; private set; }
        public string GuestName { get; private set; } = "";
        public int KeycardNo { get; private set; } = DefaultKeycardNo;
        public bool IsAvailable { get; private set; } = true;

        public Room(int roomNo, Floor floor)
        {
            this.RoomNo = roomNo;
            this.Floor = floor;
            this.RoomName = $"{Floor.FloorNo}{RoomNo:00}";
        }

        public void CheckIn(string guestName)
        {
            if (!IsAvailable)
            {
                throw new RoomNotAvailableException(guestName, this);
            }
            IsAvailable = false;
            GuestName = guestName;
        }

        public void Checkout()
        {
            IsAvailable = true;
            GuestName = "";
            KeycardNo = DefaultKeycardNo;
        }

        public bool IsValidKeycard(int keycardNo)
        {
           return keycardNo == KeycardNo;
        }

        public void GrantAccessByKeycard(int keycardNo)
        {
            KeycardNo = keycardNo;
        }
    }
}
