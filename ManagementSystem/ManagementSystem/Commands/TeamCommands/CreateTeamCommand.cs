using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;

namespace ManagementSystem.Commands.TeamCommands
{
    class CreateTeamCommand : Command
    {
        /// <summary>
        /// Treates a new Team.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public CreateTeamCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }
        public override string Execute()
        {
            List<string> parameters = TeamInput.CreateTeamParameters();

            ITeam team = InstanceHolder.Factory.CreateTeam(parameters[0]);
            InstanceHolder.Database.AddToTeamList(team);
            InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Created new team. | Title: {team.Name}");

            return PrintMessages.teamSuccesfullyCreated;
        }
    }
}
