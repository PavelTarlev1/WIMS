using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Commands.TeamCommands
{
   public class AddMemberToTeamCommand : Command
    {
        /// <summary>
        /// Adds a member to a team.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public AddMemberToTeamCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = TeamInput.AddMemberToTeamParameters();
            string teamName = parameters[0];
            string memberName = parameters[1];
            

            ITeam team = InstanceHolder.Database.TeamList.Where(t => t.Name == teamName).FirstOrDefault();
            IMember member = InstanceHolder.Database.MemberList.Where(m => m.Name == memberName).FirstOrDefault();
         

                team.Members.Add(member);
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} New Member successfully added to team. | Username: {parameters[0]} | Team: {team.Name}");

                return PrintMessages.memberSuccessfullyAddedToTeam;
            
            
                
            
        }
    }
}
