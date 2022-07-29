using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal abstract class BaseHotelCommand
    {
        protected readonly IHotelService _hotelService;
        public BaseHotelCommand(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
    }
}
