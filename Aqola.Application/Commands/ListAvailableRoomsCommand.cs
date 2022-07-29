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
            List<Room> rooms = _hotelService.GetAvailableRooms();
            string result = string.Join(", ", rooms.Select(r => r.RoomName).AsEnumerable());
            return result;
        }

        public bool IsHandle(string command)
        {
            return command.Equals("list_available_rooms");
        }
    }
}
