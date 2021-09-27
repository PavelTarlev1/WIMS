using ManagementSystem.Commands.Contracts;
using ManagementSystem.Core.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string name);
    }
}
