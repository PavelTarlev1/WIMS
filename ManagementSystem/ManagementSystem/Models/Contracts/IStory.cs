using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Models.Contracts
{
   public  interface IStory : IWorkItem
    {
        Priority Priority { get; set; }
        StorySize Size { get; set; }
        StoryStatus Status { get; set; }
      
    }
}
