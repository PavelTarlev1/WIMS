using ManagementSystem.Models;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystemTests.ModelTests.StoryTests
{
    [TestClass]
   public class ConstructoShould
    {
        [TestMethod]
        public void Assign_Values_Correctly()
        {
            Story story = new Story("JivkoStory", "jjjjjjjjjjjjjjjjjj", Priority.High, StorySize.Large, StoryStatus.Done);
               
            Assert.AreEqual("JivkoStory", story.Title);
            Assert.AreEqual("jjjjjjjjjjjjjjjjjj", story.Description);
            Assert.AreEqual("High", story.Priority.ToString());
            Assert.AreEqual("Large", story.Size.ToString());
            Assert.AreEqual("Done", story.Status.ToString());
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_Exception_If_Name_Lenght_Is_Invalid()
        {
            new Story("Jivko", "jjjjjjj", Priority.High, StorySize.Large, StoryStatus.Done);

         


        }
        [TestMethod]
        public void Should_Create_Instance_Of_Type()
        {
            Story story = new Story("JivkoStory", "jjjjjjjjjjjjjjjjjjj", Priority.High, StorySize.Large, StoryStatus.Done);


            Assert.IsInstanceOfType(story, typeof(IStory));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_Exception_If_Name_Is_NUll()
        {
             new Story(null, "jjjjjjj", Priority.High, StorySize.Large, StoryStatus.Done);



        }
        [TestMethod]
        public void Should_Create_Lists()
        {
            Story story = new Story("JivkoStory", "jjjjjjjJJJJJJJJ", Priority.High, StorySize.Large, StoryStatus.Done);

            Assert.AreEqual(0, story.Comments.Count);
            Assert.AreEqual(0, story.ActivityHistory.Count);

        }
    }
}
