using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using ManagementSystem.Models.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystemTests.ModelTests
{
    [TestClass]
    public class ConstructorShould
    {

        [TestMethod]
        public void Assign_Values_Correctly()
        {
            Bug bug = new Bug
                ("jivkoBugbug", "Kak e ludaci", new List<string> { "step1" }, Priority.High, Severity.Critical, BugStatus.Active);
            Assert.AreEqual("jivkoBugbug", bug.Title);
            Assert.AreEqual("Kak e ludaci", bug.Description);
            Assert.AreEqual(1,bug.StepsToReproduce.Count);
            Assert.AreEqual("High",bug.Priority.ToString());
            Assert.AreEqual("Critical",bug.Severity.ToString());
            Assert.AreEqual("Active",bug.Status.ToString());
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_Exception_If_Name_Lenght_Is_Invalid()
        {
            new Bug
               ("jivk", "Kak e ludaci", new List<string> { "step1" }, Priority.High, Severity.Critical, BugStatus.Active);
           

        }
        [TestMethod]
        public void Should_Create_Instance_Of_Type()
        {
            Bug bug = new Bug
               ("jivkoBugbug", "Kak e ludaci", new List<string> { "step1" }, Priority.High, Severity.Critical, BugStatus.Active);

            Assert.IsInstanceOfType(bug, typeof(IBug));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_Exception_If_Name_Is_NUll()
        {
             new Bug
               (null, "Kak e ludaci", new List<string> { "step1" }, Priority.High, Severity.Critical, BugStatus.Active);


        }
        [TestMethod]
        public void Should_Create_Lists()
        {
            Bug bug = new Bug
                ("jivkoBugbug", "Kak e ludaci", new List<string> { "step1" }, Priority.High, Severity.Critical, BugStatus.Active);
            Assert.AreEqual(0, bug.Comments.Count);
            Assert.AreEqual(0, bug.ActivityHistory.Count);

        }


    }
}
