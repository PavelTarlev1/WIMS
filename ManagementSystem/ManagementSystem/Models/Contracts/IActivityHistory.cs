using System;

namespace ManagementSystem.Models.Contracts
{
    public interface IActivityHistory
    {
        DateTime DatetimeNOW { get; }
        string Message { get; set; }

        string ToString();
    }
}