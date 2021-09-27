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
    class ChangeBugStatusCommand : Command
    {
        /// <summary>
        /// Changes the Status of a Bug.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public ChangeBugStatusCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
           
            List<string> parameters = BugInput.ChangeBugStatusParameters();
          
            int id = int.Parse(parameters[0]);
            string newStatus = parameters[1];

            IBug bug = InstanceHolder.Database.BugList.Where(i => i.Id == id).FirstOrDefault();

            if (Enum.TryParse(newStatus, out BugStatus status))
            {
                bug.Status = status;
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Changed status of a Bug | Title: {bug.Title}" + Environment.NewLine + $"New Status: {bug.Status}");

                return $"{PrintMessages.statusChanged}{Environment.NewLine}" +
                       $"New Status: {status}";
            }
            else
            {
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Attempt for changing the status of a Bug | Title: {bug.Title}" + Environment.NewLine + PrintMessages.statusNotChanged);

                return PrintMessages.statusNotChanged;
            }
        }
    }
}
