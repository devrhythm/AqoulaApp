using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class ListGuestCommand : BaseHotelCommand, ICommand
    {
        public override string CommandName => "list_guest";

        public ListGuestCommand(IHotelService hotelService) : base(hotelService)
        {

        }

        public override string Execute(params object?[] options)
        {
            return _hotelService.ListGuestNames();
        }
    }
}
