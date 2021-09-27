using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Commands.FeedbackCommands
{
    public class ChangeFeedbackRatingCommand : Command
    {
        /// <summary>
        /// Changes the rating of a Feedback.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public ChangeFeedbackRatingCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = FeedbackInput.ChangeFeedbackRatingParameters();
    
            string title = parameters[0];
            string newRating = parameters[1];

            IFeedback feedback = InstanceHolder.Database.FeedbacksList.Where(t => t.Title == title).FirstOrDefault();
            if (int.TryParse(newRating, out int number))
            {
                feedback.Rating= number;
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Changed rating of Feedback | Title: {feedback.Title}" + Environment.NewLine + $"New Rating: {feedback.Rating}");
                return $"{PrintMessages.feedbackRatingChanged}{Environment.NewLine}" +
                       $"NewRating: {number}";
            }
            else
            {
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Attempt for changing the rating of a Feedback | Title: {feedback.Title}" + Environment.NewLine + PrintMessages.feedbackRatingNotChanged);

                return PrintMessages.feedbackRatingNotChanged;
            }  
        }
    }
}
