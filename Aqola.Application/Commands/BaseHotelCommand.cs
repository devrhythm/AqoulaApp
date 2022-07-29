using Aqola.Domain.Services;

namespace Aqola.Application.Services.Commands
{
    internal abstract class BaseHotelCommand
    {
        protected readonly IHotelService _hotelService;
        public abstract string CommandName { get; }

        public BaseHotelCommand(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public abstract string Execute(params object?[] options);
        public virtual bool IsHandle(string command)
        {
            return CommandName == command;
        }
    }
}
