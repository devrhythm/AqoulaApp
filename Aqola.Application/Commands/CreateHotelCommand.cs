using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class CreateHotelCommand : BaseHotelCommand, ICommand
    {
        public override string CommandName => "create_hotel";

        public CreateHotelCommand(IHotelService hotelService) : base(hotelService)
        {

        }
        public override string Execute(params object?[] options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            int floor = options[0].ToInt();
            int roomPerFloor = options[1].ToInt();
            HotelCreatedResult result = _hotelService.CreateHotel(floor, roomPerFloor);
            return result.Message;
        }
    }
}
