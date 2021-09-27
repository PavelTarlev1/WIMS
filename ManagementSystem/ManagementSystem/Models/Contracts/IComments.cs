using System;

namespace ManagementSystem.Models.Contracts
{
   public interface IComments
    {
        DateTime DatetimeNOW { get; }
        string Message { get; set; }
     

        string ToString();
    }
}