using ManagementSystem.Models.Common;
using System.Collections.Generic;

namespace ManagementSystem.Models.Contracts
{
    public interface IWorkItem
    {
        List<IComments> Comments { get; }
        string Description { get; }
        List<ActivityHistory> ActivityHistory { get; }
        int Id { get; }
        string Title { get; }
        public IMember Assignee { get; set; }
    }
}