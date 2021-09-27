using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Commands.FeedbackCommands
{
    class ChangeFeedbackStatusCommand : Command
    {
        /// <summary>
        /// Changes the Status of a Feedback.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public ChangeFeedbackStatusCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = FeedbackInput.ChangeFeedbackStatusParameters();
          
            string title = parameters[0];
            string newFeedbackStatus = parameters[1];

            IFeedback feedback = InstanceHolder.Database.FeedbacksList.Where(i => i.Title == title).FirstOrDefault();

            if (Enum.TryParse(newFeedbackStatus, out FeedbackStatus feedbackStatus))
            {
                feedback.Status = feedbackStatus;
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Changed status of a Feedback | Title: {feedback.Title}" + Environment.NewLine + $"New Status: {feedback.Status}");

                return $"{PrintMessages.feedbackStatusChanged}{Environment.NewLine}" +
                       $"NewStatus: {feedbackStatus}";
            }
            else
            {
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Attempt for changing the status of a Feedback | Title: {feedback.Title}" + Environment.NewLine + PrintMessages.feedbackStatusNotChanged);
                return PrintMessages.feedbackStatusNotChanged;
            }
        }
    }
}
