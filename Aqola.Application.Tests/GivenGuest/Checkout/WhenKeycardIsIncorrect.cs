using Aqola.Application.Services;
using Aqola.Domain.Models;
using Aqola.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Application.Tests.GivenGuest.Checkout
{
    public class WhenKeycardIsIncorrect
    {
        private readonly IHotelService _hotelService = new HotelService();
        private readonly GuestCheckedInResult _checkInResult;

        public WhenKeycardIsIncorrect()
        {
            HotelCreatedResult hotelCreatedResult = _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);

            (string roomName, string guestName, int guestAge) = ("203", "Thor", 32);
            _checkInResult = _hotelService.CheckIn(roomName, guestName, guestAge);
        }

        [Fact]
        public void ThenGuestGetShouldGetErrorMessage()
        {
            string expectResult = "Only Thor can checkout with keycard number 1.";
            (int keycardNo, string guestName) = (1, "TonyStark");
            CheckedOutResult result = _hotelService.CheckOut(keycardNo, guestName);

            Assert.Equal(expectResult, result.Message);
        }
    }
}
