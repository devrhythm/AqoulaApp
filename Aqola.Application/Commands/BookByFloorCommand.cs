using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class BookByFloorCommand : BaseHotelCommand, ICommand
    {
        public override string CommandName => "book_by_floor";

        public BookByFloorCommand(IHotelService hotelService) : base(hotelService)
        {

        }

        public override string Execute(params object?[] options)
        {
            int floor = options[0].ToInt();
            string guestName = options[1].ToStringOrEmpty();
            int guestAge = options[2].ToInt();
            return _hotelService.BookByFloor(floor, guestName, guestAge);
        }
    }
}
