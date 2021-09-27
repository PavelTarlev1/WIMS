using System.Collections.Generic;

namespace ManagementSystem.Core.Contracts
{
    public interface IMenu
    {
        string DrawMenu(List<string> items);
    }
}