namespace Aqola.Application.Tests.GivenEmployee.BookByFloor
{
    public class WhenFlooUnavailable : BaseHotelTestScenario
    {
        [Fact]
        public void ThenGuestShouldGetMessageCannotBookFloor()
        {
            string expectedResult = "Cannot book floor 2 for TonyStark.";

            string firstGuestRoomName = "203";
            string firstGuestName = "Thor";
            int firstGuestAge = 32;

            int bookFloorNo = 2;
            string guestName = "TonyStark";
            int guestAge = 48;

            _hotelService.CheckIn(firstGuestRoomName, firstGuestName, firstGuestAge);
            string actualResult = _hotelService.BookByFloor(bookFloorNo, guestName, guestAge);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
