using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementSystem.Commands.TeamCommands
{
    class ShowAllTeamBoardsCommand : Command
    {
        /// <summary>
        /// Prints all Team boards in Database.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public ShowAllTeamBoardsCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = TeamInput.ShowAllTeamBoardsParameters();
            string name = parameters[0];

            ITeam team = InstanceHolder.Database.TeamList.Where(t => t.Name == name).FirstOrDefault();
            if (team != null)
            {
                StringBuilder str = new StringBuilder();

                str.AppendLine("----- Boards -----");
                foreach (var item in team.Boards)
                {
                    str.AppendLine(item.Name);
                }
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Printed all boards of a team. | Team: {team.Name}");
                return str.ToString();
            }
            else
            {
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Attempt for printing all boards of a team. | Team: {name}" + Environment.NewLine + PrintMessages.teamNOTfound);
                return PrintMessages.teamNOTfound;
           }
        }
    }
}
