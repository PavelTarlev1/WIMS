using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models;
using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementSystem.Commands.TeamCommands
{
    public class AddBoardToTeamCommand : Command
    {
        public AddBoardToTeamCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

       
        public override string Execute()
        {
            List<string> parameters = BoardInput.AddBoardToTeamParameters();
            ITeam team = InstanceHolder.Database.TeamList.Where(t => t.Name == parameters[0]).FirstOrDefault();
            IBoard board = InstanceHolder.Database.BoardList.Where(t => t.Name == parameters[1]).FirstOrDefault();
                    team.Boards.Add(board);
                    return PrintMessages.boardSuccessfullyAddedToTeam;
        }
    }
}
