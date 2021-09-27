using ManagementSystem.Commands.Contracts;
using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Core.UserInput;
using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementSystem.Commands.MemberCommands
{
    public class ShowMemberHistoryCommand : Command
    {
        /// <summary>
        /// Shows the activity history of a sertain member.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public ShowMemberHistoryCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = MemberInput.ShowMemberHistoryParameters();

            IMember currMember = InstanceHolder.Database.MemberList.Where(i => i.Name == parameters[0]).FirstOrDefault();
            StringBuilder str = new StringBuilder();
            
            if (currMember != null)
            {
                if (currMember.ActivityHistory.Count == 0)
                {
                    InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Attempt for printing history of | Username: {currMember.Name}" + Environment.NewLine + PrintMessages.memberHistoryEmpty);

                    return PrintMessages.memberHistoryEmpty;
                }
                else
                {
                    foreach (var item in currMember.ActivityHistory)
                    {
                        str.AppendLine(item.ToString());
                    }
                    InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Printed history of Member: {currMember.Name}.");
                    return str.ToString();
                }
            }
            else
            {
                return PrintMessages.memberDoesNotExist;
            }
        }
    }
}
