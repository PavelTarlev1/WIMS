using ManagementSystem.Commands.Contracts;
using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Core.UserInput;
using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementSystem.Commands.BoardCommands
{
    class ShowBoardActivityCommand : Command
    {
        /// <summary>
        /// Shows All Activity history of a chosen Board.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        public ShowBoardActivityCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = BoardInput.ShowBoardActivityParameters();

            string boardName = parameters[0];

            IBoard currBoard = InstanceHolder.Database.BoardList.Where(n => n.Name == boardName).FirstOrDefault();
            StringBuilder str = new StringBuilder();

                foreach (var item in currBoard.ActivityHistory)
                {
                    str.AppendLine($"{item.ToString()}");
                }
            InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Printed activity for Board | Title: {currBoard.Name}");

            return str.ToString().Trim().TrimEnd();
        }
    }
}
