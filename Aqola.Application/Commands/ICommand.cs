namespace Aqola.Application.Services.Commands
{
    internal interface ICommand
    {
        bool IsHandle(string command);
        string Execute(params object?[] options);
    }
}
