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
    public class CreateFeedbackDescription_Should
    {


        [TestMethod]
        public void CreateFeedback_Given_WrongInputForDescriptionShort_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateFeedback(new string('A', 10), "a", 6, FeedbackStatus.Done));

            // Assert

            Assert.ThrowsException<NullReferenceException>(action);

        }

        [TestMethod]
        public void CreateFeedback_Given_WrongInputForTitleLong_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateFeedback(new string('A', 15), "Description", 6, FeedbackStatus.Done));

            // Assert

            Assert.ThrowsException<Exception>(action);

        }

        [TestMethod]
        public void CreateFeedback_Given_WrongInputForTitleNull_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateFeedback(null, "Description", 6, FeedbackStatus.Done));

            // Assert
            Assert.ThrowsException<Exception>(action);

        }

        [TestMethod]
        public void CreateFeedback_Given_WrongInputForTitleCornerLong_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var result = factory.CreateFeedback(new string('A', 50), "Description", 6, FeedbackStatus.Done);

            // Assert

            Assert.AreEqual(result.Title, new string('A', 50));

        }

        [TestMethod]
        public void CreateFeedback_Given_WrongInputForTitleCornerShort_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var result = factory.CreateFeedback(new string('A', 10), "Description", 6, FeedbackStatus.Done);

            // Assert

            Assert.AreEqual(result.Title, new string('A', 10));

        }




    }
}
