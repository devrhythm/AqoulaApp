using Aqola.Application.Services;
using Aqola.Application.Services.Commands;
using Aqola.Domain.Services;

namespace Aqola.Application
{
    public class HotellController
    {
        private readonly IHotelService _hotelService = new HotelService();

        internal HotellController()
        {

        }

        public HotellController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public void Run(string[] inputCommandList, Func<string, string> triggerFunction)
        {
            List<ICommand> listOfHotelCommand = HotelCommandFactory.Create(_hotelService);
            foreach (string inputCommand in inputCommandList)
            {
                foreach (ICommand hotelCommand in listOfHotelCommand)
                {
                    if (hotelCommand.IsHandle(inputCommand))
                    {
                        object[] commandOptions = inputCommand.GetOptions();
                        string commandResult = hotelCommand.Execute(commandOptions);
                        triggerFunction(commandResult);
                    }
                }
            }
        }

    }
}
