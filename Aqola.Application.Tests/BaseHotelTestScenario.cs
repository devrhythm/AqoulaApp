using Aqola.Application.Services;
using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Tests
{
    public abstract class BaseHotelTestScenario
    {
        protected readonly IHotelService _hotelService = new HotelService();
        protected readonly Hotel _currentHotel;

        public BaseHotelTestScenario()
        {
            HotelCreatedResult hotelCreatedResult = _hotelService.CreateHotel(ConstantVariable.Hotel.AmountOfFloor, ConstantVariable.Hotel.AmountOfRoomPerFloor);
            _currentHotel = hotelCreatedResult.Hotel;
        }

        protected virtual (string, string, int)[] GetGuestList()
        {
            return new (string, string, int)[]
            {
                ("203", "Thor", 32),
                ("101","PeterParker",16),
                ("102","StephenStrange",36)
            };
        }
    }
}
