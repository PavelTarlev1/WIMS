using ManagementSystem.Models.Abstract;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Models.Contracts
{
    public interface IBug : IWorkItem
    {
        List<string> StepsToReproduce { get; }
        Priority Priority { get; set; }
        Severity Severity { get; set; }
        BugStatus Status { get; set; }
    }
}
