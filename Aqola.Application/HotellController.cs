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
                ICommand hotelCommand = listOfHotelCommand.Where(cmd => cmd.IsHandle(inputCommand)).Single();
                object[] commandOptions = inputCommand.GetOptions();
                string commandResult = hotelCommand.Execute(commandOptions);
                triggerFunction(commandResult);
            }
        }

    }
}
