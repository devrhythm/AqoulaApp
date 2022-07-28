using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Models
{
    public class RoomNotAvailableException : Exception
    {
        public RoomNotAvailableException(string guestName, Room room)
            : base($"Cannot book room {room.RoomName} for {guestName}, The room is currently booked by {room.GuestName}")
        {

        }
    }
}
