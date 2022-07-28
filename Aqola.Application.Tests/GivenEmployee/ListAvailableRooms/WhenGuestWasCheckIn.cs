using Aqola.Application.Services;
using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Tests.GivenEmployee.ListAvailableRooms
{
    public class WhenGuestWasCheckIn
    {
        private readonly IHotelService _hotelService = new HotelService();
        private readonly Hotel _currentHotel;
        public WhenGuestWasCheckIn()
        {
            HotelCreatedResult hotelCreatedResult = _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);
            _currentHotel = hotelCreatedResult.Hotel;
        }

        [Fact]
        public void ThenRoomAvailableShouldBeDecrease()
        {
            int amoutOfAvailableRoomBeforeCheckIn = _currentHotel.GetAvailableRooms().Count;
            (string roomName, string guestName, int guestAge) = ("203", "Thor", 32);
            _hotelService.CheckIn(roomName, guestName, guestAge);
            int amountOfAvailableRoomAfterCheckIn = _currentHotel.GetAvailableRooms().Count;
            Assert.True(amoutOfAvailableRoomBeforeCheckIn > amountOfAvailableRoomAfterCheckIn);
        }
    }
}
