using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class GetGuestInRoomCommand : BaseHotelCommand, ICommand
    {
        public GetGuestInRoomCommand(IHotelService hotelService) : base(hotelService)
        {

        }
        public string Execute(params object?[] options)
        {
            throw new NotImplementedException();
        }

        public bool IsHandle(string command)
        {
            return command.StartsWith("get_guest_in_room");
        }
    }
}
