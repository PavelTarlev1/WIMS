using ManagementSystem.Models;
using ManagementSystem.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystemTests.ModelTests.MemberTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void Should_Assign_Name_Correctly()
        {
            Member member = new Member("JivkoMem");

            Assert.AreEqual("JivkoMem", member.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_Exception_If_Name_Lenght_Is_Invalid()
        {
            new Member("j");
            new Member("LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL");

        }
        [TestMethod]
        public void Should_Create_Instance_Of_Type()
        {
            Member member = new Member("JivkoMem");

            Assert.IsInstanceOfType(member, typeof(IMember));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_Exception_If_Name_Is_NUll()
        {
            Member member = new Member(null);


        }
        [TestMethod]
        public void Should_Create_Lists()
        {
            Member member = new Member("JivkoMem");


            Assert.AreEqual(0, member.WorkItems.Count);
            Assert.AreEqual(0, member.ActivityHistory.Count);

        }
    }
}
