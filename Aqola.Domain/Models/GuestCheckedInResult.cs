using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Models
{
    public class GuestCheckedInResult : ResultBase
    {
        public Guest GuestAlreadyCheckedIn { get; set; }

        public GuestCheckedInResult(string message, Guest guestAlreadCheckedIn) : base(message)
        {
            GuestAlreadyCheckedIn = guestAlreadCheckedIn;
        }
    }
}
