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

namespace ManagementSystemTests.FactoryTests
{
    [TestClass]
    public class CreateBugParameters_Should
    {
        [TestMethod]
        public void CreateBugParameter_GIVEN_ValidInput_SHOULD_FillParametersCollection()
        {
            // Arrange
            var bugInput = Substitute.ForPartsOf<BugInput>();
            var subReader = Substitute.For<IReader>();
            var subInstanceHolder = Substitute.For<IInstanceHolder>();
            var subMenu = Substitute.For<IMenu>();
            string expectedDescription = new string('A', 15);
            string expectedname = new string('a', 12);

            subReader.ReadLine().Returns(expectedname, expectedDescription, "3", "A", "A", "A");
            subInstanceHolder.Reader.Returns(subReader);

            string priority = Priority.High.ToString();
            string saverity = Severity.Critical.ToString();
            string bugstatus = BugStatus.Active.ToString();
            subMenu.DrawMenu(Arg.Any<List<string>>()).Returns(priority, saverity, bugstatus);
            subInstanceHolder.Menu.Returns(subMenu);

            bugInput.InstanceHolder.Returns(subInstanceHolder);

            // Act
            List<string> parameters = bugInput.CreateBugParameters();

            // Assert
            Assert.AreEqual(parameters[0], expectedname);
            Assert.AreEqual(parameters[1], expectedDescription);
            Assert.IsNotNull(parameters);
            Assert.IsFalse(parameters.Count == 0);
        }

    }

}
