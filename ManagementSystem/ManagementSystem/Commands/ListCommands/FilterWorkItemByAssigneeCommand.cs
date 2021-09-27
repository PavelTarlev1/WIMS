using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementSystem.Commands.ListCommands
{
    public class FilterWorkItemByAssigneeCommand : Command
    {
        public FilterWorkItemByAssigneeCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = ListInput.FilterWorkItemByAssignee();
            StringBuilder str = new StringBuilder();
            if (parameters[0] == "Bug")
            {
                foreach (var item in InstanceHolder.Database.BugList.Where(n => n.Assignee.Name == parameters[1]))
                {
                    str.AppendLine(item.ToString());
                }
            }
            if (parameters[0] == "Story")
            {
                foreach (var item in InstanceHolder.Database.StoryList.Where(n => n.Assignee.Name == parameters[1]))
                {
                    str.AppendLine(item.ToString());
                }
            }
            if (parameters[0] == "Feedback")
            {
                foreach (var item in InstanceHolder.Database.FeedbacksList.Where(n => n.Assignee.Name == parameters[1]))
                {
                    str.AppendLine(item.ToString());
                }
            }
            return str.ToString();
        }
    }
}
