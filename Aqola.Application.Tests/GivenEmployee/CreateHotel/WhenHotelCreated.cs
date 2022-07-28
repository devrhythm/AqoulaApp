using Aqola.Application.Services;
using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Tests.GivenEmployee.CreateHotel
{
    public class WhenHotelCreated
    {
        private readonly IHotelService _hotelService = new HotelService();
        private readonly HotelCreatedResult _hotelCreatedResult;
        private readonly Hotel _currentHotel;
        public WhenHotelCreated()
        {
            _hotelCreatedResult = _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);
            _currentHotel = _hotelCreatedResult.Hotel;
        }

        [Fact]
        public void ThenFloorShouldBeCreated()
        {
            Assert.NotEmpty(_currentHotel.Floors);
        }

        [Fact]
        public void ThenRoomPerFloorShouldBeCreated()
        {
            Assert.NotEmpty(_currentHotel.Floors[0].Rooms);
        }

        [Fact]
        public void ThenKeycardShouldBeCreated()
        {

        }

        [Fact]
        public void ThenHotelCreatedResultShoudBeCorrect()
        {
            string expectedResult = $"Hotel created with {ConstantVariable.Hotel.AmountOfFloor} floor(s), {ConstantVariable.Hotel.AmountOfRoomPerFloor} room(s) per floor.";
            Assert.Equal(expectedResult, _hotelCreatedResult.Message);
        }
    }
}
