using ManagementSystem.Core.Contracts;
using System;

namespace ManagementSystem.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
