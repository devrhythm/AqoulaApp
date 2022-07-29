using Aqola.Domain.Models;

namespace Aqola.Domain.Services
{
    public interface IHotelService
    {
        HotelCreatedResult CreateHotel(int amountFloor, int amountRoomPerFloor);
        GuestCheckedInResult CheckIn(string roomName, string guestName, int guestAge);
        CheckedOutResult CheckOut(int keycardNo, string guestName);
        Guest GetGuestByRoom(string searchRoomName);
        string BookByFloor(int floor, string guestName, int guestAge);
        string ListGuestNames();
        string GetGuestNamesByFloor(int floor);
        List<Room> GetAvailableRooms();
        string GetGuestByAge(object filterAgeStart, object filterAgeEnd);
    }
}
