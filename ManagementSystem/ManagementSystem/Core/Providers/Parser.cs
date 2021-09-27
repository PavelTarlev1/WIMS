using ManagementSystem.Commands.Contracts;
using ManagementSystem.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace ManagementSystem.Core.Providers
{
    public class Parser : IParser
    {
        public ICommand ParseCommand(string name)
        {  
                var commandTypeInfo = this.FindCommand(name);
                var command = Activator.CreateInstance(commandTypeInfo,Engine.GetInstance(), InstanceHolder.GetInstance()) as ICommand;
                return command;
        }

        /// <summary>
        /// Finds the and to execute.
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns>Returns TypeInfo of a command type.</returns>
        /// 
        private TypeInfo FindCommand(string commandName)
        {
            Assembly currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower() == (commandName.ToLower() + "command"))
                .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentException(PrintMessages.commandNotFound);
            }
            return commandTypeInfo;
        }
    }
}
