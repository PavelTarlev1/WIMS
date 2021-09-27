using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementSystem.Core.UserInput
{
    public class BugInput : UserInput
    {

        /// <summary>
        /// Validates parameters from user input when creating a new Bug.
        /// </summary>
        /// <returns>
        /// Returns a list string with validated parameters.
        /// </returns>
        public List<string> CreateBugParameters()
        {
            InstanceHolder.Writer.WriteLine(PrintMessages.writeNameOfBug);
            string name = InstanceHolder.Reader.ReadLine();

            Parameters.Add(name);

            InstanceHolder.Writer.WriteLine(PrintMessages.description);
            string description = InstanceHolder.Reader.ReadLine();
            Parameters.Add(description);

            InstanceHolder.Writer.WriteLine(PrintMessages.stepsToProduce);
            StringBuilder stepsToProduce = new StringBuilder();
            //makes sure that it is a number what they write without throwing an exception
            while (true)
            {
                InstanceHolder.Writer.WriteLine(PrintMessages.chooseNumberOfSteps);
                string numberOfSteps = InstanceHolder.Reader.ReadLine();

                if ((int.TryParse(numberOfSteps, out int steps)))
                {
                    for (int i = 0; i < steps; i++)
                    {
                        stepsToProduce.Append(InstanceHolder.Reader.ReadLine());
                        stepsToProduce.Append(delimeter);
                    }
                    break;
                }
                else
                {
                    InstanceHolder.Writer.WriteLine(PrintMessages.inputINTneeded);
                }
            }
            Parameters.Add(stepsToProduce.ToString());
            InstanceHolder.Writer.WriteLine(PrintMessages.choosePriority);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(Priority)).ToList()));
            InstanceHolder.Writer.WriteLine(PrintMessages.chooseSeverity);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(Severity)).ToList()));
            InstanceHolder.Writer.WriteLine(PrintMessages.chooseStatus);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(BugStatus)).ToList()));

            return Parameters;
        }

        /// <summary>
        ///  Goes through the Bug database and finds a specific Bug.
        /// </summary>
        /// <returns>
        /// Returns a string - the ID of the Bug.
        /// </returns>
        private string GetBugID()
        {
            List<string> bugList = new List<string>();

            foreach (var item in InstanceHolder.Database.BugList)
            {
                bugList.Add(string.Join(" ", item.Id, item.Title));
            }
            string currentBug = InstanceHolder.Menu.DrawMenu(bugList);
            string id = currentBug.Split(" ")[0];

            return id;
        }

        /// <summary>
        /// Goes through the Bug database and finds a specific Bug.
        /// </summary>
        /// <returns>
        /// A new Bug Priority.
        /// </returns>
        public List<string> ChangeBugPriorityCommandParameters()
        {
            Parameters.Add(GetBugID());
            InstanceHolder.Writer.WriteLine(PrintMessages.choosePriority);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(Priority)).ToList()));

            return Parameters;
        }

        /// <summary>
        /// Goes through the Bug database and finds a specific Bug.
        /// </summary>
        /// <returns>
        /// A new Bug Severity.
        /// </returns>
        public List<string> ChangeBugSeverityCommandParameters()
        {

            Parameters.Add(GetBugID());
            InstanceHolder.Writer.WriteLine(PrintMessages.chooseSeverity);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(Severity)).ToList()));

            return Parameters;
        }

        /// <summary>
        /// Goes through the Bug database and finds a specific Bug.
        /// </summary>
        /// <returns>
        /// A new Bug Status.
        /// </returns>
        public List<string> ChangeBugStatusParameters()
        {
            Parameters.Add(GetBugID());

            InstanceHolder.Writer.WriteLine(PrintMessages.choosePriority);
            Parameters.Add(InstanceHolder.Menu.DrawMenu(Enum.GetNames(typeof(BugStatus)).ToList()));

            return Parameters;
        }
    }
}
