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
    class ChangeBugSeverityCommand : Command
    {
        /// <summary>
        /// Changes the Severity of a Bug.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public ChangeBugSeverityCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }
        public override string Execute()
        {
            List<string> parameters = BugInput.ChangeBugSeverityCommandParameters();

            int id = int.Parse(parameters[0]);
            string newSeverity = parameters[1];

            IBug bug = InstanceHolder.Database.BugList.Where(i => i.Id == id).FirstOrDefault();

            if (Enum.TryParse(newSeverity, out Severity severity))
            {
                bug.Severity = severity;
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Changed severity of a Bug | Title: {bug.Title}" + Environment.NewLine + $"New Severity: {bug.Severity}");

                return $"{PrintMessages.severityChanged}{Environment.NewLine}" +
                       $"NewSeverity: {severity}";
            }
            else
            {
                InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Attempt for changing the severity of a Bug | Title: {bug.Title}" + Environment.NewLine + PrintMessages.severityNotChanged);

                return PrintMessages.severityNotChanged;
            }
        }
    }
}
