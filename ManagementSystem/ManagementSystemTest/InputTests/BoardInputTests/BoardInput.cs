using ManagementSystem.Core.UserInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using ManagementSystem.Core.Providers;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Models.Contracts;
using System.Linq;
using ManagementSystem.Models.Units;
using ManagementSystem.Core;
using NSubstitute.ExceptionExtensions;

namespace ManagementSystemTests.InputsTests
{
    [TestClass]
    public class CreateBoardParameters_Should
    {
        [TestMethod]
        public void CreateBoardParameters_GIVEN_ValidInputNotInBoardList_SHOULD_FillParametersCollection()
        {

            // Arrange
            var boardInput = Substitute.ForPartsOf<BoardInput>();
                
            var subInstanceHolder = Substitute.For<IInstanceHolder>();

            var subReader = Substitute.For<IReader>();
            string expectedItem = "something";
            subReader.ReadLine().Returns(expectedItem);
            subInstanceHolder.Reader.Returns(subReader);

            var subWriter = Substitute.For<IWriter>();
            subInstanceHolder.Writer.Returns(subWriter);

            var subDatabase = Substitute.For<IDatabase>();
            subDatabase.BoardList.Returns(new List<IBoard>());
            subInstanceHolder.Database.Returns(subDatabase);

            boardInput.InstanceHolder.Returns(subInstanceHolder);

            // Act
            List<string> parameters = boardInput.CreateBoardParameters();
                
            // Assert
            Assert.IsNotNull(parameters);
            Assert.IsFalse(parameters.Count == 0);
            Assert.IsTrue(parameters.Any(param => param.Equals(expectedItem)));
        }

        [TestMethod]
        public void CreateBoardParameters_GIVEN_ValidInputAndInBoardList_SHOULD_CallWritterWithAlreadyExistsMessage()
        {
            // Arrange
            var boardInput = Substitute.ForPartsOf<BoardInput>();

            var subInstanceHolder = Substitute.For<IInstanceHolder>();

            var subReader = Substitute.For<IReader>();
            string expectedItem = "something";
            subReader.ReadLine().Returns(expectedItem);
            subInstanceHolder.Reader.Returns(subReader);

            var subWriter = Substitute.For<IWriter>();
            subInstanceHolder.Writer.Returns(subWriter);
            int actualCalls = 0;
            int expectedCalls = 1;
            subWriter
                .When(sub =>
                    sub.WriteLine(PrintMessages.boardAlreadyExists)
                )
                .Do(call => {
                    actualCalls++;
                    throw new Exception();
                }
                );

            var subDatabase = Substitute.For<IDatabase>();
            subDatabase.BoardList.Returns(new List<IBoard>() { new Board(expectedItem) });
            subInstanceHolder.Database.Returns(subDatabase);

            boardInput.Parameters.Returns(new List<string>() { expectedItem });

            boardInput.InstanceHolder.Returns(subInstanceHolder);

            // Act
            try
            {
                boardInput.CreateBoardParameters();
            }
            catch (Exception e)
            {
               
            }

            // Assert
            Assert.AreEqual(expectedCalls, actualCalls);
        }

        [TestMethod]
        public void CreateBoardParameter_Given_InvalidInputInName_SHOULD_CallExceptionExceptionValidationMassage()
        {
            // Arrange
            var boardInput = Substitute.ForPartsOf<BoardInput>();

            var subInstanceHolder = Substitute.For<IInstanceHolder>();

            var subReader = Substitute.For<IReader>();
            string expectedItem = new string('a', 4);
            subReader.ReadLine().Returns(expectedItem);
            subInstanceHolder.Reader.Returns(subReader);

            var subWriter = Substitute.For<IWriter>();
            subInstanceHolder.Writer.Returns(subWriter);

            var subDatabase = Substitute.For<IDatabase>();
            subDatabase.BoardList.Returns(new List<IBoard>());
            subInstanceHolder.Database.Returns(subDatabase);

            boardInput.InstanceHolder.Returns(subInstanceHolder);
            int actualCalls = 0;
            int expectedCalls = 1;
            // Act
            try
            {
                boardInput.CreateBoardParameters();
            }
            catch (Exception e)
            {
                actualCalls++;
            }

            // Assert
            Assert.AreEqual(actualCalls, expectedCalls);

        }

