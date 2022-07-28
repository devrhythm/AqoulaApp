using Aqola.Application.Services;
using Aqola.Domain.Models;
using Aqola.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Application.Tests.GivenGuest.CheckIn
{
    public class WhenRoomAvailable
    {
        private readonly IHotelService _hotelService = new HotelService();
        private readonly Hotel _currentHotel;
        private readonly GuestCheckedInResult _checkInResult;
        public WhenRoomAvailable()
        {
            HotelCreatedResult hotelCreatedResult = _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);
            _currentHotel = hotelCreatedResult.Hotel;
            (string roomName, string guestName, int guestAge) = ("101", "PeterParker", 16);
            _checkInResult = _hotelService.CheckIn(roomName, guestName, guestAge);

        }
        [Fact]
        public void ThenGuestShouldGetKeyCard()
        {
            Assert.True(_checkInResult.GuestWhoCheckedIn.HasKeyCard());
        }

        [Fact]
        public void ThenBookedRoomShouldUnavailable()
        {
            Assert.False(_checkInResult.BookedRoom.IsAvailable);
        }
    }
}
