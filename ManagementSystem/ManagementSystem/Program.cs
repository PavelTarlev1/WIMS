using ManagementSystem.Core;

namespace ManagementSystem
{
    class Program
    {
        /// <summary>
        /// The start of the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var engine = Engine.GetInstance();
            engine.Start();
        }
    }
}
