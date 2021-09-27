using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;

namespace ManagementSystem.Commands.Commands
{
    class CreateStoryCommand : Command
    {
        /// <summary>
        /// Creates a new Story.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public CreateStoryCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = StoryInput.CreateStoryParameters();
           
            string title = parameters[0];
            string description = parameters[1];
            Priority newPriority = 0;
            if (Enum.TryParse(parameters[2], out Priority priority))
            {
                newPriority = priority;
            }
            StorySize newStorySize = 0;
            if (Enum.TryParse(parameters[3], out StorySize storySize))
            {
                newStorySize = storySize;
            }
            StoryStatus newStoryStatus = 0;
            if (Enum.TryParse(parameters[4], out StoryStatus storyStatus))
            {
                newStoryStatus = storyStatus;
            }

            var story = InstanceHolder.Factory.CreateStory(title, description, newPriority, newStorySize, newStoryStatus);
            InstanceHolder.Database.AddToStoryList(story);

            InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Created Story. | Title: {story.Title}");

            return PrintMessages.storySuccesfullyCreated;

        }
    }
    
}
