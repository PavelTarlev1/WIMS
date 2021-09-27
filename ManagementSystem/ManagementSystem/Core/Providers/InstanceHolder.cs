using ManagementSystem.Commands;
using ManagementSystem.Core.Factories;
using ManagementSystem.Core.UserInput;
using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;

namespace ManagementSystem.Core.Providers
{
    public class InstanceHolder : IInstanceHolder
    {
        private static InstanceHolder instanceHolder;
        private InstanceHolder()
        {
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();
            this.Database = new Database();
            this.Parser = new Parser();
            this.Menu = new Menu();
            this.BoolVariables = new BoolVariables();
            this.Factory = new Factory();
        }

        public IReader Reader { get; }
        public IWriter Writer { get; }
        public IDatabase Database { get; }
        public Parser Parser { get; private set; }
        public Command Command { get; private set; }
        public IMenu Menu { get; }
        public BoolVariables BoolVariables { get; private set; }
        public Factory Factory { get; }

        public static InstanceHolder GetInstance()
        {
            if (instanceHolder == null)
            {
                instanceHolder = new InstanceHolder();
            }
            return instanceHolder;
        }

    }
}
