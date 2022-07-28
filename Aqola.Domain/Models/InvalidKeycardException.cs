using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Models
{
    public class InvalidKeycardException : Exception
    {
        public InvalidKeycardException(Room room)
                : base($"Only {room.GuestName} can checkout with keycard number {room.KeycardNo}")
        {
        }
    }
}
