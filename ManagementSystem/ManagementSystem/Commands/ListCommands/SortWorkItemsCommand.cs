using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementSystem.Commands.ListCommands
{
    public class SortWorkItemsCommand : Command
    {
        public SortWorkItemsCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = ListInput.SortWorkItemsOptionsInput();
            string workItem = parameters[0];
           
            string criteria = parameters[1];

            StringBuilder str = new StringBuilder();
            if (workItem == "Bug")
            {
                List<IBug> bugList = InstanceHolder.Database.BugList;
                //List<string> options = new List<string>() { "Title", "Priority", "Severity" };
                if (criteria == "Title")
                {
                    foreach (var item in bugList.OrderBy(x => x.Title))
                    {
                        str.AppendLine(item.ToString());
                    }
                }
                else if (criteria == "Priority")
                {
                    foreach (var item in bugList.OrderBy(x => x.Priority))
                    {
                        str.AppendLine(item.ToString());
                    }
                }
                else if (criteria == "Severity")
                {
                    foreach (var item in bugList.OrderBy(x => x.Severity))
                    {
                        str.AppendLine(item.ToString());
                    }
                }
            }
            else if (workItem =="Story")
            {
                //List<string> options = new List<string>() { "Title", "Priority", "Size", "Status" };
                List<IStory> storyList = InstanceHolder.Database.StoryList;
                if (criteria == "Title")
                {
                    foreach (var item in storyList.OrderBy(x => x.Title))
                    {
                        str.AppendLine(item.ToString());
                    }
                }
                else if (criteria == "Priority")
                {
                    foreach (var item in storyList.OrderBy(x => x.Priority))
                    {
                        str.AppendLine(item.ToString());
                    }
                }
                else if (criteria == "Size")
                {
                    foreach (var item in storyList.OrderBy(x => x.Size))
                    {
                        str.AppendLine(item.ToString());
                    }
                }
                else if (criteria == "Status")
                {
                    foreach (var item in storyList.OrderBy(x => x.Title))
                    {
                        str.AppendLine(item.ToString());
                    }
                }
            }
            else if (workItem == "Feedback")
            {
                //List<string> options = new List<string>() { "Title", "Rating", "Status" };
                List<IFeedback> feedbackList = InstanceHolder.Database.FeedbacksList;

                if (criteria == "Title")
                {
                    foreach (var item in feedbackList.OrderBy(x => x.Title))
                    {
                        str.AppendLine(item.ToString());
                    }
                }
                else if (criteria == "Rating")
                {
                    foreach (var item in feedbackList.OrderBy(x => x.Rating))
                    {
                        str.AppendLine(item.ToString());
                    }
                }
                else if (criteria == "Status")
                {
                    foreach (var item in feedbackList.OrderBy(x => x.Status))
                    {
                        str.AppendLine(item.ToString());
                    }
                }
            }
            return str.ToString();
        }
    }
}
