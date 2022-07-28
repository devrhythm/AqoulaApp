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
        public string BookedRoomName { get; private set; } = "";

        private Guest()
        {

        }

        public Guest(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void TakeRoomKeycard(string bookedRoomName, int keycard)
        {
            BookedRoomName = bookedRoomName;
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

        public void ReturnKeycard()
        {
            KeycardNo = Keycard.DefaultKeycardNo;
            BookedRoomName = "";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            var compareGuest = (Guest)obj;
            return Name == compareGuest.Name
              && Age == compareGuest.Age;
        }
    }
}
