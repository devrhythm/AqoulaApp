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

        public Guest GetGuestInRoom(string searchRoomName)
        {
            return _currentHotel.GetGuestInfoByRoom(searchRoomName);
        }
    }
}
