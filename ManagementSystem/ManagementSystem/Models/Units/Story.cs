using ManagementSystem.Models.Abstract;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using System.Text;

namespace ManagementSystem.Models
{
    public class Story : WorkItem, IStory
    {
        public Story(string title, string description,
            Priority priority,
            StorySize size,
            StoryStatus status)
            : base(title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.Status = status;
        }

        public Priority Priority { get; set; }
        public StorySize Size { get; set; }
        public StoryStatus Status { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(base.ToString());

            str.AppendLine($"Priority: {this.Priority}");
            str.AppendLine($"Size: {this.Size}");
            str.AppendLine($"Status: {this.Status}");

            return str.ToString();
        }
    }
}
