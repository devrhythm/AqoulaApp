using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class ListAvailableRoomsCommand : BaseHotelCommand, ICommand
    {
        public override string CommandName => "list_available_rooms";

        public ListAvailableRoomsCommand(IHotelService hotelService) : base(hotelService)
        {

        }

        public override string Execute(params object?[] options)
        {
            string result = _hotelService.GetAvailableRoomNames();
            return result;
        }
    }
}
