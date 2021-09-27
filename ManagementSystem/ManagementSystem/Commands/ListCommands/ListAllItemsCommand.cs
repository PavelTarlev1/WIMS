using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Commands.List
{
    class ListAllItemsCommand : Command
    {
        public ListAllItemsCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("------Members------");
            foreach (var item in InstanceHolder.Database.MemberList)
            {
                str.AppendLine(item.Print());
            }
            str.AppendLine("------Boards------");
            foreach (var item in InstanceHolder.Database.BoardList)
            {
                str.AppendLine(item.Print());
            }
            str.AppendLine("------Teams------");
            foreach (var item in InstanceHolder.Database.TeamList)
            {
                str.AppendLine(item.ToString());
            }
            str.AppendLine("------Bugs------");
            foreach (var item in InstanceHolder.Database.BugList)
            {
                str.AppendLine(item.ToString());
            }
            str.AppendLine("------Stories------");
            foreach (var item in InstanceHolder.Database.StoryList)
            {
                str.AppendLine(item.ToString());
            }
            str.AppendLine("------Feedbacks------");
            foreach (var item in InstanceHolder.Database.FeedbacksList)
            {
                str.AppendLine(item.ToString());
            }
            return str.ToString();
        }
    }
}
