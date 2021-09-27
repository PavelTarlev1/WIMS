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
    public class CreateFeedbackTitle_Should
    {
        /// <summary>
        /// Check if create feedback return's IFeedback.
        /// </summary>
        [TestMethod]
        public void CreateFeedback_Given_CorrectInputs_Should_ReturnInstaceOfIFeedback()
        {
            // Arrange
             var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var feedback = factory.CreateFeedback(new string('A',15), "Description", 6, FeedbackStatus.Done);

            // Assert
            Assert.IsInstanceOfType(feedback, typeof(IFeedback));

        }

        [TestMethod]
        public void CreateFeedback_Given_WrongInputForTitleShort_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateFeedback(new string('A', 6), "Description", 6, FeedbackStatus.Done));
            var action1 = new Action(() => factory.CreateFeedback(new string('A',9), "Description", 6, FeedbackStatus.Done));

            // Assert
            Assert.ThrowsException<Exception>(action);
            Assert.ThrowsException<Exception>(action1);

        }

        [TestMethod]
        public void CreateFeedback_Given_WrongInputForTitleLong_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateFeedback(new string('A', 70), "Description", 6, FeedbackStatus.Done));
            var action1 = new Action(() => factory.CreateFeedback(new string('A', 51), "Description", 6, FeedbackStatus.Done));

            // Assert
            Assert.ThrowsException<Exception>(action);
            Assert.ThrowsException<Exception>(action1);

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
        public void CreateFeedback_Given_ValidInput_Should_Return_Valid_Title()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var result = factory.CreateFeedback(new string('A',50), "Description", 6, FeedbackStatus.Done);
            var result1 = factory.CreateFeedback(new string('A',10), "Description", 6, FeedbackStatus.Done);

            // Assert
            Assert.AreEqual(result.Title, new string('A',50));
            Assert.AreEqual(result1.Title, new string('A', 10));

        }

    }
}
