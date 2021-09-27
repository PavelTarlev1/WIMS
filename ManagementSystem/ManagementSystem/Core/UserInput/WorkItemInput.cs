using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace ManagementSystem.Core.UserInput
{
    public class WorkItemInput : UserInput
    {
        /// <summary>
        /// Assigns a WorkItem(Bug/Story/Feedback) to Member.
        /// </summary>
        /// <returns>
        /// Returns a list of strings.
        /// </returns>
        public List<string> AssignWorkItemParameters()
        {
            bool choice2 = true;
            List<string> toWhatOption = new List<string>()
            {
                "Member",
                "Board"
            };
            string choice = InstanceHolder.Menu.DrawMenu(toWhatOption);
            List<string> options = new List<string>()
            {
                "Bug",
                "Story",
                "Feedback"
            };
            string option = InstanceHolder.Menu.DrawMenu(options);
              List<string> memberList = new List<string>();
            foreach (var item in InstanceHolder.Database.MemberList)
            {
                memberList.Add(item.Name);
            }
            List<string> boardList = new List<string>();
            foreach (var item in InstanceHolder.Database.BoardList)
            {
                boardList.Add(item.Name);
            }
            List<string> bugList = new List<string>();
            foreach (var item in InstanceHolder.Database.BugList)
            {
                bugList.Add(item.Title);
            }
            List<string> storyList = new List<string>();
            foreach (var item in InstanceHolder.Database.StoryList)
            {
                storyList.Add(item.Title);
            }
            List<string> feedbackList = new List<string>();
            foreach (var item in InstanceHolder.Database.FeedbacksList)
            {
                feedbackList.Add(item.Title);
            }
            if (true)
            {

            }
            if (choice=="Member")
            {
                switch (option)
            {
                case "Bug":
                    Parameters.Add(InstanceHolder.Menu.DrawMenu(bugList));
                    Parameters.Add(InstanceHolder.Menu.DrawMenu(memberList));
                        
                    break;
                case "Story":
                    Parameters.Add(InstanceHolder.Menu.DrawMenu(storyList));
                    Parameters.Add(InstanceHolder.Menu.DrawMenu(memberList));
                    break;
                case "Feedback":
                    Parameters.Add(InstanceHolder.Menu.DrawMenu(feedbackList));
                    Parameters.Add(InstanceHolder.Menu.DrawMenu(memberList));
                    break;
                default:
                    break;
            }
            }
            else
            {
                switch (option)
                {
                    case "Bug":
                        Parameters.Add(InstanceHolder.Menu.DrawMenu(bugList));
                        Parameters.Add(InstanceHolder.Menu.DrawMenu(boardList));
                        choice2 = false;
                        break;
                    case "Story":
                        Parameters.Add(InstanceHolder.Menu.DrawMenu(storyList));
                        Parameters.Add(InstanceHolder.Menu.DrawMenu(boardList));
                        choice2 = false;
                        break;
                    case "Feedback":
                        Parameters.Add(InstanceHolder.Menu.DrawMenu(feedbackList));
                        Parameters.Add(InstanceHolder.Menu.DrawMenu(boardList));
                        choice2 = false;
                        break;
                    default:
                        break;
                }

            }
            Parameters.Add(choice2.ToString());
            return Parameters;
        }
        /// <summary>
        /// Unassigns a WorkItem(Bug/Story/Feedback) to Member.
        /// </summary>
        /// <returns>
        /// Returns a list of strings.
        /// </returns>
        public List<string> UnassignWorkItemParameters()
        {

            List<string> options = new List<string>()
          {
              "Bug",
              "Story",
              "Feedback"
          };
            List<string> memberList = new List<string>();
            foreach (var item in InstanceHolder.Database.MemberList)
            {
                memberList.Add(item.Name);
            }
            Parameters.Add(InstanceHolder.Menu.DrawMenu(memberList));
            IMember member = InstanceHolder.Database.MemberList.Where(m => m.Name == Parameters[0]).FirstOrDefault();
            string option = InstanceHolder.Menu.DrawMenu(options);
            List<string> workItemList = new List<string>();
            foreach (var item in member.WorkItems)
            {
                workItemList.Add(item.Title);
            }
            Parameters.Add(InstanceHolder.Menu.DrawMenu(workItemList));
            return Parameters;
        }
        /// <summary>
        /// Adds a Comment to Bug/Story/Feedback.
        /// </summary>
        /// <returns>
        /// Returns a list of strings.
        /// </returns>
        public List<string> AddCommentToWorkItemParameters()
        {
            List<string> options = new List<string>()
            {
                "Bug",
                "Story",
                "Feedback"
            };
            string option = InstanceHolder.Menu.DrawMenu(options);
          
            List<string> bugList = new List<string>();
            foreach (var item in InstanceHolder.Database.BugList)
            {
                bugList.Add(item.Title);
            }
            List<string> storyList = new List<string>();
            foreach (var item in InstanceHolder.Database.StoryList)
            {
                storyList.Add(item.Title);
            }
            List<string> feedbackList = new List<string>();
            foreach (var item in InstanceHolder.Database.FeedbacksList)
            {
                feedbackList.Add(item.Title);
            }
            switch (option)
            {
                case "Bug":
                    Parameters.Add(InstanceHolder.Menu.DrawMenu(bugList));
                   
                    break;
                case "Story":
                    Parameters.Add(InstanceHolder.Menu.DrawMenu(storyList));
                  
                    break;
                case "Feedback":
                    Parameters.Add(InstanceHolder.Menu.DrawMenu(feedbackList));
                   
                    break;
                default:
                    break;
            }
            InstanceHolder.Writer.WriteLine("Comment:");
            Parameters.Add(InstanceHolder.Reader.ReadLine());
            return Parameters;
        }





    }
}
