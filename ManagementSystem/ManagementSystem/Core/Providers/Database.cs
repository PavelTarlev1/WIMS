using ManagementSystem.Core.Contracts;
using ManagementSystem.Models;
using ManagementSystem.Models.Abstract;
using ManagementSystem.Models.Contracts;
using ManagementSystem.Models.Enums;
using ManagementSystem.Models.Units;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ManagementSystem;

namespace ManagementSystem.Core.Providers
{
    public class  Database : IDatabase
    {
        private List<IMember> memberList;

        private List<IWorkItem> workItems;
        private List<IBoard> boardList;
        private List<ITeam> teamList;
        private Dictionary<string, string> usernamePasswordDatabase;
        private List<IBug> bugList;
        private List<IFeedback> feedbacksList;
        private List<IStory> storyList;
        private readonly List<ActivityHistory> commandHistory;
        public Database()
        {
            this.boardList = new List<IBoard>();
            this.memberList = new List<IMember>();
            this.workItems = new List<IWorkItem>();
            this.bugList = new List<IBug>();
            this.teamList = new List<ITeam>();
            this.feedbacksList = new List<IFeedback>();
            this.storyList = new List<IStory>();
            this.usernamePasswordDatabase = new Dictionary<string, string>();
            this.commandHistory = new List<ActivityHistory>();
             SeedData();
            //TODO: IMPORRTANT: When you create a new list you need to comment SeedAllListsFromFiles(); from this constructor as if you don`t, the program will crash!
            //SeedAllListsFromFiles();
        }
        public void SeedData()
        {
            AddToBoardList(new Board("jivkobard"));
            AddToBoardList(new Board("Yoanabard"));
            AddToBoardList(new Board("Pavelbard"));
            AddToMemberList(new Member("jivko"));
            AddToMemberList(new Member("Yoanna"));
            AddToBugList(new Bug("JivkoBugBug", "asdasdasdasdasdasdasd", new List<string> { "asdasdasdasd" }, Priority.High, Severity.Critical, BugStatus.Active));
            AddToTeamList(new Team("Gotinite"));
            AddToFeedbackList(new Feedback("MoqtFeedback", "asdasdasdasdasdasdasd", 3, FeedbackStatus.New));
            AddToStoryList(new Story("MoytoStory", "qasdasdasdasdasdasdasd", Priority.High, StorySize.Large, StoryStatus.InProgress));
            AddToWorkItemList(new Bug("JivkoBugBug", "asdasdasdasdasdasdasd", new List<string> { "asdasdasdasd" }, Priority.High, Severity.Critical, BugStatus.Active));
        }

        [JsonConverter(typeof(WorkItemJsonConverter<List<WorkItem>>))]
        public List<IWorkItem> WorkItems { get => this.workItems.ToList(); }

        public List<ITeam> TeamList { get => this.teamList.ToList(); }
        public List<IBug> BugList { get => this.bugList.ToList(); }
        public List<IBoard> BoardList { get => this.boardList.ToList(); }
        public List<IMember> MemberList { get => this.memberList.ToList(); }
        public List<IFeedback> FeedbacksList { get => this.feedbacksList.ToList(); }
        public List<IStory> StoryList { get => this.storyList.ToList(); }
        public Dictionary<string, string> UsernamePasswordDatabase { get => FakeDic(usernamePasswordDatabase); }
        public List<ActivityHistory> CommandHistory { get => this.commandHistory; }

