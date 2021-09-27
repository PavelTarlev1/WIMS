

using System.Collections.Generic;

namespace ManagementSystem.Core
{
    public static class PrintMessages
    {
        public const string ExitCommand = "Exit";
        public const string NullProvidersExceptionMessage = "cannot be null.";
        public static List<string> menuItemsNotLogged = new List<string>()
            {
                "Login",
                "Register",
                "Exit"
            };
        public static List<string> ShowMenu = new List<string>()
            {
                "ShowMenu",
                "Exit"

            };

        public static List<string> menuList = new List<string>()
            {
                "CreateBoard",
                "ShowAllBoards",
                "ShowBoardActivity",
                "--------------------",
                "AddCommentToWorkItem",
                "ShowAllWorkItems",
                "AssignWorkItem",
                "UnassignWorkItem",
                "--------------------",
                "CreateBug",
                "ChangeBugStatus",
                "ChangeBugSeverity",
                "ChangeBugPriority",
                "--------------------",
                "CreateFeedback",
                "ChangeFeedbackStatus",
                "ChangeFeedbackRating",
                "--------------------",
                "CreateMember",
                "ShowAllMembers",
                "ShowMemberHistory",
                "--------------------",
                "CreateTeam",
                "AddBoardToTeam",
                "AddMemberToTeam",
                "ShowAllTeamMembers",
                "ShowAllTeams",
                "ShowAllTeamBoards",
                "ShowAllTeamActivity",
                "--------------------",
                "CreateStory",
                "ChangeStoryPriority",
                "ChangeStoryStatus",
                "ChangeStorySize",
                "--------------------",
                 "FilterWorkItemByStatus",
                 "FilterWorkItemByAssignee",
                 "ListAllItems",
                 "ListWorkItems",
                 "SortWorkItems"
            };

        public const string commandNotFound = "The passed command is not found!";


        //REQUIREMENTS
        public const string usernameRequirements = "Username should contain at least 8 symbols.";
        public const string passwordRequirements =
            "Password must be at least 8 symbols long, must contain at least one digit and at least one " +
            "UpperCase and LowerCase letter.";
        public const string titleRequirements = "The title must be between 10 and 50 characters.";
        public const string descriptionRequirements = "The title must be between 10 and 500 characters.";
        public const string feedbackRequirements = "Rating must be positive number.";

        //REGISTRATION AND LOGIN
        public const string userName = "Username: ";
        public const string password = "Password: ";
        public const string memberAlreadyExists = "Member already exists!";
        public const string successfullyRegistered = "Member successfully added!";
        public const string successfullyLoggedIn = "Member successfully logged in!";
        public const string memberNotLoggedIn = "Member did not manage to log in!";
        public const string wrongPassword = "Wrong Password! Please try again!";

        //ENUMS
        public const string choosePriority = "Choose priority: ";
        public const string chooseStatus = "Choose status: ";
        public const string chooseSeverity = "Choose severity: ";
        public const string chooseSize = "Choose size: ";

        //BOARD
        public const string AllBoards = "Boards in database: ";
        public const string title = "Title: ";


        public const string ChooseBoard = "Go up and down with the arrows and press enter to choose a board.";
        public const string writeNameOfBoard = "Name of board: ";
        public const string boardDoesNotExist = "This board does not exist!";
        public const string boardAlreadyExists = "This board name already exists!";
        public const string boardSuccessfullyCreated = "You have successfully created a board!";
        public const string boardSuccessfullyAddedToTeam = "You have successfully added the board to team!";


        //BUG
        public const string writeNameOfBug = "Name of bug: ";
        public const string description = "Description: ";
        public const string stepsToProduce = "Steps to produce: ";
        public const string chooseNumberOfSteps = "Write number of steps: ";
        public const string inputINTneeded = "Please enter a number: ";
        public const string chooseAssignee = "Choose assignee: ";
        public const string bugDoesNotExist = "This bug does not exist.";
        public const string bugSuccesfullyCreated = "Bug successfully created!";

        //MEMBER
        public const string memberNOTSuccessfullyAddedToTeam = "Please choose a valid team and member.";
        public const string memberSuccessfullyAddedToTeam = "Member successfully added!";
        public const string memberSuccessfullyCreated = "Member successfully created!";
        public const string memberHistoryEmpty = "There is no history of this member.";
        public const string memberDoesNotExist = "This member does not exist.";
        public const string addMembersToTeam = "Numbers of members to be added: ";


        //STORY
        public const string storySuccesfullyCreated = "Story successfully created!";
        public const string storySizeSuccessfullyChanged = "Story size successfully changed!";
        public const string storySizeNOTChanged = "Story size NOT changed!";


        //FEEDBACK
        public const string FeedbackRating = "Rating: ";
        public const string newFeedbackRating = "New rating: ";
        public const string feedbackRatingChanged = "Feedback rating successfully changed!";
        public const string feedbackRatingNotChanged = "Please provide valid rating.";
        public const string feedbackSuccesfullyCreated = "Feedback successfully created!";
        public const string feedbackStatusChanged = "Feedback Status successfully changed!";
        public const string feedbackStatusNotChanged = "Please provide valid status.";

        //TEAM
        public const string teamSuccesfullyCreated = "Team successfully created!";
        public const string teamAlreadyExist = "Team with this name already exists!";
        public const string teamNOTfound = "This member does not exist.";

        //ENUMS
        public const string priorityChanged = "Priority has been successfully changed.";
        public const string priorityNotChanged = "Please provide valid priority.";
        public const string severityChanged = "Severity has been successfully changed.";
        public const string severityNotChanged = "Please provide valid severity.";
        public const string statusChanged = "Status has been successfully changed.";
        public const string statusNotChanged = "Please provide valid status.";

        //WORKITEM
        public const string successfullyAddedComment = "Successfully added a comment.";
        public const string workItemSuccessfullyAssigned = "Work item successfully assigned.";
        public const string workItemSuccessfullyUnassigned = "Work item successfully unassigned.";

        //COMMON
        public const string noAssignees = "There are no assigned members.";
        public const string chooseSort = "Choose between the options for sorting: ";


    }
}
