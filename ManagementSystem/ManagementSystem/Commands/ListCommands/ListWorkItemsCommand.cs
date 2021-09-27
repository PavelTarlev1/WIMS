using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Core.UserInput;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Commands.List
{
    public class ListWorkItemsCommand : Command
    {
        public ListWorkItemsCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            string option = ListInput.ListWorkItemInput();
            StringBuilder str = new StringBuilder();
            if (option == "Bug")
            {
                foreach (var item in InstanceHolder.Database.BugList)
                {
                    str.AppendLine(item.ToString());
                }
            }
            else if (option == "Story")
            {
                foreach (var item in InstanceHolder.Database.StoryList)
                {

                    str.AppendLine(item.ToString());
                }
            }
            else if (option == "Feedback")
            {
                foreach (var item in InstanceHolder.Database.FeedbacksList)
                {
                    str.AppendLine(item.ToString());
                }
            }

            return str.ToString();
        }
    }
}
