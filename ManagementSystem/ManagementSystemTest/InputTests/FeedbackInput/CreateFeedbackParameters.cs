using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Core.UserInput;
using ManagementSystem.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementSystemTests.FeedbackInputa
{
    [TestClass]
    public class CreateFeedbackParameters
    {
        [TestMethod]
        public void CreateFeedbackParameter_GIVEN_ValidInput_SHOULD_FillParametersCollection()
        {
            // Arrange
            var feedbackInput = Substitute.ForPartsOf<FeedbackInput>();
            var subReader = Substitute.For<IReader>();
            var subInstanceHolder = Substitute.For<IInstanceHolder>();
            var subMenu = Substitute.For<IMenu>();

            string expectedTitle = "title";
            string expectedDescription = "description";
            string expectedRating = "5";
            string feedbackstatus = FeedbackStatus.Done.ToString();

            subInstanceHolder.Menu.Returns(subMenu);
            subReader.ReadLine().Returns(expectedTitle, expectedDescription, expectedRating, feedbackstatus);
            subInstanceHolder.Reader.Returns(subReader);
            subMenu.DrawMenu(Arg.Any<List<string>>()).Returns(feedbackstatus);
            feedbackInput.InstanceHolder.Returns(subInstanceHolder);

            // Act
            List<string> parameters = feedbackInput.CreateFeedbackParameters();

            // Assert
            Assert.IsNotNull(parameters);
            Assert.AreEqual(parameters[0], expectedTitle);
            Assert.AreEqual(parameters[1], expectedDescription);
            Assert.AreEqual(parameters[2], expectedRating);
            Assert.IsFalse(parameters.Count == 0);

        }
      
    }
}
