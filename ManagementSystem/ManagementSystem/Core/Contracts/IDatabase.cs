using ManagementSystem.Models;
using ManagementSystem.Models.Contracts;
using System.Collections.Generic;

namespace ManagementSystem.Core.Contracts
{
    public interface IDatabase
    {
        List<IBoard> BoardList { get; }
        List<IBug> BugList { get; }
        List<ActivityHistory> CommandHistory { get; }
        List<IFeedback> FeedbacksList { get; }
        List<IMember> MemberList { get; }
        List<IStory> StoryList { get; }
        List<ITeam> TeamList { get; }
        Dictionary<string, string> UsernamePasswordDatabase { get; }
        List<IWorkItem> WorkItems { get; }

        void AddToBoardList(IBoard board);
        void AddToBugList(IBug bug);
        void AddToFeedbackList(IFeedback feedback);
        void AddToMemberList(IMember member);
        void AddToStoryList(IStory story);
        void AddToTeamList(ITeam team);
        void AddToUsernamePasswordDatabase(string username, string password);
        void AddToWorkItemList(IWorkItem item);
        ActivityHistory CreateActivityHistory(string message);
        Dictionary<string, string> FakeDic(Dictionary<string, string> dic);
        void SaveAllListsToFiles();
        void SeedAllListsFromFiles();
        void SeedData();
    }
}