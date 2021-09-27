using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Models.Contracts
{
    public interface IFeedback : IWorkItem
    {
        public int Rating { get; set; }
        public FeedbackStatus Status { get; set; }
    }
}
