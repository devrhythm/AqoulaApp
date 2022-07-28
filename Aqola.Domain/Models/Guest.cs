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
        public int KeycardNo { get; private set; }
        public string BookedRoomNo { get; private set; } = "";
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
    }
}
