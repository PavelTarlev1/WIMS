using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementSystem.Core.UserInput
{
    public class    BoardInput : UserInput
    {
        /// <summary>
        /// Validates parameters from user input when creating a new Board.
        /// </summary>
        /// <returns>
        /// Returns a list string with validated parameters.
        /// </returns>
       
        public List<string> CreateBoardParameters()
        {
            InstanceHolder.Writer.WriteLine(PrintMessages.title);
            while (true)
            {
                string name = InstanceHolder.Reader.ReadLine();

                if (name == null)
                {
                    throw new ArgumentNullException(ValidationMessages.BoardNameLength);
                }
                else if (name.Length < 5 || name.Length > 10)
                {
                    throw new ArgumentOutOfRangeException(ValidationMessages.BoardNameLength);
                }


                if (InstanceHolder.Database.BoardList.Any(n => n.Name == name))
                {
                    InstanceHolder.Writer.WriteLine(PrintMessages.boardAlreadyExists);
                }
                else
                {
                    Parameters.Add(name);
                    break;
                }
            }
            return Parameters;
        }
        /// <summary>
        /// Goes through the Board database and finds a specific Board.
        /// </summary>
        /// <returns>
        /// Returns a list string with validated parameters - the name of the Board.
        /// </returns>
        public string GetBoardName()
        {
            List<string> boarList = new List<string>();
            foreach (var item in InstanceHolder.Database.BoardList)
            {
                boarList.Add(item.Name);
            }

            string boardName = InstanceHolder.Menu.DrawMenu(boarList);

            if (InstanceHolder.Database.BoardList.Any(n=>n.Name == boardName))
            {
                Parameters.Add(boardName);
            }
            else
            {
                throw new Exception(PrintMessages.boardDoesNotExist);
            }
            return boardName;
        }

        /// <summary>
        /// Goes through the Board databas, finds a specific Board.
        /// </summary>
        /// <returns>
        /// Returns the name of the Board which Activity History will be printed.
        /// </returns>
        public List<string> ShowBoardActivityParameters()
        {
            InstanceHolder.Writer.WriteLine(PrintMessages.AllBoards);
            Parameters.Add(GetBoardName());
            return Parameters;
        }
        public List<string> AddBoardToTeamParameters()
        {
            List<string> teams = new List<string>();
            List<string> board = new List<string>();
            foreach (var item in InstanceHolder.Database.TeamList)
            {
                teams.Add(item.Name);
            }

            Parameters.Add(InstanceHolder.Menu.DrawMenu(teams));

            foreach (var item in InstanceHolder.Database.BoardList)
            {
                board.Add(item.Name);
            }
            Parameters.Add(InstanceHolder.Menu.DrawMenu(board));
            return Parameters;
        }
    }
}
