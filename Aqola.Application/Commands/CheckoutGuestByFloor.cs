using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal class CheckoutGuestByFloor : BaseHotelCommand, ICommand
    {
        public override string CommandName => "checkout";

        public CheckoutGuestByFloor(IHotelService hotelService) : base(hotelService)
        {

        }
        public override string Execute(params object[] options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            int floorNo = options[0].ToInt();
            return _hotelService.CheckoutByFloor(floorNo);
        }
    }
}
