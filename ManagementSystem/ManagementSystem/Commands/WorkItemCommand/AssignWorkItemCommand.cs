using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Commands.WorkItemCommand
{
    class AssignWorkItemCommand : Command
    {
        /// <summary>
        /// Assigns a Work item.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public AssignWorkItemCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = WorkItemInput.AssignWorkItemParameters();
            string workIteamName = parameters[0];
            string Name = parameters[1];
            bool choice = bool.Parse(parameters[2]);
            IBug bug = InstanceHolder.Database.BugList.Where(b => b.Title == workIteamName).FirstOrDefault();
            IStory story = InstanceHolder.Database.StoryList.Where(s => s.Title == workIteamName).FirstOrDefault();
            IFeedback feedback = InstanceHolder.Database.FeedbacksList.Where(f => f.Title == workIteamName).FirstOrDefault();
            IMember member = InstanceHolder.Database.MemberList.Where(m => m.Name == Name).FirstOrDefault();
            IBoard board = InstanceHolder.Database.BoardList.Where(m => m.Name == Name).FirstOrDefault();
            if (choice)
            {
            if (bug!=null)
            {
                member.WorkItems.Add(bug);
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Added work item to member. | Title: {bug.Title}");
            }
            else if (story!=null)
            {
                member.WorkItems.Add(story);
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Added work item to member. | Title: {story.Title}");
            }
            else if (feedback != null)
            {
                member.WorkItems.Add(feedback);
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Added work item to member. | Title: {feedback.Title}");
            }

            }
            else
            {
                if (bug != null)
                {
                    board.WorkItems.Add(bug);
                    InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Added work item to board. | Title: {bug.Title}");
                }
                else if (story != null)
                {
                    board.WorkItems.Add(story);
                    InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Added work item to board. | Title: {story.Title}");
                }
                else if (feedback != null)
                {
                    board.WorkItems.Add(feedback);
                    InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Added work item to board. | Title: {feedback.Title}");
                }
            }

            return PrintMessages.workItemSuccessfullyAssigned;
        }
    }
}
