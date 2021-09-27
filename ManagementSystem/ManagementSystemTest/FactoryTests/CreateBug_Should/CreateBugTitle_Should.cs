using ManagementSystem.Core;
using ManagementSystem.Core.Factories;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ManagmentSystem.Test
{
    [TestClass]
    public class CreateBugTitle_Should
    {
        List<string> stepsToProduce = new List<string>() { "a", "b", "c" };
        [TestMethod]
        public void ReturInstanceOfTypeIBug()
        {
           
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var bug = factory.CreateBug("Peshoaaaaaaaa", "description", stepsToProduce,
                Priority.High, Severity.Critical, BugStatus.Active);

            // Assert
            Assert.IsInstanceOfType(bug, typeof(IBug));

        }

        [TestMethod]
        public void CreateBug_Given_WrongInputForTitleShort_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateBug(new string('A', 6), "Description", stepsToProduce,Priority.High, Severity.Critical, BugStatus.Active));
            var action1 = new Action(() => factory.CreateBug(new string('A', 9), "Description", stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active));

            // Assert
            Assert.ThrowsException<Exception>(action);
            Assert.ThrowsException<Exception>(action1);

        }

        [TestMethod]
        public void CreateBug_Given_WrongInputForTitleLong_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateBug(new string('A', 70), "Description", stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active));
            var action1 = new Action(() => factory.CreateBug(new string('A', 51), "Description", stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active));

            // Assert
            Assert.ThrowsException<Exception>(action);
            Assert.ThrowsException<Exception>(action1);

        }

        [TestMethod]
        public void CreateBug_Given_WrongInputForTitleNull_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateBug(null, "Description", stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active));

            // Assert
            Assert.ThrowsException<Exception>(action);

        }

        [TestMethod]
        public void CreateBug_Given_ValidInput_Should_Return_Valid_Title()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var result = factory.CreateBug(new string('A', 50), "Description", stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active);
            var result1 = factory.CreateBug(new string('A', 10), "Description", stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active);

            // Assert
            Assert.AreEqual(result.Title, new string('A', 50));
            Assert.AreEqual(result1.Title, new string('A', 10));

        }

    }
}
   

