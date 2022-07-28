using Aqola.Domain.Models;
using Aqola.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Application.Services
{
    public class HotelService : IHotelService
    {
        private Hotel _hotel = new Hotel();
        public HotelCreatedResult CreateHotel(int amountFloor, int amountRoomPerFloor)
        {
            _hotel = new Hotel(amountFloor, amountRoomPerFloor);
            _hotel.Create();
            var outputMessage = $"Hotel created with {amountFloor} floor(s), {amountRoomPerFloor} room(s) per floor.";
            return new HotelCreatedResult(outputMessage, _hotel);
        }
    }
}
