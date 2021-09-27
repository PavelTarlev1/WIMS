using ManagementSystem.Models;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using ManagementSystem.Models.Units;
using System.Collections.Generic;

namespace ManagementSystem.Core.Factories
{
    public interface IFactory
    {
        IBoard CreateBoard(string name);
        IBug CreateBug(string title, string description, List<string> stepsToProduce, Priority priority, Severity severity, BugStatus status);
        IFeedback CreateFeedback(string title, string description, int rating, FeedbackStatus status);
        IMember CreateMember(string name);
        IStory CreateStory(string title, string description, Priority priority, StorySize size, StoryStatus status);
        ITeam CreateTeam(string name);

    }
}