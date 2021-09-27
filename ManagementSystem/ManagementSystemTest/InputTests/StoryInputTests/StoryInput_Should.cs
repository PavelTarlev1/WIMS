using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Core.UserInput;
using ManagementSystem.Models;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementSystemTests.StoryInputTests
{
    [TestClass]
    public class StoryInput_Should
    {
        [TestMethod]
        public void CreateStoryParameters_Parameters_TitleIsShorter()
        {
            //public IStory CreateStory(string title, string description, Priority priority, StorySize size, StoryStatus status)

            // Arrange
            var storyInput = Substitute.ForPartsOf<StoryInput>();
            var subReader = Substitute.For<IReader>();
            var subInstanceHolder = Substitute.For<IInstanceHolder>();
            var subMenu = Substitute.For<IMenu>();

            string expectedTitle = "greda";
            string expectedDescription = "description";
            string priority = Priority.High.ToString();
            string size = StorySize.Large.ToString();
            string storyStatus = StoryStatus.Done.ToString();

            subInstanceHolder.Menu.Returns(subMenu);
            subReader.ReadLine().Returns(expectedTitle, expectedDescription, priority, size, storyStatus);
            subInstanceHolder.Reader.Returns(subReader);
            subMenu.DrawMenu(Arg.Any<List<string>>()).Returns(priority,size,storyStatus);


            storyInput.InstanceHolder.Returns(subInstanceHolder);

            // Act
            List<string> parameters = storyInput.CreateStoryParameters();
            try
            {
                storyInput.CreateStoryParameters();
            }
            catch (Exception e)
            {

            }
            // Assert
            Assert.AreEqual(parameters[0], expectedTitle);
            //Assert.AreEqual(isTrue, expected);
            Assert.AreEqual(parameters[1], expectedDescription);
            Assert.AreEqual(parameters[2], priority);
            Assert.AreEqual(parameters[3], size);
            Assert.AreEqual(parameters[4], storyStatus);
            Assert.IsFalse(parameters.Count == 0);
        }
    }
}
