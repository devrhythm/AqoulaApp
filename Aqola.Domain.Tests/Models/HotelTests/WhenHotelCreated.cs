using Aqola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Domain.Tests.Models.HotelTests
{
    public class WhenHotelCreated
    {
        private readonly Hotel _hotel;
        private readonly int _amountOfFloor = 2;
        private readonly int _amountRoomOfFloor = 3;

        public WhenHotelCreated()
        {
            _hotel = new Hotel(_amountOfFloor, _amountRoomOfFloor);
            _hotel.Create();
        }

        [Fact]
        public void AmountOfFloorShouldBeEqualsInput()
        {
            Assert.Equal(_amountOfFloor, _hotel.Floors?.Count);
        }

        [Fact]
        public void AmountRoomOfFloorShouldBeEqualsInput()
        {
            Assert.Equal(_amountRoomOfFloor, _hotel.Floors?.FirstOrDefault()?.Rooms?.Count);
        }

        [Fact]
        public void AmountOfRoomInHotelShouldBeCorrect()
        {
            var expectTotalRoom = _amountOfFloor * _amountRoomOfFloor;
            List<Room> roomList = _hotel.GetAllRooms();
            Assert.Equal(expectTotalRoom, roomList.Count);
        }

        [Fact]
        public void FirstRoomOnFirstFloorNameShouldBe101()
        {
            var expectRoomNo = "101";
            var actualRoomNo = _hotel.Floors?.First().Rooms?.First().RoomName;
            Assert.Equal(expectRoomNo, actualRoomNo);
        }

        [Fact]
        public void LastRoomOnLastFloorNameShouldBe203()
        {
            var expectRoomNo = "203";
            var actualRoomNo = _hotel.Floors?.Last().Rooms?.Last().RoomName;
            Assert.Equal(expectRoomNo, actualRoomNo);
        }

        [Theory]
        [InlineData(4, 8)]
        [InlineData(10, 20)]
        public void TotalRoomShouldBeCorrect(int amountFloor, int amountRoom)
        {
            var hotel = new Hotel(amountFloor, amountRoom);
            hotel.Create();
            var expectTotalRoom = amountFloor * amountRoom;
            var actualTotalRoom = hotel.TotalRoom;
            Assert.Equal(expectTotalRoom, actualTotalRoom);
        }
    }
}
