using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Models
{
    public class GuestCheckedInResult : ResultBase
    {
        public Guest GuestWhoCheckedIn { get; set; }
        public Room BookedRoom { get; set; }

        public GuestCheckedInResult(string message, Room bookedRoom) : base(message)
        {
            BookedRoom = bookedRoom;
            GuestWhoCheckedIn = bookedRoom.Guest;
        }
    }
}
