using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Commands.List
{
    public class FilterWorkItemByStatusCommand : Command
    {
        public FilterWorkItemByStatusCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = ListInput.FilterWorkItemByStatusInput();
            StringBuilder str = new StringBuilder();
            if (parameters[0] == "Bug")
            {
                foreach (var item in InstanceHolder.Database.BugList)
                {
                    if (Enum.TryParse(parameters[1], out BugStatus status))
                    {
                        if (item.Status == status)
                        {
                            str.AppendLine(item.ToString());
                        }
                    }
                }
            }
            if (parameters[0] == "Story")
            {
                foreach (var item in InstanceHolder.Database.StoryList)
                {
                    if (Enum.TryParse(parameters[1], out StoryStatus status))
                    {
                        if (item.Status == status)
                        {
                            str.AppendLine(item.ToString());
                        }
                    }
                }
            }
            if (parameters[0] == "Feedback")
            {
                foreach (var item in InstanceHolder.Database.FeedbacksList)
                {
                    if (Enum.TryParse(parameters[1], out FeedbackStatus status))
                    {
                        if (item.Status == status)
                        {
                            str.AppendLine(item.ToString());
                        }
                    }
                }
            }
            return str.ToString();
        }
    }
}
