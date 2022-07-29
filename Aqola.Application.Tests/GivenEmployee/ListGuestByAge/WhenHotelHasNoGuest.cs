using Aqola.Application.Services;
using Aqola.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Application.Tests.GivenEmployee.ListGuestByAge
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
            string expectedResult = "";
            string actualResult = _hotelService.GetGuestByAge("<", 18);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
