using Aqola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Application.Tests.GivenRunMultipleCommmands
{
    public class WhenCommandOptionsConvereted : BaseHotelTestScenario
    {
        private int line = 2;
        private readonly string[] expectedCommandResult =
@"Room 203 is booked by Thor with keycard number 1.
Room 101 is booked by PeterParker with keycard number 2.
Room 102 is booked by StephenStrange with keycard number 3.
Room 201 is booked by TonyStark with keycard number 4.
Room 202 is booked by TonyStark with keycard number 5.
Cannot book room 203 for TonyStark, The room is currently booked by Thor.
103
Room 201 is checkout.
Room 103 is booked by TonyStark with keycard number 4.
Cannot book room 101 for Thanos, The room is currently booked by PeterParker.
Only Thor can checkout with keycard number 1.
Room 202 is checkout.
Room 103 is checkout.
Thor, PeterParker, StephenStrange
Thor
PeterParker
Thor
Room 101, 102 are checkout.
Room 101, 102, 103 are booked with keycard number 2, 3, 4
Cannot book floor 2 for TonyStark.".Split(Environment.NewLine);

        [Fact]
        public void ThenAllResultShouldBeCorrect()
        {
            ResultBase line02 = _hotelService.CheckIn("203", "Thor", 32);
            ResultBase line03 = _hotelService.CheckIn("101", "PeterParker", 16);
            ResultBase line04 = _hotelService.CheckIn("102", "StephenStrange", 36);
            ResultBase line05 = _hotelService.CheckIn("201", "TonyStark", 48);
            ResultBase line06 = _hotelService.CheckIn("202", "TonyStark", 48);
            ResultBase line07 = _hotelService.CheckIn("203", "TonyStark", 48);
            string line08 = _hotelService.GetAvailableRoomNames();
            ResultBase line09 = _hotelService.CheckOut(4, "TonyStark");
            ResultBase line10 = _hotelService.CheckIn("103", "TonyStark", 48);
            ResultBase line11 = _hotelService.CheckIn("101", "Thanos", 65);
            ResultBase line12 = _hotelService.CheckOut(1, "TonyStark");
            ResultBase line13 = _hotelService.CheckOut(5, "TonyStark");
            ResultBase line14 = _hotelService.CheckOut(4, "TonyStark");
            string line15 = _hotelService.ListGuestNames();
            string line16 = _hotelService.GetGuestByRoom("203").Name;
            string line17 = _hotelService.GetGuestByAge("<", 18);
            string line18 = _hotelService.GetGuestNamesByFloor(2);
            string line19 = _hotelService.CheckoutByFloor(1);
            string line20 = _hotelService.BookByFloor(1, "TonyStark", 48);
            string line21 = _hotelService.BookByFloor(2, "TonyStark", 48);

            AssertMessage(0, line02.Message);
            AssertMessage(01, line03.Message);
            AssertMessage(02, line04.Message);
            AssertMessage(03, line05.Message);
            AssertMessage(04, line06.Message);
            AssertMessage(05, line07.Message);
            AssertMessage(06, line08);
            AssertMessage(07, line09.Message);
            AssertMessage(08, line10.Message);
            AssertMessage(09, line11.Message);
            AssertMessage(10, line12.Message);
            AssertMessage(11, line13.Message);
            AssertMessage(12, line14.Message);
            AssertMessage(13, line15);
            AssertMessage(14, line16);
            AssertMessage(15, line17);
            AssertMessage(16, line18);
            AssertMessage(17, line19);
            AssertMessage(18, line20);
            AssertMessage(19, line21);
        }

        private void AssertMessage(int resultIndex, string actualResult)
        {
            string expectedResult = expectedCommandResult[resultIndex];
            Assert.Equal(expectedResult, actualResult);
            line += 1;
        }
    }
}
