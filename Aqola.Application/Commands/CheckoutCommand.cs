using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class CheckoutCommand : BaseHotelCommand, ICommand
    {
        public override string CommandName => "checkout";

        public CheckoutCommand(IHotelService hotelService) : base(hotelService)
        {

        }
        public override string Execute(params object?[] options)
        {
            int keycardNo = options[0].ToInt();
            string guestName = options[1].ToStringOrEmpty();

            CheckedOutResult result = _hotelService.CheckOut(keycardNo, guestName);
            return result.Message;
        }
    }
}
