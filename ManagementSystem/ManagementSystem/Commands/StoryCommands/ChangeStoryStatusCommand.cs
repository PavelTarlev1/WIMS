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
    public class ChangeStoryStatusCommand : Command
    {
        /// <summary>
        /// Changes the Status of a Story.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public ChangeStoryStatusCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = StoryInput.ChangeStoryStatusCommandParameters();
       
            int id = int.Parse(parameters[0]);
            string newStatus = parameters[1];

            IStory story = InstanceHolder.Database.StoryList.Where(i => i.Id == id).FirstOrDefault();

            if (Enum.TryParse(newStatus, out StoryStatus status))
            {
                story.Status = status;
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Changed status of a Story | Title: {story.Title}" + Environment.NewLine + $"New Status: {story.Status}");

                return $"{PrintMessages.statusChanged}{Environment.NewLine}" +
                       $"New Status: {status}";
            }
            else
            {
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Attempt for changing the status of a Story | Title: {story.Title}" + Environment.NewLine + PrintMessages.statusNotChanged);
                return PrintMessages.statusNotChanged;
            }
        }
    }
}
