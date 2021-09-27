using ManagementSystem.Models;
using ManagementSystem.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystemTests.ModelTests
{
    [TestClass]
    public class MemberTest
    {
        [TestMethod]
        public void Should_Assign_Name_Correctly()
        {
            Member member = new Member("Jivko JJ");

            Assert.AreEqual("Jivko JJ", member.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_Exception_If_Name_Lenght_Is_Invalid()
        {
            new Member("J");
            new Member("jjjjjjjjjjjjjjjjjjjjjjjjjj");


            // Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Board("j"));
            // Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Board("jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj"));

        }
        [TestMethod]
        public void Should_Create_Instance_Of_Type()
        {
            Member board = new Member("Jivkomember");

            Assert.IsInstanceOfType(board, typeof(IMember));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_Exception_If_Name_Is_NUll()
        {
            Member board = new Member(null);
            Assert.IsNull(board);
        }

    }
}
