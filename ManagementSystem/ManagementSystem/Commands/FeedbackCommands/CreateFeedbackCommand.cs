using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;

namespace ManagementSystem.Commands.FeedbackCommands
{
    class CreateFeedbackCommand : Command
    {
        /// <summary>
        /// Creates a new Feedback.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public CreateFeedbackCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = FeedbackInput.CreateFeedbackParameters();
            string title = parameters[0];
            string description = parameters[1];
            int rating = int.Parse(parameters[2]);
            FeedbackStatus newfeedbackStatus = 0;
            if(Enum.TryParse(parameters[3],out FeedbackStatus feedbackStatus))
            {
                newfeedbackStatus = feedbackStatus;
            }
            IFeedback newFeedback = InstanceHolder.Factory.CreateFeedback(title, description, rating, newfeedbackStatus);
            InstanceHolder.Database.AddToFeedbackList(newFeedback);

            InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Created Board. | Title: {newFeedback.Title}");
            return PrintMessages.feedbackSuccesfullyCreated;
        }
    }
}
