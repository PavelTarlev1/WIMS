using ManagementSystem.Core;
using ManagementSystem.Core.Factories;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ManagmentSystem.Test
{

    [TestClass]
    public class CreateBoard_Should
    {
        [TestMethod]
        public void ReturInstanceOfTypeIBoard()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var board = factory.CreateBoard("Pesho");
            // Assert
            Assert.IsInstanceOfType(board, typeof(IBoard));

        }

        [TestMethod]
        public void CreateBoard_Given_WrongInputForTitleShort_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateBoard(new string('A', 4)));
            var action1 = new Action(() => factory.CreateBoard(new string('A', 1)));

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.ThrowsException<ArgumentOutOfRangeException>(action1);

        }

        [TestMethod]
        public void CreateBoard_Given_WrongInputForTitleLong_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateBoard(new string('A', 15)));
            var action1 = new Action(() => factory.CreateBoard(new string('A', 11)));

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.ThrowsException<ArgumentOutOfRangeException>(action1);

        }

        [TestMethod]
        public void CreateBoard_Given_WrongInputForTitleNull_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateBoard(null));

            // Assert
            Assert.ThrowsException<ArgumentNullException>(action);

        }

        [TestMethod]
        public void CreateBoard_Given_ValidInput_Should_Return_Valid_Title()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var result = factory.CreateBoard(new string('A', 5));
            var result1 = factory.CreateBoard(new string('A', 10));

            // Assert
            Assert.AreEqual(result.Name, new string('A', 5));
            Assert.AreEqual(result1.Name, new string('A', 10));

        }

    }
}



    
