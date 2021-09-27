using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Models.Contracts
{
    public interface ITeam
    {
        string Name { get; set; }
        List<IBoard> Boards { get; set; }
        List<IMember> Members { get; set; }
    }
}