        public void AddToTeamList(ITeam team)
        {
            teamList.Add(team);
        }
        public void AddToWorkItemList(IWorkItem item)
        {
            workItems.Add(item);
        }
        public void AddToBugList(IBug bug)
        {
            bugList.Add(bug);
        }
        public void AddToBoardList(IBoard board)
        {
            boardList.Add(board);
        }
        public void AddToMemberList(IMember member)
        {
            memberList.Add(member);
        }
        public void AddToFeedbackList(IFeedback feedback)
        {
            feedbacksList.Add(feedback);
        }
        public void AddToStoryList(IStory story)
        {
            storyList.Add(story);
        }
        public void AddToUsernamePasswordDatabase(string username, string password)
        {
            usernamePasswordDatabase.Add(username, password);
        }
        public Dictionary<string, string> FakeDic(Dictionary<string, string> dic)
        {
            Dictionary<string, string> fakeDic = new Dictionary<string, string>();
            foreach (var item in usernamePasswordDatabase)
            {
                fakeDic.Add(item.Key, item.Value);

            }
            return fakeDic;
        }
        public ActivityHistory CreateActivityHistory(string message)
        {
            ActivityHistory activityHistory = new ActivityHistory(message);
            CommandHistory.Add(activityHistory);
            return activityHistory;
        }
        private void SeedWorkItemListFromFile()
        {
            if (!WorkItems.Any())
            {
                string json = File.ReadAllText(@"../../../Jsons/WorkItem.json");

                foreach (var item in JsonConvert.DeserializeObject<List<WorkItem>>(json))
                {
                    if (item is Bug)
                    {
                        AddToWorkItemList(item);
                    }
                    else if (item is Feedback)
                    {
                        AddToWorkItemList(item);
                    }
                    else if (item is Story)
                    {
                        AddToWorkItemList(item);
                    }
                }
            }
        }
        private void SaveWorkItemListToFile()
        {
            if (WorkItems.Any())
            {
                var json = JsonConvert.SerializeObject(WorkItems);
                File.WriteAllText(@"../../../Jsons/WorkItemList.json", json);
            }
        }
        private void SeedTeamListFromFile()
        {
            if (!TeamList.Any())
            {
                string json = File.ReadAllText(@"../../../Jsons/TeamList.json");
                var convertToTeamList = JsonConvert.DeserializeObject<List<Team>>(json);
                foreach (var team in convertToTeamList)
                {
                    AddToTeamList(team);
                }
            }
        }
        private void SaveTeamListToFile()
        {
            if (TeamList.Any())
            {
                var json = JsonConvert.SerializeObject(TeamList);
                File.WriteAllText(@"../../../Jsons/TeamList.json", json);
            }
        }
        private void SeedBugListFromFile()
        {
            if (!BugList.Any())
            {
                string json = File.ReadAllText(@"../../../Jsons/BugList.json");
                var convertToBugList = JsonConvert.DeserializeObject<List<Bug>>(json);
                foreach (var bug in convertToBugList)
                {
                    AddToBugList(bug);
                }
            }
        }
        private void SaveBugListToFile()
        {
            if (BugList.Any())
            {
                var json = JsonConvert.SerializeObject(BugList);
                File.WriteAllText(@"../../../Jsons/BugList.json", json);
            }
        }
        private void SeedBoardListFromFile()
        {
            if (!BoardList.Any())
            {
                string json = File.ReadAllText(@"../../../Jsons/BoardList.json");
                var convertToBoardList = JsonConvert.DeserializeObject<List<Board>>(json);
                foreach (var board in convertToBoardList)
                {
                    AddToBoardList(board);
                }
            }
        }
        private void SaveBoardListToFile()
        {
            if (BoardList.Any())
            {
                var json = JsonConvert.SerializeObject(BoardList);
                File.WriteAllText(@"../../../Jsons/BoardList.json", json);
            }
        }
        private void SeedMemberListFromFile()
        {
            if (!MemberList.Any())
            {
                string json = File.ReadAllText(@"../../../Jsons/MemberList.json");
                var convertToMemberList = JsonConvert.DeserializeObject<List<Member>>(json);



                foreach (var member in convertToMemberList)
                {
                    AddToMemberList(member);
                }
            }
        }
        private void SaveMemberListToFile()
        {
            if (MemberList.Any())
            {
                var json = JsonConvert.SerializeObject(MemberList);
                File.WriteAllText(@"../../../Jsons/MemberList.json", json);
            }
        }
        private void SeedFeedbackListFromFile()
        {
            if (!FeedbacksList.Any())
            {
                string json = File.ReadAllText(@"../../../Jsons/FeedbackList.json");
                var convertToFeedbackList = JsonConvert.DeserializeObject<List<Feedback>>(json);
                foreach (var feedback in convertToFeedbackList)
                {
                    AddToFeedbackList(feedback);
                }
            }
        }
        private void SaveFeedbackListToFile()
        {
            if (FeedbacksList.Any())
            {
                var json = JsonConvert.SerializeObject(FeedbacksList);
                File.WriteAllText(@"../../../Jsons/FeedbackList.json", json);
            }
        }
        private void SeedStoryListFromFile()
        {
            if (!StoryList.Any())
            {
                string json = File.ReadAllText(@"../../../Jsons/StoryList.json");
                var convertToStoryList = JsonConvert.DeserializeObject<List<Story>>(json);
                foreach (var story in convertToStoryList)
                {
                    AddToStoryList(story);
                }
            }
        }
        private void SaveStoryListToFile()
        {
            if (StoryList.Any())
            {
                var json = JsonConvert.SerializeObject(StoryList);
                File.WriteAllText(@"../../../Jsons/StoryList.json", json);
            }
        }
        private void SeedUsernamePassrowdFromFile()
        {
            if (!UsernamePasswordDatabase.Any())
            {
                string json = File.ReadAllText(@"../../../Jsons/UsernamePasswordDatabase.json");
                var convertToUsernamePass = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                foreach (var userPass in convertToUsernamePass)
                {
                    AddToUsernamePasswordDatabase(userPass.Key, userPass.Value);
                }
            }
        }
        private void SaveUsernamePasswordToFile()
        {
            if (StoryList.Any())
            {
                var json = JsonConvert.SerializeObject(UsernamePasswordDatabase);
                File.WriteAllText(@"../../../Jsons/UsernamePasswordDatabase.json", json);
            }
        }

        private void SeedCommandActivityHistoryFromFile()
        {
            if (!TeamList.Any())
            {
                string json = File.ReadAllText(@"../../../Jsons/CommandActivityHistory.json");
                var convertToActivityHistoryList = JsonConvert.DeserializeObject<List<ActivityHistory>>(json);
                foreach (var history in convertToActivityHistoryList)
                {
                    convertToActivityHistoryList.Add(history);
                }
            }
        }
        private void SaveCommandActivityHistoryToFile()
        {
            if (CommandHistory.Any())
            {
                var json = JsonConvert.SerializeObject(CommandHistory);
                File.WriteAllText(@"../../../Jsons/CommandActivityHistory.json", json);
            }
        }
        public void SeedAllListsFromFiles()
        {
            //SeedWorkItemListFromFile();
            SeedTeamListFromFile();
            SeedBugListFromFile();
            SeedBoardListFromFile();
            SeedMemberListFromFile();
            SeedFeedbackListFromFile();
            SeedStoryListFromFile();
            SeedUsernamePassrowdFromFile();
            SeedCommandActivityHistoryFromFile();

        }
        public void SaveAllListsToFiles()
        {
            SaveWorkItemListToFile();
            SaveTeamListToFile();
            SaveBugListToFile();
            SaveBoardListToFile();
            SaveMemberListToFile();
            SaveFeedbackListToFile();
            SaveStoryListToFile();
            SaveUsernamePasswordToFile();
            SaveCommandActivityHistoryToFile();
        }

    }
}
