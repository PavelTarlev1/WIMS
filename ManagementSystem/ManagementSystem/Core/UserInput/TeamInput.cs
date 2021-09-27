using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Core.UserInput
{
   public class TeamInput : UserInput
    {

        /// <summary>
        /// Goes through the Team database and finds a specific Feedback.
        /// </summary>
        /// <returns>
        /// Returns a string with the Name of the Team.
        /// </returns>
        public string GetTeamName()
        {
            List<string> teams = new List<string>();
            foreach (var item in InstanceHolder.Database.TeamList)
            {
                teams.Add(item.Name);
            }
            string teamName = InstanceHolder.Menu.DrawMenu(teams);

            return teamName;
        }
        /// <summary>
        /// Validates parameters from user input when creating a new Team.
        /// </summary>
        /// <returns>
        /// Returns a list string with validated parameters.
        /// </returns>
        public List<string> CreateTeamParameters()
        {
            InstanceHolder.Writer.WriteLine(PrintMessages.title);
           
            string name = InstanceHolder.Reader.ReadLine();

                ITeam team = InstanceHolder.Database.TeamList.Where(n => n.Name == name).FirstOrDefault();
                if (InstanceHolder.Database.TeamList.Contains(team))
                {
                    InstanceHolder.Writer.WriteLine(PrintMessages.teamAlreadyExist);
                }
                else
                {
                    Parameters.Add(name);
                }
            return Parameters;
        }
        /// <summary>
        /// Goes through the Team database and finds a specific Team.
        /// </summary>
        /// <returns>
        /// The name of the Team.
        /// </returns>
        public List<string> ShowAllTeamBoardsParameters()
        {
            List<string> teams = new List<string>();

            foreach (var item in InstanceHolder.Database.TeamList)
            {
                teams.Add(item.Name);
            }
            Parameters.Add(InstanceHolder.Menu.DrawMenu(teams));

            return Parameters;
        }
        /// <summary>
        /// Goes through the Team database and finds a specific Team.
        /// </summary>
        /// <returns>
        /// A list of strings with the team name and the member to be added in the team.
        /// </returns>
        public List<string> AddMemberToTeamParameters()
        {
            List<string> teams = new List<string>();
            List<string> members = new List<string>();
            foreach (var item in InstanceHolder.Database.TeamList)
            {
                teams.Add(item.Name);
            }

            Parameters.Add(InstanceHolder.Menu.DrawMenu(teams));

            foreach (var item in InstanceHolder.Database.MemberList)
            {
                members.Add(item.Name);
            }
            Parameters.Add(InstanceHolder.Menu.DrawMenu(members));
            return Parameters;
        }
        /// <summary>
        /// Goes through the Team database and finds a specific Member name within a team.
        /// </summary>
        /// <returns>
        /// A new Feedback Status.
        /// </returns>
        public string GetMemberName()
        {
            List<string> members = new List<string>();
            foreach (var item in InstanceHolder.Database.MemberList)
            {
                members.Add(item.Name);
            }
            string memberName = InstanceHolder.Menu.DrawMenu(members);

            return memberName;
        }
    }
}
