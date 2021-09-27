using ManagementSystem.Commands.Contracts;
using ManagementSystem.Core.Contracts;
using ManagementSystem.Core.Providers;
using ManagementSystem.Core.UserInput;
using ManagementSystem.Models;
using ManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;

namespace ManagementSystem.Commands
{
    public abstract class Command : ICommand
    {
        public Command(IEngine engine, InstanceHolder instanceHolder)
        {
            Console.Clear();
            this.InstanceHolder = instanceHolder;
            this.Engine = engine;
            this.BoardInput = new BoardInput();
            this.BugInput = new BugInput();
            this.FeedbackInput = new FeedbackInput();
            this.TeamInput = new TeamInput();
            this.MemberInput = new MemberInput();
            this.WorkItemInput = new WorkItemInput();
            this.StoryInput = new StoryInput();
            this.ListInput = new ListInput();


        }
        public IInstanceHolder InstanceHolder { get; set; }
        public IEngine Engine { get; set; }
        public BoardInput BoardInput { get; private set; }
        public BugInput BugInput { get; private set; }
        public FeedbackInput FeedbackInput { get; private set; }
        public TeamInput TeamInput { get; private set; }
        public MemberInput MemberInput { get; private set; }
        public WorkItemInput WorkItemInput { get; private set; }
        public StoryInput StoryInput { get; private set; }
        public ListInput ListInput { get; private set; }

        public abstract string Execute();

    }
}
