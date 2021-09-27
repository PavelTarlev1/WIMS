using ManagementSystem.Core.Contracts;
using ManagementSystem.Models;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using ManagementSystem.Models.Units;
using System;
using System.Collections.Generic;

namespace ManagementSystem.Core.Factories
{
    /// <summary>
    /// Factory for creating Members, Boards, Bug's, Feedback, Story, Teams.
    /// </summary>
    public class Factory : IFactory
    {

        public Factory()
        {
            
        }
        /// <summary>
        /// Creates a new member.
        /// </summary>
        /// <param name="name"></param>
        /// <returns><Return new Member>
        public IMember CreateMember(string name)
        {
            IMember member = new Member(name);
            return member;
        }


        /// <summary>
        /// Creates a new board.
        /// </summary>
        /// <param name="name"></param>
        /// <returns><Returns new Board>
        public IBoard CreateBoard(string name)
        {
            // factory_activity_history.add (::::);
            IBoard board = new Board(name);
            return board;

        }

        /// <summary>
        /// Creates a new bug.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="stepsToProduce"></param>
        /// <param name="priority"></param>
        /// <param name="severity"></param>
        /// <param name="assignees"></param>
        /// <param name="status"></param>
        /// <returns>Returns an instance of Bug</returns>
        public IBug CreateBug(string title, string description, List<string> stepsToProduce,
            Priority priority, Severity severity, BugStatus status)
        {
            Bug bug = new Bug(title, description, stepsToProduce, priority, severity, status);
            return bug;
        }


        /// <summary>
        /// Creates a new feedback.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="rating"></param>
        /// <param name="status"></param>
        /// <returns>Returns an instance of Feedback</returns>
        public IFeedback CreateFeedback(string title, string description, int rating, FeedbackStatus status)
        {
            IFeedback feedback = new Feedback(title, description, rating, status);
            return feedback;
        }


        /// <summary>
        /// Creates a new story.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="priority"></param>
        /// <param name="size"></param>
        /// <param name="status"></param>
        /// <param name="assignee"></param>
        /// <returns><Returns the Story>
        public IStory CreateStory(string title, string description, Priority priority, StorySize size, StoryStatus status)
        {
            IStory story = new Story(title, description, priority, size, status);
            return story;
        }


        /// <summary>
        /// Creates a new team.
        /// </summary>
        /// <param name="name"></param>
        /// <returns><Return the new Team>
        public ITeam CreateTeam(string name)
        {
            ITeam team = new Team(name);
            return team;
        }

    }
}
