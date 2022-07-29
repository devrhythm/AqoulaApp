using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class ListGuestByFloorCommand : BaseHotelCommand, ICommand
    {
        public override string CommandName => "list_guest_by_floor";

        public ListGuestByFloorCommand(IHotelService hotelService) : base(hotelService)
        {

        }

        public override string Execute(params object?[] options)
        {
            int floor = options[0].ToInt();
            return _hotelService.GetGuestNamesByFloor(floor);
        }
    }
}
