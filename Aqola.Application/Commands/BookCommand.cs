using Aqola.Domain.Models;
using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class BookCommand : BaseHotelCommand, ICommand
    {
        public override string CommandName => "book";

        public BookCommand(IHotelService hotelService) : base(hotelService)
        {

        }
        public override string Execute(params object?[] options)
        {
            string roomName = options[0].ToStringOrEmpty();
            string guestName = options[1].ToStringOrEmpty();
            int guesetAge = options[2].ToInt();
            GuestCheckedInResult result = _hotelService.CheckIn(roomName, guestName, guesetAge);
            return result.Message;
        }
    }
}