        [TestMethod]
        public void CreateBoardParameter_Given_InvalidInputInName_Should_CallExceptionExceptionValidationMassage()
        {
            // Arrange
            var boardInput = Substitute.ForPartsOf<BoardInput>();

            var subInstanceHolder = Substitute.For<IInstanceHolder>();

            var subReader = Substitute.For<IReader>();
            string expectedItem = new string('a', 11);
            subReader.ReadLine().Returns(expectedItem);
            subInstanceHolder.Reader.Returns(subReader);

            var subWriter = Substitute.For<IWriter>();
            subInstanceHolder.Writer.Returns(subWriter);

            var subDatabase = Substitute.For<IDatabase>();
            subDatabase.BoardList.Returns(new List<IBoard>());
            subInstanceHolder.Database.Returns(subDatabase);

            boardInput.InstanceHolder.Returns(subInstanceHolder);
            int actualCalls = 0;
            int expectedCalls = 1;

            // Act
            try
            {
                boardInput.CreateBoardParameters();
            }
            catch (Exception e)
            {
                actualCalls++;
            }

            // Assert
            Assert.AreEqual(actualCalls, expectedCalls);
        }

        [TestMethod]
        public void CreateBoardParameter_Given_InvalidInputInNameNull_Should_CallExceptionExceptionValidationMassage()
        {
            // Arrange
            var boardInput = Substitute.ForPartsOf<BoardInput>();

            var subInstanceHolder = Substitute.For<IInstanceHolder>();

            var subReader = Substitute.For<IReader>();
            string expectedItem = null;
            subReader.ReadLine().Returns(expectedItem);
            subInstanceHolder.Reader.Returns(subReader);

            var subWriter = Substitute.For<IWriter>();
            subInstanceHolder.Writer.Returns(subWriter);

            var subDatabase = Substitute.For<IDatabase>();
            subDatabase.BoardList.Returns(new List<IBoard>());
            subInstanceHolder.Database.Returns(subDatabase);

            boardInput.InstanceHolder.Returns(subInstanceHolder);
            int actualCalls = 0;
            int expectedCalls = 1;

            // Act
            try
            {
                boardInput.CreateBoardParameters();
            }
            catch (Exception e)
            {
                actualCalls++;
            }

            // Assert
            Assert.AreEqual(actualCalls, expectedCalls);
        }

        [TestMethod]
        public void CreateBoardParameters_GIVEN_CornerCasesShort_SHOULD_FillParametersCollection()
        {
            // Arrange
            var boardInput = Substitute.ForPartsOf<BoardInput>();

            var subInstanceHolder = Substitute.For<IInstanceHolder>();

            var subReader = Substitute.For<IReader>();
            string expectedItem = new string('A', 5);
            subReader. ReadLine().Returns(expectedItem);
            subInstanceHolder.Reader.Returns(subReader);

            var subWriter = Substitute.For<IWriter>();
            subInstanceHolder.Writer.Returns(subWriter);

            var subDatabase = Substitute.For<IDatabase>();
            subDatabase.BoardList.Returns(new List<IBoard>());
            subInstanceHolder.Database.Returns(subDatabase);

            boardInput.InstanceHolder.Returns(subInstanceHolder);

            // Act
            List<string> parameters = boardInput.CreateBoardParameters();

            // Assert
            Assert.IsNotNull(parameters);
            Assert.IsFalse(parameters.Count == 0);
            Assert.IsTrue(parameters.Any(param => param.Equals(expectedItem)));
        }

        [TestMethod]
        public void CreateBoardParameters_GIVEN_CornerCasesLong_SHOULD_FillParametersCollection()
        {
            // Arrange
            var boardInput = Substitute.ForPartsOf<BoardInput>();

            var subInstanceHolder = Substitute.For<IInstanceHolder>();

            var subReader = Substitute.For<IReader>();
            string expectedItem = new string('A', 10);
            subReader.ReadLine().Returns(expectedItem);
            subInstanceHolder.Reader.Returns(subReader);

            var subWriter = Substitute.For<IWriter>();
            subInstanceHolder.Writer.Returns(subWriter);

            var subDatabase = Substitute.For<IDatabase>();
            subDatabase.BoardList.Returns(new List<IBoard>());
            subInstanceHolder.Database.Returns(subDatabase);

            boardInput.InstanceHolder.Returns(subInstanceHolder);

            // Act
            List<string> parameters = boardInput.CreateBoardParameters();

            // Assert
            Assert.IsNotNull(parameters);
            Assert.IsFalse(parameters.Count == 0);
            Assert.IsTrue(parameters.Any(param => param.Equals(expectedItem)));
        }

    }
}
