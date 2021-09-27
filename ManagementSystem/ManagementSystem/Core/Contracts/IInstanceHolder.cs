using ManagementSystem.Commands;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Factories;

namespace ManagementSystem.Core.Providers
{
    public interface IInstanceHolder
    {
        BoolVariables BoolVariables { get; }
        Command Command { get; }
        IDatabase Database { get; }
        Factory Factory { get; }
        IMenu Menu { get; }
        Parser Parser { get; }
        IReader Reader { get; }
        IWriter Writer { get; }
    }
}