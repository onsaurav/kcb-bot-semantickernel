namespace KcbBotSemanticKernel.Bot.Common
{
    public static class Metadata
    {
        public const string WelcomeCard = "welcomeCard.json";
        public const string ResponseCard = "responseCard.json";
        public const string MapCard = "mapCard.json";

        public const string WelcomeNote = "I’m here to help you with whatever you need. Just ask away, and let’s get started! 😊";

        public enum Mode
        {
            None = 0,
            Stream = 1
        }

        public enum ChatStatus
        {
            Starting = 0,
            Continue,
            Ending
        }
    }
}
