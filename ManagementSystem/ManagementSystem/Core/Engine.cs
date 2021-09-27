using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using System;

namespace ManagementSystem.Core
{
    public class Engine : IEngine
    {
        private static Engine instanceHolder;
        public static string commandType;

        private Engine()
        {
            this.Instanceholder = InstanceHolder.GetInstance();
        }

        public InstanceHolder Instanceholder { get; private set; }

        public static Engine GetInstance()
        {
            if (instanceHolder == null)
            {
                instanceHolder = new Engine();
            }
            return instanceHolder;
        }

        public void Start()
        {
            while (true)
            {
                string selectedItem = null;

                if (Instanceholder.BoolVariables.showMenu == false && Instanceholder.BoolVariables.showFullMenu == false)
                {
                    selectedItem = Instanceholder.Menu.DrawMenu(PrintMessages.ShowMenu);
                }
                if (Instanceholder.BoolVariables.isLogged == false && Instanceholder.BoolVariables.showMenu == true)
                {
                    selectedItem = Instanceholder.Menu.DrawMenu(PrintMessages.menuItemsNotLogged);
                }

                if (Instanceholder.BoolVariables.isLogged == true && Instanceholder.BoolVariables.showMenu == true && Instanceholder.BoolVariables.showFullMenu == true)
                {
                    selectedItem = Instanceholder.Menu.DrawMenu(PrintMessages.menuList);
                }

                if (selectedItem == "" || selectedItem == null || selectedItem == "--------------------")
                {

                }
                else
                {

                    if (selectedItem == "" || selectedItem == null || selectedItem == "--------------------")
                    {
                        Instanceholder.BoolVariables.showMenu = true;
                    }
                    else
                    {
                        Instanceholder.BoolVariables.showMenu = false;
                        Instanceholder.BoolVariables.showFullMenu = false;
                    }
                    try
                    {
                        var commandName = selectedItem;
                        commandType = commandName;
                        if (commandName.ToLower() == PrintMessages.ExitCommand.ToLower())
                        {
                            InstanceHolder.GetInstance().Database.SaveAllListsToFiles();

                            break;
                        }
                        Menu.index = 0;
                        this.ProcessCommand(commandName);
                    }
                    catch (Exception ex)
                    {
                        this.Instanceholder.Writer.WriteLine(ex.Message);
                    }
                }
            }
        }
        private void ProcessCommand(string commandName)
        {
            if (string.IsNullOrWhiteSpace(commandName))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }
            var command = this.Instanceholder.Parser.ParseCommand(commandName);

            var executionResult = command.Execute();
            this.Instanceholder.Writer.WriteLine(executionResult);
        }
    }
}



