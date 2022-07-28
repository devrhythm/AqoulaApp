using Aqola.Application.Services;
using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Tests.GivenEmployee.ListAvailableRooms
{
    public class WhenHotelCreated
    {
        private readonly IHotelService _hotelService = new HotelService();
        private readonly Hotel _currentHotel;
        public WhenHotelCreated()
        {
            HotelCreatedResult hotelCreatedResult = _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);
            _currentHotel = hotelCreatedResult.Hotel;
        }

        [Fact]
        public void ThenAmountOfRoomAvailableShouldEqualsAmountOfRoomCreated()
        {
            int expectedAvailableRoom = _currentHotel.TotalRoom;
            int actualAvailableRoom = _currentHotel.GetAvailableRooms().Count;
            Assert.Equal(expectedAvailableRoom, actualAvailableRoom);
        }
    }
}
