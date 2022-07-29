using Aqola.Application.Services.Commands;
using Aqola.Domain.Services;

namespace Aqola.Application
{
    internal class CommandFactory
    {
        internal static List<ICommand>? Create(IHotelService hotelService)
        {
            return new List<ICommand>()
                        {
                            new BookByFloorCommand(hotelService),
                            new BookCommand(hotelService),
                            new CheckoutCommand(hotelService),
                            new CheckoutGuestByFloor(hotelService),
                            new CreateHotelCommand(hotelService),
                            new GetGuestInRoomCommand(hotelService),
                            new ListAvailableRoomsCommand(hotelService),
                            new ListGuestByAgeCommand(hotelService),
                            new ListGuestByFloorCommand(hotelService),
                            new ListGuestCommand(hotelService)
                        };
        }
    }
}
