using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Models.Common
{
    public class Comments : IComments
    {
        public Comments(string message)
        {
            this.DatetimeNOW = DateTime.Now;
            this.Message = message;
        }
        public DateTime DatetimeNOW { get; }
        
        public string Message { get; set; }

        public override string ToString()
        {
            string output = $"{DatetimeNOW} |{this.Message}";
            return output;
        }
    }
}
