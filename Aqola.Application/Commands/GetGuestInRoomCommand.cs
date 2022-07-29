using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class GetGuestInRoomCommand : BaseHotelCommand, ICommand
    {
        public override string CommandName => "get_guest_in_room";

        public GetGuestInRoomCommand(IHotelService hotelService) : base(hotelService)
        {

        }
        public override string Execute(params object?[] options)
        {
            string roomName = options[0].ToStringOrEmpty();
            Guest guest = _hotelService.GetGuestByRoom(roomName);
            return guest.Name;
        }
    }
}
