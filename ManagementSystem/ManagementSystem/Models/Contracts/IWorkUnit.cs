using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ManagementSystem.Models.Contracts
{
    public interface IUnit
    {
        public string Name { get; set; }

        [JsonConverter(typeof(WorkItemJsonConverter<List<WorkItem>>))]
        public List<IWorkItem> WorkItems { get; }

        public List<ActivityHistory> ActivityHistory { get; set; }

        string Print();
    }
}
