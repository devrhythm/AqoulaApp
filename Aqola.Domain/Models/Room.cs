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
        public Guest Guest { get; private set; } = Guest.DummyGuest();
        public int KeycardNo { get; private set; } = Keycard.DefaultKeycardNo;
        public bool IsAvailable { get; private set; } = true;
        public DateTime? CheckInDate { get; private set; }

        public Room(int roomNo, Floor floor)
        {
            this.RoomNo = roomNo;
            this.Floor = floor;
            this.RoomName = $"{Floor.FloorNo}{RoomNo:00}";
        }

        public void CheckIn(Guest newGuest)
        {
            if (!IsAvailable)
            {
                throw new RoomNotAvailableException(RoomName, newGuest.Name, Guest.Name);
            }
            CheckInDate = DateTime.Now;
            IsAvailable = false;
            Guest = newGuest;
        }

        public void Checkout()
        {
            IsAvailable = true;
            Guest = Guest.DummyGuest();
            KeycardNo = Keycard.DefaultKeycardNo;
            CheckInDate = null;
        }

        public bool IsValidKeycard(int keycardNo, string guestName)
        {
            return KeycardNo == keycardNo && Guest.Name == guestName;
        }

        public void GrantAccessByKeycard(int keycardNo)
        {
            KeycardNo = keycardNo;
        }
    }
}
