using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Models
{
    public class RoomNotAvailableException : Exception
    {
        public RoomNotAvailableException(string roomName,string newGuestName, string nameOfGuestWhoBookedRoom)
            : base($"Cannot book room {roomName} for {newGuestName}, The room is currently booked by {nameOfGuestWhoBookedRoom}.")
        {

        }
    }
}
