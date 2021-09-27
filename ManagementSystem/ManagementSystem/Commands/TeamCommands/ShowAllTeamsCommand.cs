using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using System;
using System.Text;

namespace ManagementSystem.Commands.TeamCommands
{
    class ShowAllTeamsCommand : Command
    {
        /// <summary>
        /// Prints all teams in Database.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public ShowAllTeamsCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            StringBuilder str = new StringBuilder();

            foreach (var item in InstanceHolder.Database.TeamList)
            {
                str.AppendLine(item.Name);
            }
            InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Printed all teams.");
            return str.ToString();
        }
    }
}
