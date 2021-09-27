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
    public class CreateStory_should
    {
        [TestMethod]
        public void ReturInstanceOfTypeIstory()
        {

            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var story = factory.CreateStory(new string('a', 15), new string('a', 20),
                Priority.High, StorySize.Large, StoryStatus.Done);

            // Assert
            Assert.IsInstanceOfType(story, typeof(IStory));

        }

        [TestMethod]
        public void CreateStory_Given_WrongInputForTitleShort_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateStory(new string('A', 6), "Description", Priority.High, StorySize.Large, StoryStatus.Done));
            var action1 = new Action(() => factory.CreateStory(new string('A', 9), "Description", Priority.High, StorySize.Large, StoryStatus.Done));
            // Assert
            Assert.ThrowsException<Exception>(action);
            Assert.ThrowsException<Exception>(action1);

        }

        [TestMethod]
        public void CreateStory_Given_WrongInputForTitleLong_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateStory(new string('A', 70), "Description", Priority.High, StorySize.Large, StoryStatus.Done));
            var action1 = new Action(() => factory.CreateStory(new string('A', 51), "Description",Priority.High, StorySize.Large, StoryStatus.Done));
            // Assert

            Assert.ThrowsException<Exception>(action);
            Assert.ThrowsException<Exception>(action1);

        }

        [TestMethod]
        public void CreateStory_Given_WrongInputForTitleNull_Should_ReturnException()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var action = new Action(() => factory.CreateStory(null, "Description", Priority.High, StorySize.Large, StoryStatus.Done));

            // Assert
            Assert.ThrowsException<Exception>(action);

        }

        [TestMethod]
        public void CreateStory_Given_ValidInput_Should_Return_Valid_Title()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var result = factory.CreateStory(new string('A', 50), "Description", Priority.High, StorySize.Large, StoryStatus.Done);
            var result1 = factory.CreateStory(new string('A', 10), "Description", Priority.High, StorySize.Large, StoryStatus.Done);
            // Assert

            Assert.AreEqual(result.Title, new string('A', 50));
            Assert.AreEqual(result1.Title, new string('A', 10));

        }

    }
}

  


