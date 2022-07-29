using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class ListGuestByAgeCommand : BaseHotelCommand, ICommand
    {
        public ListGuestByAgeCommand(IHotelService hotelService) : base(hotelService)
        {

        }

        public string Execute(params object?[] options)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            object filterAgeStart = options[0];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            object filterAgeEnd = options[1];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable CS8604 // Possible null reference argument.
            string guestNames = _hotelService.GetGuestByAge(filterAgeStart, filterAgeEnd);
#pragma warning restore CS8604 // Possible null reference argument.
            return guestNames;
        }

        public bool IsHandle(string command)
        {
            return command.StartsWith("list_guest_by_age");
        }
    }
}
