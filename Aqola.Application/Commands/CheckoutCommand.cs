using Aqola.Domain.Models;
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
            int keycardNo = options[0].ToInt();
            string guestName = options[1].ToStringOrEmpty();

            CheckedOutResult result = _hotelService.CheckOut(keycardNo, guestName);
            return result.Message;
        }

        public bool IsHandle(string command)
        {
            return command.StartsWith("checkout");
        }
    }
}
