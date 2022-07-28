using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Models
{
    public class CheckedOutResult : ResultBase
    {
        public Keycard? ReturnedKeycard { get; }
        public Room? CheckoutRoom { get; }

        public CheckedOutResult(string message) : base(message)
        {
        }

        public CheckedOutResult(string message, Keycard returnedKeycard, Room checkoutRoom) : base(message)
        {
            ReturnedKeycard = returnedKeycard;
            CheckoutRoom = checkoutRoom;
        }

    }
}
