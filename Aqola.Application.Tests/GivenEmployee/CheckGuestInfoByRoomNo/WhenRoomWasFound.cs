using Aqola.Application.Services;
using Aqola.Domain.Models;
using Aqola.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Application.Tests.GivenEmployee.CheckGuestInfoByRoomNo
{
    public class WhenRoomWasFound
    {
        private readonly IHotelService _hotelService = new HotelService();
        private readonly GuestCheckedInResult _checkInResult;
        public WhenRoomWasFound()
        {
            HotelCreatedResult hotelCreatedResult = _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);
            (string roomName, string guestName, int guestAge) = ("203", "Thor", 32);
            _checkInResult = _hotelService.CheckIn(roomName, guestName, guestAge);
        }

        [Fact]
        public void ThenGuestInfoShouldBeCorrect()
        {
            string searchRoomNo = "203";
            Guest guest = _hotelService.GetGuestByRoom(searchRoomNo);
            Guest guestWhoCheckedIn = _checkInResult.GuestWhoCheckedIn;
            Assert.True(guest.Equals(guestWhoCheckedIn));
        }
    }
}
