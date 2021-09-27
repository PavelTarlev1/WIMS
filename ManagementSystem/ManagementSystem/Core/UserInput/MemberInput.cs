using ManagementSystem.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Core.UserInput
{
   public class MemberInput : UserInput
    {
        /// <summary>
        /// Validates parameters from user input when creating a new Member.
        /// </summary>
        /// <returns>
        /// Returns a list string with validated parameters.
        /// </returns>
        public List<string> CreateMemberInputParameters()
        {
            InstanceHolder.Writer.WriteLine(PrintMessages.userName);
            string name = InstanceHolder.Reader.ReadLine();

            Parameters.Add(name);

           
            return Parameters;
        }
        /// <summary>
        /// Validates parameters from user input when creating a new Registration.
        /// </summary>
        /// <returns>
        /// Returns a list string with validated parameters.
        /// </returns>
        public List<string> RegisterParameters()
        {

            InstanceHolder.Writer.WriteLine(PrintMessages.userName);

            string username = string.Empty;

            //reading and saving the username
            while (true)
            {
                username = InstanceHolder.Reader.ReadLine();

                if (username.Length < 8)
                {
                    InstanceHolder.Writer.WriteLine(Environment.NewLine);
                    InstanceHolder.Writer.WriteLine(PrintMessages.usernameRequirements);
                }
                else
                {
                    if (InstanceHolder.Database.UsernamePasswordDatabase.ContainsKey(username))
                    {
                        InstanceHolder.Writer.WriteLine(Environment.NewLine);
                        InstanceHolder.Writer.WriteLine(PrintMessages.memberAlreadyExists);
                    }
                    else
                    {
                        Parameters.Add(username);
                        break;
                    }
                }
            }
            //reading and creating password
          
            while (true)
            {
                InstanceHolder.Writer.WriteLine(PrintMessages.password);
                string password = PasswordHiding();
                if (password.Length >= 8 &&
        password.Any(c => char.IsDigit(c)) &&
        password.Any(c => char.IsUpper(c)) &&
        password.Any(c => char.IsLower(c)))
                {
                    Parameters.Add(password);
                    break;
                }
                else
                {
                    InstanceHolder.Writer.WriteLine(Environment.NewLine);
                    InstanceHolder.Writer.WriteLine(PrintMessages.passwordRequirements);

                }
            }
            return Parameters;
        }

        /// <summary>
        /// Goes through the Member database and finds a specific Registered member.
        /// </summary>
        /// <returns>
        /// Returns a list string with validated parameters.
        /// </returns>
        
        public List<string> LoginParameters()
        {
            InstanceHolder.Writer.WriteLine(PrintMessages.userName);
            Parameters.Add(InstanceHolder.Reader.ReadLine());
            if (!(InstanceHolder.Database.UsernamePasswordDatabase.ContainsKey(Parameters[0])))
            {
                InstanceHolder.Writer.WriteLine(PrintMessages.memberDoesNotExist);
            }
            else
            {
                InstanceHolder.Writer.WriteLine(PrintMessages.password);
                Parameters.Add(InstanceHolder.Reader.ReadLine());

                if (InstanceHolder.Database.UsernamePasswordDatabase[Parameters[0]].Contains(Parameters[1]))
                {

                }
                else
                {
                    InstanceHolder.Writer.WriteLine(PrintMessages.wrongPassword);
                }
            }
            return Parameters;
        }

        /// <summary>
        /// Goes through the Member database and finds a specific Member.
        /// </summary>
        /// <returns>
        /// Returns a list string with validated parameters.
        /// </returns>
        public List<string> ShowMemberHistoryParameters()
        {
            List<string> memberList = new List<string>();
            foreach (var item in InstanceHolder.Database.MemberList)
            {
                memberList.Add(item.Name);
            }
            string currentMember = InstanceHolder.Menu.DrawMenu(memberList);
            List<string> member = currentMember.Split(" ").ToList();

            Parameters.Add(member[0]);
            return Parameters;
        }

        /// <summary>
        /// Hides the password while a member enters it.
        /// </summary>
        /// <returns>
        /// Returns a string with the password.
        /// </returns>
        private string PasswordHiding()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);

            pass = pass.Trim();
            return pass;
        }
    }
}

