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
    public class CreateStoryDescription_Should
    {

        [TestMethod]
        public void CreateStory_Given_WrongInputDescriptionShort_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateStory(new string('A', 15), new string('A', 5), Priority.High, StorySize.Large, StoryStatus.Done));
            var action1 = new Action(() => factory.CreateStory(new string('A', 15), new string('A', 9), Priority.High, StorySize.Large, StoryStatus.Done));
            Assert.ThrowsException<Exception>(action);
            Assert.ThrowsException<Exception>(action1);

        }

        [TestMethod]
        public void CreateStory_Given_WrongInputDescriptionLong_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateStory(new string('A', 15), new string('A', 600), Priority.High, StorySize.Large, StoryStatus.Done));
            var action1 = new Action(() => factory.CreateStory(new string('A', 15), new string('A', 501), Priority.High, StorySize.Large, StoryStatus.Done));
            // Assert

            Assert.ThrowsException<Exception>(action);
            Assert.ThrowsException<Exception>(action1);

        }

        [TestMethod]
        public void CreateStory_Given_ValidInputDescription_Should_ReturnValid_Description()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var result = factory.CreateStory(new string('A', 15), new string('A', 500), Priority.High, StorySize.Large, StoryStatus.Done);
            var result1 = factory.CreateStory(new string('A', 15), new string('A', 10), Priority.High, StorySize.Large, StoryStatus.Done);


            // Assert
            Assert.AreEqual(result.Description, new string('A', 500));
            Assert.AreEqual(result1.Description, new string('A', 10));

        }


        [TestMethod]
        public void CreateStoryk_Given_WrongInputDescriptionNull_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateStory(new string('A', 15), null, Priority.High, StorySize.Large, StoryStatus.Done));

            // Assert
            Assert.ThrowsException<ArgumentNullException>(action);

        }
    }
}
