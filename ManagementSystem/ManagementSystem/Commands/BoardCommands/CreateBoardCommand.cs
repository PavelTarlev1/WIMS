using ManagementSystem.Core;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Core.UserInput;
using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;

namespace ManagementSystem.Commands.BoardCommands
{
   
    public class CreateBoardCommand : Command
    {
        /// <summary>
        /// Creates a new Board.
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="instanceHolder"></param>
        public CreateBoardCommand(IEngine engine, InstanceHolder instanceHolder) : base(engine, instanceHolder)
        {
        }

        public override string Execute()
        {
            List<string> parameters = BoardInput.CreateBoardParameters();
            IBoard board = InstanceHolder.Factory.CreateBoard(parameters[0]);
            InstanceHolder.Database.AddToBoardList(board);

            InstanceHolder.Database.CreateActivityHistory($"{DateTime.Now} Created Board. | Name: {board.Name}");

            return PrintMessages.boardSuccessfullyCreated;
        }
    }
}

