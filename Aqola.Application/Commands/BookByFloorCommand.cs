using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class BookByFloorCommand : BaseHotelCommand, ICommand
    {
        public BookByFloorCommand(IHotelService hotelService) : base(hotelService)
        {

        }
        public string Execute(params object?[] options)
        {
            int floor = options[0].ToInt();
            string guestName = options[1].ToStringOrEmpty();
            int guestAge = options[2].ToInt();
            return _hotelService.BookByFloor(floor, guestName, guestAge);
        }

        public bool IsHandle(string command)
        {
            return command.StartsWith("book_by_floor");
        }
    }
}
