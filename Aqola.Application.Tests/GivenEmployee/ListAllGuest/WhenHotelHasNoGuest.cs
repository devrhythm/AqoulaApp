using Aqola.Application.Services;
using Aqola.Domain.Services;

namespace Aqola.Application.Tests.GivenEmployee.ListAllGuest
{
    public class WhenHotelHasNoGuest
    {
        private readonly IHotelService _hotelService = new HotelService();

        public WhenHotelHasNoGuest()
        {
            _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);
        }

        [Fact]
        public void ThenGuestListShouldBeEmpty()
        {
            string expectedNames = "";
            string actualGuestNames = _hotelService.ListGuestNames();
            Assert.Equal(expectedNames, actualGuestNames);
        }
    }
}
