using Aqola.Application.Services;
using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Tests.GivenEmployee.ListAvailableRooms
{
    public class WhenGuestWasCheckOut
    {
        private readonly IHotelService _hotelService = new HotelService();
        private readonly Hotel _currentHotel;
        public WhenGuestWasCheckOut()
        {
            HotelCreatedResult hotelCreatedResult = _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);
            _currentHotel = hotelCreatedResult.Hotel;
        }

        [Fact]
        public void ThenAvailableRoomShouldBeIncrease()
        {
            (string roomName, string guestName, int guestAge) = ("203", "Thor", 32);
            GuestCheckedInResult guestCheckedInResult = _hotelService.CheckIn(roomName, guestName, guestAge);
            Guest guest = guestCheckedInResult.GuestAlreadyCheckedIn;

            int amountOfAvailableBeforeCheckOut = _currentHotel.GetAvailableRooms().Count;

            _hotelService.CheckOut(guest.KeycardNo, guestName);
            int amountOfAvailableRoomAfterCheckOut = _currentHotel.GetAvailableRooms().Count;
            Assert.True(amountOfAvailableBeforeCheckOut < amountOfAvailableRoomAfterCheckOut);
        }
    }
}
