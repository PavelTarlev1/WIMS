using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Core.UserInput
{
    public class FeedbackInput : UserInput
    {
        /// <summary>
        /// Goes through the Feedback database and finds a specific Feedback.
        /// </summary>
        /// <returns>
        /// A new Feedback Rating.
        /// </returns>
        public List<string> ChangeFeedbackRatingParameters()
        {
            List<string> feedbackList = new List<string>();

            foreach (var item in InstanceHolder.Database.FeedbacksList)
            {
                feedbackList.Add(item.Title);
            }

            Parameters.Add(InstanceHolder.Menu.DrawMenu(feedbackList));
            InstanceHolder.Writer.Write(PrintMessages.newFeedbackRating);

            string newRating = InstanceHolder.Reader.ReadLine();

            Parameters.Add(newRating);
            return Parameters;
        }
        /// <summary>
        /// Goes through the Feedback database and finds a specific Feedback.
        /// </summary>
        /// <returns>
        /// A new Feedback Status.
        /// </returns>
        public List<string> ChangeFeedbackStatusParameters()
        {
            List<string> feedbackList = new List<string>();
            foreach (var item in InstanceHolder.Database.FeedbacksList)
            {
                feedbackList.Add(item.Title);
            }
            
            Parameters.Add(InstanceHolder.Menu.DrawMenu(feedbackList));
            InstanceHolder.Writer.WriteLine(PrintMessages.chooseStatus);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(FeedbackStatus)).ToList()));
            return Parameters;
        }
        /// <summary>
        /// Validates parameters from user input when creating a new Feedback.
        /// </summary>
        /// <returns>
        /// Returns a list string with validated parameters.
        /// </returns>
        public List<string> CreateFeedbackParameters()
        {
            InstanceHolder.Writer.WriteLine(PrintMessages.title);
            string title = InstanceHolder.Reader.ReadLine();
            Parameters.Add(title);

            InstanceHolder.Writer.WriteLine(PrintMessages.description);
            string description = InstanceHolder.Reader.ReadLine();
            Parameters.Add(description);

            InstanceHolder.Writer.WriteLine(PrintMessages.FeedbackRating);
            string rating = InstanceHolder.Reader.ReadLine();
            Parameters.Add(rating);

            InstanceHolder.Writer.WriteLine(PrintMessages.chooseStatus);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(FeedbackStatus)).ToList()));

            return Parameters;
        }
    }
}
