using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Core.UserInput
{
    public class StoryInput : UserInput
    {

        /// <summary>
        /// Goes through the Story database and finds a specific Story.
        /// </summary>
        /// <returns>
        /// Returns a string with the ID of the chosen Story.
        /// </returns>
        private string GetStoryID()
        {
            List<string> storyList = new List<string>();

            foreach (var item in InstanceHolder.Database.StoryList)
            {
                storyList.Add(string.Join(" ", item.Id, item.Title));
            }
            string currentStory = InstanceHolder.Menu.DrawMenu(storyList);
            string id = currentStory.Split(" ")[0];

            return id;
        }
        /// <summary>
        /// Validates parameters from user input when creating a new Story.
        /// </summary>
        /// <returns>
        /// Returns a list string with validated parameters.
        /// </returns>
        public List<string> CreateStoryParameters()
        {

            InstanceHolder.Writer.WriteLine(PrintMessages.title);
            string title = InstanceHolder.Reader.ReadLine();

            Parameters.Add(title);

            InstanceHolder.Writer.WriteLine(PrintMessages.description);
            string description = InstanceHolder.Reader.ReadLine();

            Parameters.Add(description);

            InstanceHolder.Writer.WriteLine(PrintMessages.choosePriority);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(Priority)).ToList()));
            InstanceHolder.Writer.WriteLine(PrintMessages.chooseSize);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(StorySize)).ToList()));
            InstanceHolder.Writer.WriteLine(PrintMessages.chooseStatus);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(StoryStatus)).ToList()));

            return Parameters;
        }
        /// <summary>
        /// Goes through the Story database and finds a specific Story.
        /// </summary>
        /// <returns>
        /// Returns a new Story Size.
        /// </returns>
        public List<string> ChangeStorySizeCommandParameters()
        {
            Parameters.Add(GetStoryID());
            InstanceHolder.Writer.WriteLine(PrintMessages.chooseSize);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(StorySize)).ToList()));

            return Parameters;
        }

        /// <summary>
        /// Goes through the Story database and finds a specific Feedback.
        /// </summary>
        /// <returns>
        /// Returns a new Story Status.
        /// </returns>
        public List<string> ChangeStoryStatusCommandParameters()
        {

            Parameters.Add(GetStoryID());
            InstanceHolder.Writer.WriteLine(PrintMessages.chooseStatus);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(StoryStatus)).ToList()));

            return Parameters;
        }

        /// <summary>
        /// Goes through the Story database and finds a specific Feedback.
        /// </summary>
        /// <returns>
        /// Returns a new Story Priority.
        /// </returns>
        public List<string> ChangeStoryPriorityParameters()
        {
            Parameters.Add(GetStoryID());
            InstanceHolder.Writer.WriteLine(PrintMessages.choosePriority);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(Priority)).ToList()));

            return Parameters;
        }
    }
}
