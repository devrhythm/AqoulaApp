using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Models
{
    public class Keycard
    {
        public const int DefaultKeycardNo = -1;
        public int KeycardNo { get; private set; }
        public string RoomNo { get; private set; } = "";
        public bool IsAvailable { get; private set; } = true;
        public Keycard(int keycardNo)
        {
            KeycardNo = keycardNo;
        }
        public static List<Keycard> CreateKeycards(int amountOfKeycard)
        {
            var keycards = new List<Keycard>();
            for (int runningNo = 1; runningNo <= amountOfKeycard; runningNo++)
            {
                keycards.Add(new Keycard(runningNo));
            }
            return keycards;
        }

        public Keycard Register(string roomNo)
        {
            RoomNo = roomNo;
            IsAvailable = false;
            return this;
        }

        public Keycard Unregister()
        {
            RoomNo = "";
            IsAvailable = false;
            return this;
        }
    }
}
