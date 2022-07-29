using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class CheckoutCommand : BaseHotelCommand, ICommand
    {
        public CheckoutCommand(IHotelService hotelService) : base(hotelService)
        {

        }
        public string Execute(params object?[] options)
        {
            throw new NotImplementedException();
        }

        public bool IsHandle(string command)
        {
            return command.StartsWith("checkout");
        }
    }
}
