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
    public class WhenKeycardIsCorrect
    {
        private readonly IHotelService _hotelService = new HotelService();
        private readonly CheckedOutResult _checkedOutResult;
        private readonly Guest _guestWhoCheckIn;
        public WhenKeycardIsCorrect()
        {
            HotelCreatedResult hotelCreatedResult = _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);

            (string roomName, string guestName, int guestAge) = ("201", "TonyStark", 4);
            GuestCheckedInResult checkInResult = _hotelService.CheckIn(roomName, guestName, guestAge);
            _guestWhoCheckIn = checkInResult.GuestWhoCheckedIn;
            _checkedOutResult = _hotelService.CheckOut(_guestWhoCheckIn.KeycardNo, _guestWhoCheckIn.Name);
        }

        [Fact]
        public void ThenGuestShouldBeReturnCard()
        {
            Assert.False(_guestWhoCheckIn.HasKeyCard());
        }

        [Fact]
        public void ThenRoomShouldBeAvailable()
        {
            Assert.True(_checkedOutResult.CheckoutRoom?.IsAvailable);
        }

        [Fact]
        public void ThenKeycardShouldBeAvailable()
        {
            Assert.True(_checkedOutResult.ReturnedKeycard?.IsAvailable);
        }

    }
}
