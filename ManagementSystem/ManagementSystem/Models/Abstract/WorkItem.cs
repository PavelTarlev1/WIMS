using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Common;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Units;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ManagementSystem.Models.Abstract
{
    public abstract class WorkItem : IWorkItem
    {
        private int id;
        private string title;
        private string description;
        private static List<int> ids;
        private IMember assignee;

        protected WorkItem(string title, string description)
        {
            this.Title = title;
            this.Description = description;
            this.Comments = new List<IComments>();
            this.ActivityHistory = new List<ActivityHistory>();
            ids = new List<int>();
            this.Id = CreateID();
            this.Assignee = assignee;
        }

        public int Id { get => this.id; private set => this.id = value; }
        public IMember Assignee { get; set; }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ValidationMessages.TitleNameLenght);
                }
                else if (value.Length < 10 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException(ValidationMessages.TitleNameLenght);
                }
                else
                {
                    this.title = value;
                }
            }
        }

        public string Description
        {
            get { return this.description; }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ValidationMessages.DescriptionLength);
                }
                if (value.Length < 10 || value.Length > 500)
                {
                    throw new Exception(ValidationMessages.DescriptionLength);
                }
                this.description = value;
            }

        }

        [JsonConverter(typeof(CommentJsonConverter<List<Comments>>))]
        public List<IComments> Comments { get; protected set; }
        public List<ActivityHistory> ActivityHistory { get; protected set; }

        /// <summary>
        ///  Creates unique ID.
        /// </summary>
        /// <returns>Returns the created ID.</returns>
        public int CreateID()
        {
            int lastID = ids.Count;
            lastID++;
            ids.Add(lastID);
            return lastID;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"ID: {this.Id} | {this.Title}");
            str.AppendLine($"Description: {this.Description}");

            str.AppendLine("Comments:");
            foreach (var item in this.Comments)
            {
                str.AppendLine(item.ToString());
            }

            str.AppendLine("Activity history:");
            foreach (var item in this.ActivityHistory)
            {
                str.AppendLine(item.ToString());
            }

            return str.ToString();
        }

    }
}
