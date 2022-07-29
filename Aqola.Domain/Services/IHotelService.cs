using Aqola.Domain.Models;

namespace Aqola.Domain.Services
{
    public interface IHotelService
    {
        HotelCreatedResult CreateHotel(int amountFloor, int amountRoomPerFloor);
        GuestCheckedInResult CheckIn(string roomName, string guestName, int guestAge);
        CheckedOutResult CheckOut(int keycardNo, string guestName);
        Guest GetGuestInRoom(string searchRoomName);
       string ListGuestNames();
    }
}
