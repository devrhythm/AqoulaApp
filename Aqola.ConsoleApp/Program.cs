// See https://aka.ms/new-console-template for more information
using Aqola.Application;
using Aqola.Application.Services;
using Aqola.Domain.Services;

Console.WriteLine(@"
--------------------
Welcome to Aqola Hotel App
--------------------");
IHotelService hotelService = new HotelService();
HotellController controller = new(hotelService);
int line = 1;
Func<string, string> ShowResult = (result) =>
{
    Console.WriteLine($"line {line:00}: {result}");
    line++;
    return result;
};
try
{
    string[] inputCommands = File.ReadAllLines(@"Files\input.txt");
    controller.Run(inputCommands, ShowResult);
}
catch (Exception ex)
{
    Console.WriteLine($@"
--------------------
Error : {ex.Message}
StackTrace : {ex.StackTrace}
--------------------");
}



string readyToQuitMessage = $@"
--------------------
Please enter any key to close the app.";
Console.WriteLine(readyToQuitMessage);
Console.ReadLine();
