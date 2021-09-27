using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Commands.WorkItemCommand
{
    public class ShowAllWorkItemsCommand : Command
    {
        public ShowAllWorkItemsCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            InstanceHolder.Writer.WriteLine("------Bugs------");
            foreach (var item in InstanceHolder.Database.BugList)
            {
                InstanceHolder.Writer.WriteLine(item.Title);

            }
            InstanceHolder.Writer.WriteLine("------Feedbacks------");
            foreach (var item in InstanceHolder.Database.FeedbacksList)
            {
                InstanceHolder.Writer.WriteLine(item.Title);

            }
            InstanceHolder.Writer.WriteLine("------Stories------");
            foreach (var item in InstanceHolder.Database.StoryList)
            {
                InstanceHolder.Writer.WriteLine(item.Title);

            }
            return "";
        }
    }
}
