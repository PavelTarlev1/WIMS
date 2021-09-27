using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ManagementSystem.Commands.Commands
{
    public class ChangeStoryPriorityCommand : Command
    {
        /// <summary>
        /// Changes the priority of a Story.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public ChangeStoryPriorityCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            //done
            List<string> parameters = StoryInput.ChangeStoryPriorityParameters();
            int id = int.Parse(parameters[0]);
            string newPriority = parameters[1];

            IStory story = InstanceHolder.Database.StoryList.Where(i => i.Id == id).FirstOrDefault();

            if (Enum.TryParse(newPriority, out Priority priority))
            {
                story.Priority = priority;
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Changed priority of a Story | Title: {story.Title}" + Environment.NewLine + 
                    $"New Priority: {story.Priority}");
                
                return $"{PrintMessages.priorityChanged}{Environment.NewLine}" +
                       $"NewStatus: {priority}";
            }
            else
            {
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Attempt for changing the priority of a Story | Title: {story.Title}" + Environment.NewLine + PrintMessages.priorityNotChanged);
                return PrintMessages.priorityNotChanged;
            }

        }
    }
}
