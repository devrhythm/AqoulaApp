using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class ListAvailableRoomsCommand : BaseHotelCommand, ICommand
    {
        public ListAvailableRoomsCommand(IHotelService hotelService) : base(hotelService)
        {

        }

        public string Execute(params object?[] options)
        {
            string result = _hotelService.GetAvailableRoomNames();
            return result;
        }

        public bool IsHandle(string command)
        {
            return command.Equals("list_available_rooms");
        }
    }
}
