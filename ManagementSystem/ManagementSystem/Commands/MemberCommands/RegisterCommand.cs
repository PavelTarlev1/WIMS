using ManagementSystem.Commands.Contracts;
using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Factories;
using ManagementSystem.Core.Providers;
using ManagementSystem.Core.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Commands
{
    /// <summary>
    /// Command for register.
    /// </summary>
    public class RegisterCommand : Command
    {
        /// <summary>
        /// Registers a new member.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public RegisterCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = MemberInput.RegisterParameters();

            InstanceHolder.Database.UsernamePasswordDatabase.Add(parameters[0], parameters[1]);
            InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} New Member successfully registered. | Username: {parameters[0]}");

            return PrintMessages.successfullyRegistered;
        }
    }
}
