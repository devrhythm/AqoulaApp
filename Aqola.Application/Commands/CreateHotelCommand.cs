using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class CreateHotelCommand : BaseHotelCommand, ICommand
    {
        public CreateHotelCommand(IHotelService hotelService) : base(hotelService)
        {

        }
        public string Execute(params object?[] options)
        {
            throw new NotImplementedException();
        }

        public bool IsHandle(string command)
        {
            return command.StartsWith("create_hotel");
        }
    }
}
