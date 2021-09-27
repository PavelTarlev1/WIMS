using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;

namespace ManagementSystem.Commands
{
    class ShowMenuCommand : Command
    {
        public ShowMenuCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            InstanceHolder.BoolVariables.showMenu = true;
            InstanceHolder.BoolVariables.showFullMenu = true;
            return "";
        }
    }
}
