using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using System;
using System.Collections.Generic;

namespace ManagementSystem.Commands.MemberCommands
{
    public class CreateMemberCommand : Command
    {
        /// <summary>
        /// Creates a new Member.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        public CreateMemberCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }
        public override string Execute()
        {
            List<string> parameters = MemberInput.CreateMemberInputParameters();
            var member = InstanceHolder.Factory.CreateMember (parameters[0]);
            InstanceHolder.Database.AddToMemberList(member);
            InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Created Member. | Title: {member.Name}");

            return PrintMessages.memberSuccessfullyCreated;
        }
    }
}
