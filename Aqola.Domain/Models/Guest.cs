using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Models
{
    public class Guest
    {
        public string Name { get; private set; } = "";
        public int Age { get; private set; } = 0;
        public int KeycardNo { get; private set; } = Keycard.DefaultKeycardNo;
        public string BookedRoomNo { get; private set; } = "";

        private Guest()
        {

        }

        public Guest(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void TakeRoomKeycard(string bookedRoomNo, int keycard)
        {
            BookedRoomNo = bookedRoomNo;
            KeycardNo = keycard;
        }

        public static Guest DummyGuest()
        {
            return new Guest();
        }

        public bool HasKeyCard()
        {
            return KeycardNo != Keycard.DefaultKeycardNo;
        }
    }
}
