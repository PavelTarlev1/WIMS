namespace ManagementSystem.Models.Units
{
    public static class ValidationMessages
    {
        //MEMBER
        public const string MemberNameLenght = "Member name should be between 5 and 15 symbols";
        public const string MemberNameAlreadyExists = "Member name already exists";

        //BOARD
        public const string BoardNameLength = "Board name should be between 5 and 10 symbols";
        public const string BoardNameAlreadyExists = "Board name already exists in this team.";

        //TITLE
        public const string TitleNameLenght = "Title length should be between 10 and 50 symbols";

        //DESCRIPTION
        public const string DescriptionLength = "Description length should be between 10 and 500 symbols";

        //RATING
        public const string RatingShouldBePositiveNum = "Rating should be a positive number";
    }
}
