using ManagementSystem.Core;
using ManagementSystem.Core.Factories;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ManagmentSystem.Test
{

    [TestClass]
    public class CreateTeamTitle_Should
    {
        [TestMethod]
        public void ReturInstanceOfTypeITeam()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var team = factory.CreateTeam("Pesho");

            // Assert
            Assert.IsInstanceOfType(team, typeof(ITeam));

        }

        [TestMethod]
        public void CreateTeam_Given_WrongInputForTitleShort_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateTeam(new string('A', 4)));
            var action1 = new Action(() => factory.CreateTeam(new string('A', 1)));

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.ThrowsException<ArgumentOutOfRangeException>(action1);

        }

        [TestMethod]
        public void CreateTeam_Given_WrongInputForTitleLong_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateTeam(new string('A', 30)));
            var action1 = new Action(() => factory.CreateTeam(new string('A', 21)));

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            Assert.ThrowsException<ArgumentOutOfRangeException>(action1);

        }

        [TestMethod]
        public void CreateTeam_Given_WrongInputForTitleNull_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateTeam(null));

            // Assert
            Assert.ThrowsException<ArgumentNullException>(action);

        }

        [TestMethod]
        public void CreateTeam_Given_ValidInput_Should_Return_Valid_Title()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var result = factory.CreateTeam(new string('A', 5));
            var result1 = factory.CreateTeam(new string('A', 20));

            // Assert
            Assert.AreEqual(result.Name, new string('A', 5));
            Assert.AreEqual(result1.Name, new string('A', 20));

        }

    }
}