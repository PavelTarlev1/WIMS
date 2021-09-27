using ManagementSystem.Models.Contracts;
using System;

namespace ManagementSystem.Models
{
    public class ActivityHistory : IActivityHistory
    {
        public ActivityHistory(string message)
        {
            this.Message = message;
            this.DatetimeNOW = DateTime.Now;
        }
       
        public DateTime DatetimeNOW { get; }
        public string Message { get; set; }

        public override string ToString()
        {
            string result = $"{this.DatetimeNOW} | {this.Message}";
            return result;
        }
    }
}