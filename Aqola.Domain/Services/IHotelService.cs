using Aqola.Domain.Models;

namespace Aqola.Domain.Services
{
    public interface IHotelService
    {
        HotelCreatedResult CreateHotel(int amountFloor, int amountRoomPerFloor);
    }
}
