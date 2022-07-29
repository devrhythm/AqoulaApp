using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class ListGuestByFloorCommand : BaseHotelCommand, ICommand
    {
        public ListGuestByFloorCommand(IHotelService hotelService) : base(hotelService)
        {

        }

        public string Execute(params object?[] options)
        {
            int floor = options[0].ToInt();
            return _hotelService.GetGuestNamesByFloor(floor);
        }

        public bool IsHandle(string command)
        {
            return command.StartsWith("list_guest_by_floor");
        }
    }
}
