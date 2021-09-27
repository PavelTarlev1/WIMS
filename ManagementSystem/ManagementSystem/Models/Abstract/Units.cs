using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementSystem.Models.Abstract
{
    public abstract class Unit : IUnit
    {
    
        public Unit(string name)
        {
            Name = name;
            WorkItems = new List<IWorkItem>();
            ActivityHistory = new List<ActivityHistory>();
        }

        public virtual string Name { get; set; }

        
        public List<IWorkItem> WorkItems { get; set; }
        public List<ActivityHistory> ActivityHistory { get; set; }

       public virtual string Print()
        {
            return "";
        }
        public string PrintAllDetails()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(this.Name);
            foreach (var item in this.WorkItems)
            {
                str.AppendLine($"Title: {item.Title}");
                str.AppendLine($"Description: {item.Description}");

                foreach (var workitem in this.WorkItems)
                {
                    workitem.ToString();
                }
                foreach (var history in item.ActivityHistory)
                {
                    history.ToString();
                }
            }
            return str.ToString();
        }
    }
}
