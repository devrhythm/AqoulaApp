using Aqola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Application.Tests.GivenGuest.BookByFloor
{
    public class WhenFloorAvailable : BaseHotelTestScenario
    {
        [Fact]
        public void ThenFloorShouldBeUnavailable()
        {
            (int bookFloorNo, string guestName, int guestAge) = (1, "TonyStark", 48);
            _hotelService.BookByFloor(bookFloorNo, guestName, guestAge);
            Floor floor = _currentHotel.GetFloor(bookFloorNo);
            Assert.True(floor.IsUnavailable());
        }
    }
}
