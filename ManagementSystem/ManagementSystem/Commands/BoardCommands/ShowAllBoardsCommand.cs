using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using System;
using System.Text;

namespace ManagementSystem.Commands.BoardCommands
{
    
    class ShowAllBoardsCommand : Command
    {
        /// <summary>
        /// Shows all Boards in Database.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>

        public ShowAllBoardsCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            StringBuilder str = new StringBuilder();
            foreach (var item in InstanceHolder.Database.BoardList)
            {
                str.AppendLine(item.Print());
            }
            InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Printed activity of all Boards in Database.");
            return str.ToString().Trim();
        }
    }
}
