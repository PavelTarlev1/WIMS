using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Commands.StoryCommands
{
  public  class ChangeStorySizeCommand : Command
    {
        /// <summary>
        /// Changes the size of a Story.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public ChangeStorySizeCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = StoryInput.ChangeStorySizeCommandParameters();
            
            int id = int.Parse(parameters[0]);
            string newSize = parameters[1];

            IStory story = InstanceHolder.Database.StoryList.Where(i => i.Id == id).FirstOrDefault();

            if (Enum.TryParse(newSize, out StorySize storysize))
            {
                story.Size = storysize;
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Changed size of a Story | Title: {story.Title}" + Environment.NewLine + $"New Size: {story.Size}");

                return $"{PrintMessages.storySizeSuccessfullyChanged}{Environment.NewLine}" +
                       $"NewSize: {storysize}";
            }
            else
            {
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Attempt for changing the size of a Story | Title: {story.Title}" + Environment.NewLine + PrintMessages.storySizeNOTChanged);

                return PrintMessages.storySizeNOTChanged;
            }

        }
    }
}
