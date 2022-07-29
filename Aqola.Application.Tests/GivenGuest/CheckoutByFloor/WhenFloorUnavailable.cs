using Aqola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Application.Tests.GivenGuest.CheckoutByFloor
{
    public class WhenFloorUnavailable : BaseHotelTestScenario
    {
        public WhenFloorUnavailable()
        {
            _hotelService.CheckIn("101", "PeterParker", 16);
            _hotelService.CheckIn("102", "StephenStrange", 36);
        }

        [Fact]
        public void ThenFloorShouldBeAvailable()
        {
            int checkoutFloorNo = 1;
            _hotelService.CheckoutByFloor(checkoutFloorNo);
            Floor floor = _currentHotel.GetFloor(checkoutFloorNo);
            Assert.True(floor.IsAvailable());
        }

        [Fact]
        public void ThenGuestShouldGetMessageCheckoutSucces()
        {
            int checkoutFloorNo = 1;
            string expectedResult = "Room 101, 102 are checkout.";
            string actualResult = _hotelService.CheckoutByFloor(checkoutFloorNo);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
