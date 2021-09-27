using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Core.UserInput;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Commands.BugCommands
{  
    class ChangeBugPriorityCommand : Command
    {
        /// <summary>
        /// Changes the Priority of a Bug.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// 
        public ChangeBugPriorityCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = BugInput.ChangeBugPriorityCommandParameters();

            int id = int.Parse(parameters[0]);

            IBug bug = InstanceHolder.Database.BugList.Where(i => i.Id == int.Parse(parameters[0])).FirstOrDefault();

            if (Enum.TryParse(parameters[1], out Priority priority))
            {
                bug.Priority = priority;
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Changed priority of a Bug | Title: {bug.Title}" + Environment.NewLine + $"New Priority: {priority}");
                 
                return $"{PrintMessages.priorityChanged}{Environment.NewLine}" +
                       $"New Priority: {priority}";
            }
            else
            {
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Attempt for changing the priority of a Bug | Title: {bug.Title}" + Environment.NewLine + PrintMessages.priorityNotChanged);

                return PrintMessages.priorityNotChanged;
            }
        }
    }
}
 