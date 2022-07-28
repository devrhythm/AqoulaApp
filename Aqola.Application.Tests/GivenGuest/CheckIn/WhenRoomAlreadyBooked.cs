using Aqola.Application.Services;
using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Tests.GivenGuest.CheckIn
{
    public class WhenRoomAlreadyBooked
    {
        private readonly IHotelService _hotelService = new HotelService();

        public WhenRoomAlreadyBooked()
        {
            HotelCreatedResult hotelCreatedResult = _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);
            (string roomName, string guestName, int guestAge) = ("101", "PeterParker", 16);
            _hotelService.CheckIn(roomName, guestName, guestAge);
        }

        [Fact]
        public void ThenGuestShouldGetMessageRoomIsNotAvailable()
        {
            (string roomName, string newGuestName, int guestAge) = ("101", "Thanos", 65);
            GuestCheckedInResult checkInResult = _hotelService.CheckIn(roomName, newGuestName, guestAge);
            Guest guestAlreadyCheckedIn = checkInResult.GuestWhoCheckedIn;
            string expectedMessage = $"Cannot book room 101 for Thanos, The room is currently booked by PeterParker.";
            Assert.Equal(expectedMessage, checkInResult.Message);
        }
    }
}
