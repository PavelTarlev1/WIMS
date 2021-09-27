using ManagementSystem.Core.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Core.Contracts
{
    public interface IEngine
    {
        void Start();
        InstanceHolder Instanceholder { get; }
    }
}
