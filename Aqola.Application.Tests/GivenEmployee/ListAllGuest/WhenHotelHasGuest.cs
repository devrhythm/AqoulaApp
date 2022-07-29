using Aqola.Application.Services;
using Aqola.Domain.Models;
using Aqola.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Application.Tests.GivenEmployee.ListAllGuest
{
    public class WhenGuestAlreadyCheckedIn
    {
        private readonly IHotelService _hotelService = new HotelService();

        public WhenGuestAlreadyCheckedIn()
        {
            _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);
            var bookedGuestList = new (string, string, int)[]
         {
                ("203", "Thor", 32),
                ("101","PeterParker",16),
                ("102","StephenStrange",36),
                ("201","TonyStark",48),
                ("202","TonyStark",48),
                ("203","TonyStark",48),
         };

            foreach ((string roomName, string guestName, int guestAge) in bookedGuestList)
            {
                _hotelService.CheckIn(roomName, guestName, guestAge);
            }
        }

        [Fact]
        public void ThenGuestListShouldBeFound()
        {
            string expectedNames = "Thor, PeterParker, StephenStrange, TonyStark";
            string actualGuestNames = _hotelService.ListGuestNames();
            Assert.Equal(expectedNames, actualGuestNames);
        }
    }
}
