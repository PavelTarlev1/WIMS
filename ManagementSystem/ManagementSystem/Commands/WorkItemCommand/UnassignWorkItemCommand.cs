using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Commands.WorkItemCommand
{
    class UnassignWorkItemCommand : Command
    {
        /// <summary>
        /// Unassigns a Work item from a member.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>

        public UnassignWorkItemCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = WorkItemInput.UnassignWorkItemParameters();
            IMember member = InstanceHolder.Database.MemberList.Where(m => m.Name == parameters[0]).FirstOrDefault();
            IWorkItem workitem = member.WorkItems.Where(i => i.Title == parameters[1]).FirstOrDefault();

            member.WorkItems.Remove(workitem);
            InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Work item unnasigned from member. | Member name: {member.Name}");

            return PrintMessages.workItemSuccessfullyUnassigned;
        }
    }
}
