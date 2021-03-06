using ManagementSystem.Core.Contracts;
using System;
using System.IO;

namespace ManagementSystem.Core.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
             Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
