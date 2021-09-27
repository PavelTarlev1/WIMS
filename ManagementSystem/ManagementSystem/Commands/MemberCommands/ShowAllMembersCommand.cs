using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using System;
using System.Text;

namespace ManagementSystem.Commands.MemberCommands
{
    public class ShowAllMembersCommand : Command
    {
        /// <summary>
        /// Shows all members.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        /// <param name="writer"></param>
        public ShowAllMembersCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            StringBuilder str = new StringBuilder();
            foreach (var item in InstanceHolder.Database.MemberList)
            {
                str.AppendLine(item.Name);
            }
            InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Printed all Members in Database.");

            return str.ToString().Trim();
        }
    }
}
