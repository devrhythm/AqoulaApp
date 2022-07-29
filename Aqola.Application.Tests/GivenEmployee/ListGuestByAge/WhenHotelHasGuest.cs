using Aqola.Application.Services;
using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Tests.GivenEmployee.ListGuestByAge
{
    public class WhenHotelHasGuest
    {
        private readonly IHotelService _hotelService = new HotelService();

        public WhenHotelHasGuest()
        {
            _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);
            (string, string, int)[] bookedGuestList = MockGuestList();
            foreach ((string roomName, string guestName, int guestAge) in bookedGuestList)
            {
                _hotelService.CheckIn(roomName, guestName, guestAge);
            }
        }

        private static (string, string, int)[] MockGuestList()
        {
            return new (string, string, int)[]
                  {
                    ("203", "Thor", 32),
                    ("101","PeterParker",16),
                    ("102","StephenStrange",36),
                    ("201","TonyStark",48)
                  };
        }

        [Fact]
        public void ThenGuestListShouldBeFound()
        {
            string expectedResult = "PeterParker";
            string actualResult = _hotelService.GetGuestByAge("<", 18);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
