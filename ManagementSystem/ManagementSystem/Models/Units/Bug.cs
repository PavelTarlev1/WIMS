using ManagementSystem.Models.Abstract;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Models.Units
{
    public class Bug : WorkItem, IBug
    {
        public Bug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity, BugStatus status)
            : base(title, description)
        {
            this.StepsToReproduce = stepsToReproduce;
            this.Priority = priority;
            this.Severity = severity;
            this.Status = status;
        }

        public List<string> StepsToReproduce { get; set; }
        public Priority Priority { get; set; }
        public Severity Severity { get; set; }
      
        public BugStatus Status { get; set; }

        //Made a new ToString because I wanted to change the order a little bit
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"ID: {this.Id} | {this.Title}");
            str.AppendLine($"Description: {this.Description}");

            int counter = 1;
            foreach (var step in this.StepsToReproduce)
            {
                str.AppendLine($"{counter}. {step}");
                counter++;
            }

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

            str.AppendLine($"Priority: {this.Priority}");
            str.AppendLine($"Severity: {this.Severity}");
            str.AppendLine($"Status: {this.Status}");

            return str.ToString();
        }
    }
}
