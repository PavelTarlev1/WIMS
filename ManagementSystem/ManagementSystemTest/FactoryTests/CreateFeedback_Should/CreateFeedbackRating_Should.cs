using ManagementSystem.Core.Factories;
using ManagementSystem.Core.Providers;
using ManagementSystem.Models;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using ManagementSystem.Models.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ManagmentSystem.Test
{

    [TestClass]
    public class CreateFeedbackRating_Should
    {

        [TestMethod]
        public void CreateFeedback_Given_ValidInputRating_Should_ReturnValidRating()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var result = factory.CreateFeedback(new string('A', 15), new string('A', 50), 5, FeedbackStatus.Done);

            // Assert
            Assert.AreEqual(result.Rating, 5);

        }

        [TestMethod]
        public void CreateFeedback_Given_WrongInputForRatingNegative_Should_ReturnException()
        {
            // Arrange,Act,Assert
            Assert.ThrowsException<Exception>(() => new Feedback(new string('A', 15), new string('A', 50), -5, FeedbackStatus.Done));

            
        }

    }
}
