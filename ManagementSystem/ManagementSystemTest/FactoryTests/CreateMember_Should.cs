using ManagementSystem.Core.Providers;
using ManagementSystem.Models;
using ManagementSystem.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ManagmentSystem.Test
{

    [TestClass]
    public class CreateMember_Should
    {
        [TestMethod]
        public void ReturInstanceOfTypeIMember()
        {
            // Arrange
            var factory = InstanceHolder.GetInstance().Factory;

            // Act
            var member = factory.CreateMember("Pesho");

            // Assert
            Assert.IsInstanceOfType(member, typeof(IMember));

        }

        [TestMethod]
        public void CtorSetValidName()
        {
            // Arrange
            string testName = "Pesho";

            // Act
            var member = new Member(testName);

            // Assert
            Assert.AreEqual(testName, member.Name);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Board name should be between 5 and 10 symbols")]
        public void CtorShouldThrowExNull()
        {
            // Arrange
            string testName = null;

            // Act
            var member = new Member(testName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Board name should be between 5 and 10 symbols")]
        public void CtorShouldThrowExOutOfRangeMore()
        {
            // Arrange
            string testName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            // Act
            var member = new Member(testName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Board name should be between 5 and 10 symbols")]
        public void CtorShouldThrowExOutOfRangeLess()
        {
            // Arrange
            string testName = "a";

            // Act
            var member = new Member(testName);
        }
    }
}
