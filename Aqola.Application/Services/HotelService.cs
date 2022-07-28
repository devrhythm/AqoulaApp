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
                bookedRoom.CheckIn(guestName);
                Keycard keycard = _currentHotel.RegisterKeycard(roomName);
                guest.TakeRoomKeycard(bookedRoom.RoomName, keycard.KeycardNo);
                bookedRoom.GrantAccessByKeycard(keycard.KeycardNo);

                var message = $"Room {roomName} is booked by {guestName} with keycard number {keycard.KeycardNo}.";
                return new GuestCheckedInResult(message, guest);
            }
            catch (Exception ex)
            {
                return new GuestCheckedInResult(ex.Message, guest);
            }
        }

        public CheckedOutResult CheckOut(int keycardNo, string guestName)
        {
            Room room = _currentHotel.GetGuestRoom(guestName);
            if (room.IsValidKeycard(keycardNo))
            {
                room.Checkout();
                return new CheckedOutResult($"Room {room.RoomName} is checkout.");
            }
            throw new InvalidKeycardException(room);
        }

        public HotelCreatedResult CreateHotel(int amountFloor, int amountRoomPerFloor)
        {
            _currentHotel = new Hotel(amountFloor, amountRoomPerFloor);
            _currentHotel.Create();
            var outputMessage = $"Hotel created with {amountFloor} floor(s), {amountRoomPerFloor} room(s) per floor.";
            return new HotelCreatedResult(outputMessage, _currentHotel);
        }
    }
}
