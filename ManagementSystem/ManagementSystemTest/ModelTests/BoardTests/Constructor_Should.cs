using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystemTests.ModelTests.BoardTests
{
    [TestClass]
   public class Constructor_Should
    {

        [TestMethod]
        public void Should_Assign_Name_Correctly()
        {
            Board board = new Board("Jivkoboard");

            Assert.AreEqual("Jivkoboard", board.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_Exception_If_Name_Lenght_Is_Invalid()
        {
            new Board("J");
            new Board("jjjjjjjjjjjjjjjjjjjjjjjjjj");

            
           // Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Board("j"));
           // Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Board("jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj"));

        }
        [TestMethod]
        public void Should_Create_Instance_Of_Type()
        {
            Board board = new Board("Jivkoboard");

            Assert.IsInstanceOfType(board, typeof(IBoard));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_Exception_If_Name_Is_NUll()
        {
            Board board = new Board(null);
            Assert.IsNull(board);
        }
        [TestMethod]
        public void Should_Create_Lists()
        {
            Board board = new Board("Jivkoboard");


            Assert.AreEqual(0, board.WorkItems.Count);
            Assert.AreEqual(0, board.ActivityHistory.Count);

        }


    }
}
