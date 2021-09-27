using ManagementSystem.Models.Abstract;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using ManagementSystem.Models.Units;
using System;
using System.Text;

namespace ManagementSystem.Models
{
    public class Feedback : WorkItem, IFeedback
    {
        private int rating;

        public Feedback(string title, string description, int rating,
            FeedbackStatus status)
            : base(title, description)
        {
            this.Rating = rating;
            this.Status = status;
        }

        public int Rating
        {
            get => this.rating;
            set
            {
                if (value < 0)
                {
                    throw new Exception(ValidationMessages.RatingShouldBePositiveNum);
                }
                else
                {
                    this.rating = value;
                }
            }
        }
        public FeedbackStatus Status { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(base.ToString());
            str.AppendLine($"Rating: {this.Rating}");
            str.AppendLine($"Status: {this.Status}");

            return str.ToString();
        }
    }
}
