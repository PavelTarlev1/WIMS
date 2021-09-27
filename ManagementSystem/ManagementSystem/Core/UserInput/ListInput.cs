using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementSystem.Core.UserInput
{
    public class ListInput : UserInput
    {
        public string ListWorkItemInput()
        {
            List<string> options = new List<string>()
            {
                "Bug",
                "Story",
                "Feedback"
            };
            string option = InstanceHolder.Menu.DrawMenu(options);

            return option;
        }

        public List<string> FilterWorkItemByStatusInput()
        {
            Parameters.Add(ListWorkItemInput());
            if (Parameters[0] == "Bug")
            {
                InstanceHolder.Writer.WriteLine(PrintMessages.chooseStatus);
                Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(BugStatus)).ToList()));
            }
            if (Parameters[0] == "Story")
            {
                InstanceHolder.Writer.WriteLine(PrintMessages.chooseStatus);
                Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(StoryStatus)).ToList()));
            }
            if (Parameters[0] == "Feedback")
            {
                InstanceHolder.Writer.WriteLine(PrintMessages.chooseStatus);
                Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(FeedbackStatus)).ToList()));
            }

            return Parameters;
        }
        public List<string> FilterWorkItemByAssignee()
        {
            Parameters.Add(ListWorkItemInput());
            if (Parameters[0] == "Bug")
            {
                List<string> assigneeList = new List<string>();
                foreach (var item in InstanceHolder.Database.BugList)
                {
                    assigneeList.Add(item.Assignee.Name);
                }
                if (assigneeList == null)
                {
                    Parameters.Add(PrintMessages.noAssignees);
                }
                else
                {
                    InstanceHolder.Writer.WriteLine(PrintMessages.chooseAssignee);
                    Parameters.Add(InstanceHolder.Menu.DrawMenu(assigneeList));
                }

            }
            if (Parameters[0] == "Story")
            {
                List<string> assigneeList = new List<string>();
                foreach (var item in InstanceHolder.Database.StoryList)
                {
                    assigneeList.Add(item.Assignee.Name);
                }
                if (assigneeList == null)
                {
                    Parameters.Add(PrintMessages.noAssignees);
                }
                else
                {
                    InstanceHolder.Writer.WriteLine(PrintMessages.chooseAssignee);
                    Parameters.Add(InstanceHolder.Menu.DrawMenu(assigneeList));
                }
            }
            if (Parameters[0] == "Feedback")
            {
                List<string> assigneeList = new List<string>();
                foreach (var item in InstanceHolder.Database.FeedbacksList)
                {
                    assigneeList.Add(item.Assignee.Name);
                }
                if (assigneeList == null)
                {
                    Parameters.Add(PrintMessages.noAssignees);
                }
                else
                {
                    InstanceHolder.Writer.WriteLine(PrintMessages.chooseAssignee);
                    Parameters.Add(InstanceHolder.Menu.DrawMenu(assigneeList));
                }
            }

            return Parameters;
        }
        public string SortWorkItemsInput()
        {
            List<string> options = new List<string>()
            {
                "Bug",
                "Story",
                "Feedback"
                
            };
            string option = InstanceHolder.Menu.DrawMenu(options);

            return option;
        }
      
        public List<string> SortWorkItemsOptionsInput()
        {
            Parameters.Add(SortWorkItemsInput());
            if (Parameters[0] == "Bug")
            {
                InstanceHolder.Writer.WriteLine(PrintMessages.chooseSort);
                List<string> options = new List<string>() { "Title", "Priority", "Severity" };
                Parameters.Add(InstanceHolder.Menu.DrawMenu(options));
            }
            if (Parameters[0] == "Story")
            {
                InstanceHolder.Writer.WriteLine(PrintMessages.chooseSort);
                List<string> options = new List<string>() { "Title", "Priority", "Size", "Status" };
                Parameters.Add(InstanceHolder.Menu.DrawMenu(options));
            }
            if (Parameters[0] == "Feedback")
            {
                InstanceHolder.Writer.WriteLine(PrintMessages.chooseSort);
                List<string> options = new List<string>() { "Title", "Rating", "Status" };
                Parameters.Add(InstanceHolder.Menu.DrawMenu(options));
            }

            return Parameters;
        }
    }
}
