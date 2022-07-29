using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class ListGuestCommand : BaseHotelCommand, ICommand
    {
        public ListGuestCommand(IHotelService hotelService) : base(hotelService)
        {

        }

        public string Execute(params object?[] options)
        {
            throw new NotImplementedException();
        }

        public bool IsHandle(string command)
        {
            return command.StartsWith("list_guest");
        }
    }
}
