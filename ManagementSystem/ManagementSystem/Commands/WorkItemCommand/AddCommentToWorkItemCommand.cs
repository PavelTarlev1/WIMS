using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Common;
using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Commands.WorkItemCommand
{
    class AddCommentToWorkItemCommand : Command
    {

        /// <summary>
        /// Adds a comment to Work item.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        public AddCommentToWorkItemCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = WorkItemInput.AddCommentToWorkItemParameters();
            IBug bug = InstanceHolder.Database.BugList.Where(b => b.Title == parameters[0]).FirstOrDefault();
            IStory story = InstanceHolder.Database.StoryList.Where(s => s.Title == parameters[0]).FirstOrDefault();
            IFeedback feedback = InstanceHolder.Database.FeedbacksList.Where(f => f.Title == parameters[0]).FirstOrDefault();
            IComments comment = new Comments(parameters[1]);
            if (bug != null)
            {
                bug.Comments.Add(comment);
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Added comment to Work Item. | Title: {bug.Title}");

            }
            else if (story != null)
            {
                story.Comments.Add(comment);
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Added comment to Work Item. | Title: {story.Title}");

            }
            else if (feedback != null)
            {
                feedback.Comments.Add(comment);
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Added comment to Work Item. | Title: {feedback.Title}");
            }

            return PrintMessages.successfullyAddedComment;
        }
    }
}
