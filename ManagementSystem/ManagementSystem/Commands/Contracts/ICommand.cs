using ManagementSystem.Core.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(); 
    }
}
