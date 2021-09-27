using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Models
{
    public class Team : ITeam
    {
        private string name;
        private List<IMember> members;
        private List<IBoard> boards;
        public Team(string name)
        {
            this.Name = name;
            Members = new List<IMember>();
            Boards = new List<IBoard>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ValidationMessages.BoardNameLength);
                }
                else if (value.Length < 5 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException(ValidationMessages.BoardNameLength);
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public List<IBoard> Boards { get; set; }
        public List<IMember> Members { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Team name: {this.Name}");
            str.AppendLine("Members of the team:");
            foreach (var item in this.Members)
            {
                str.AppendLine(item.ToString());
            }
            str.AppendLine("Boards of this team:");
            foreach (var item in this.Boards)
            {
                str.AppendLine(item.ToString());
            }

            return str.ToString();
        }
    }
}
