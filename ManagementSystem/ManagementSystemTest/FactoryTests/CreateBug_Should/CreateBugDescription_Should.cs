using ManagementSystem.Core.Factories;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using ManagementSystem.Models.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ManagmentSystem.Test
{

    [TestClass]
    public class CreateBugDescription_Should
    {
        List<string> stepsToProduce = new List<string>() { "a", "b", "c" };

        [TestMethod]
        public void CreateBug_Given_WrongInputDescriptionShort_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateBug(new string('A', 15), new string('A', 5), stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active));
            var action1 = new Action(() => factory.CreateBug(new string('A', 15), new string('A', 9), stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active));

            // Assert
            Assert.ThrowsException<Exception>(action);
            Assert.ThrowsException<Exception>(action1);

        }

        [TestMethod]
        public void CreateBug_Given_WrongInputDescriptionLong_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateBug(new string('A', 15), new string('A', 600), stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active));
            var action1 = new Action(() => factory.CreateBug(new string('A', 15), new string('A', 501), stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active));

            // Assert
            Assert.ThrowsException<Exception>(action);
            Assert.ThrowsException<Exception>(action1);

        }




        [TestMethod]
        public void BugTest1()
        {
            var bug = new Bug(new string('A', 15), new string('A', 500), stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active);
            Assert.AreEqual(bug.Id, 1);
        }



        [TestMethod]
        public void BugTest2()
        {
            var bug = new Bug(new string('A', 15), new string('A', 500), stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active);
            Assert.AreEqual(bug.Id, 1);
        }

















        [TestMethod]
        public void CreateBug_Given_ValidInputDescription_Should_ReturnValid_Description()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var result = factory.CreateBug(new string('A', 15), new string('A', 500), stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active);
            var result1 = factory.CreateBug(new string('A', 15), new string('A', 10), stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active);


            // Assert
            Assert.AreEqual(result.Description, new string('A', 500));
            Assert.AreEqual(result1.Description, new string('A', 10));

        }


        [TestMethod]
        public void CreateBug_Given_WrongInputDescriptionNull_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateBug(new string('A', 15), null, stepsToProduce, Priority.High, Severity.Critical, BugStatus.Active));

            // Assert
            Assert.ThrowsException<ArgumentNullException>(action);

        }
    }
}

