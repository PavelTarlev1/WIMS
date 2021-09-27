using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using System;
using System.Collections.Generic;

namespace ManagementSystem.Commands
{
    public class LoginCommand : Command
    {
        /// <summary>
        /// Logs in a regstered member.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public LoginCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            //List<string> parameters = MemberInput.LoginParameters();
            //string username = parameters[0];
            //string password = parameters[1];

            //if (InstanceHolder.Database.UsernamePasswordDatabase.ContainsKey(username) && InstanceHolder.Database.UsernamePasswordDatabase[username] == password)
            //{
            //    InstanceHolder.BoolVariables.isLogged = true;
            //    CreateActivityHistory($"{DateTime.Now} Member logged in. | Username: {username}");
            //    return PrintMessages.successfullyLoggedIn;
            //}
            //else
            //{
            //    CreateActivityHistory($"{DateTime.Now} Attempt for logging in. | Username: {username}" + Environment.NewLine + PrintMessages.memberNotLoggedIn);
            //    return PrintMessages.memberNotLoggedIn;
            //}
            InstanceHolder.BoolVariables.isLogged = true;
                return "";
        }
    }
}
