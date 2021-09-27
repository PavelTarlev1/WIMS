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

    class CreateBugCommand : Command
    {
        /// <summary>
        /// Creates a new Bug.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public CreateBugCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        { 
            List<string> parameters = BugInput.CreateBugParameters();
            string title = parameters[0];
            string description = parameters[1];

            List<string> stepsToProduce = parameters[2].Split("###").ToList();

            Priority newPriority = 0;
            if (Enum.TryParse(parameters[3], out Priority priority))
            {
                newPriority = priority;
            }

            Severity newSeverity = 0;
            if (Enum.TryParse(parameters[4], out Severity severity))
            {
                newSeverity = severity;
            }

            BugStatus newStatus = 0;
            if (Enum.TryParse(parameters[5], out BugStatus status))
            {
                newStatus = status;
            }
            IBug newBug = InstanceHolder.Factory.CreateBug(title, description, stepsToProduce, newPriority, newSeverity, newStatus);

            InstanceHolder.Database.AddToBugList(newBug);

            InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Created Board. | Title: {newBug.Title}");

            return PrintMessages.bugSuccesfullyCreated;
        }
    }
}
