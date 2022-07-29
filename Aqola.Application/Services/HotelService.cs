using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Services
{
    public class HotelService : IHotelService
    {
        private Hotel _currentHotel = new Hotel();

        public GuestCheckedInResult CheckIn(string roomName, string guestName, int guestAge)
        {
            Guest guest = new(guestName, guestAge);
            Room bookedRoom = _currentHotel.GetRoom(roomName);
            try
            {
                bookedRoom.CheckIn(guest);
                Keycard keycard = _currentHotel.RegisterKeycard(roomName);
                guest.TakeRoomKeycard(bookedRoom.RoomName, keycard.KeycardNo);
                bookedRoom.GrantAccessByKeycard(keycard.KeycardNo);

                var message = $"Room {roomName} is booked by {guestName} with keycard number {keycard.KeycardNo}.";
                return new GuestCheckedInResult(message, bookedRoom);
            }
            catch (Exception ex)
            {
                return new GuestCheckedInResult(ex.Message, bookedRoom);
            }
        }

        public CheckedOutResult CheckOut(int keycardNo, string guestName)
        {
            try
            {
                Keycard keycard = _currentHotel.GetKeycard(keycardNo);
                Room room = _currentHotel.GetRoom(keycard.RoomName);

                if (room.IsValidKeycard(keycardNo, guestName))
                {
                    room.Guest.ReturnKeycard();
                    keycard.Unregister();
                    room.Checkout();

                    return new CheckedOutResult($"Room {room.RoomName} is checkout.", keycard, room);
                }
                else
                {
                    return new CheckedOutResult($"Only {room.Guest.Name} can checkout with keycard number {keycardNo}.");
                }
            }
            catch (Exception)
            {
                return new CheckedOutResult("Invalid keycard number.");
            }
        }

        public HotelCreatedResult CreateHotel(int amountFloor, int amountRoomPerFloor)
        {
            _currentHotel = new Hotel(amountFloor, amountRoomPerFloor);
            _currentHotel.Create();
            var outputMessage = $"Hotel created with {amountFloor} floor(s), {amountRoomPerFloor} room(s) per floor.";
            return new HotelCreatedResult(outputMessage, _currentHotel);
        }

        public Guest GetGuestByRoom(string searchRoomName)
        {
            return _currentHotel.GetGuestInfoByRoom(searchRoomName);
        }

        public string ListGuestNames()
        {
            List<Guest> guestList = _currentHotel.GetGuestList();
            IEnumerable<string> listGuestNames = guestList.Select(g => g.Name).Distinct().AsEnumerable();
            return string.Join(", ", listGuestNames);
        }

        public string GetGuestByAge(object filterAgeStart, object filterAgeEnd)
        {
            List<Guest> guestList = _currentHotel.GetGuestList();
            IEnumerable<string> listGuestNames
                                    = guestList.FilterByOperand(filterAgeStart, filterAgeEnd)
                                    .ToList()
                                    .Select(g => g.Name)
                                    .Distinct()
                                    .AsEnumerable();
            return listGuestNames.JoinCommaWithSpace();
        }

        public List<Room> GetAvailableRooms()
        {
            return _currentHotel.GetAvailableRooms();
        }

        public string GetGuestNamesByFloor(int floor)
        {
            List<Guest> guestList = _currentHotel.GetGuestList();
            string floorString = floor.ToString();
            IEnumerable<string> guestListByFloor = guestList
                                                    .Where(guest => guest.BookedRoomName.StartsWith(floorString))
                                                    .Select(guest => guest.Name)
                                                    .ToList();
            return string.Join(", ", guestListByFloor);
        }

        public string BookByFloor(int floorNo, string guestName, int guestAge)
        {
            Guest guest = new(guestName, guestAge);
            Floor floor = _currentHotel.GetFloor(floorNo);
            if (floor.IsAvailable())
            {
                foreach (Room bookedRoom in floor.Rooms)
                {
                    bookedRoom.CheckIn(guest);
                    Keycard keycard = _currentHotel.RegisterKeycard(bookedRoom.RoomName);
                    guest.TakeRoomKeycard(bookedRoom.RoomName, keycard.KeycardNo);
                    bookedRoom.GrantAccessByKeycard(keycard.KeycardNo);
                }

                IEnumerable<string> roomNameList = floor.Rooms.Select(room => room.RoomName).AsEnumerable();
                string roomNames = roomNameList.JoinCommaWithSpace();
                IEnumerable<int> keycardNoList = floor.Rooms.Select(room => room.KeycardNo).AsEnumerable();
                string bookedKeycardNumbers = keycardNoList.JoinCommaWithSpace();
                string message = $"Room {roomNames} are booked with keycard number {bookedKeycardNumbers}";
                return message;
            }
            else
            {
                return $"Cannot book floor {floorNo} for {guestName}.";
            }

        }

        public string CheckoutByFloor(int floorNo)
        {
            Floor floor = _currentHotel.GetFloor(floorNo);
            List<Room> guestRooms = floor.GetGuestRooms();
            foreach (Room room in guestRooms)
            {
                if (room.IsValidKeycard(room.KeycardNo, room.Guest.Name))
                {
                    Keycard keycard = _currentHotel.GetKeycard(room.KeycardNo);
                    room.Guest.ReturnKeycard();
                    room.Checkout();
                    keycard.Unregister();
                }
            }

            if (floor.Rooms.TrueForAll(room => room.IsAvailable))
            {
                return $"Room {guestRooms.Select(r => r.RoomName).JoinCommaWithSpace()} are checkout.";
            }

            throw new NotImplementedException();
        }

        public string GetAvailableRoomNames()
        {
            return string.Join(", ", GetAvailableRooms().Select(r => r.RoomName).AsEnumerable());
        }
    }
}
