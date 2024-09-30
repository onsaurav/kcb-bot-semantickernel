namespace KcbBotSemanticKernel.Bot.Models
{
    public class Config
    {
        public Config()
        {
            ApiSettings = new ApiSettings();
            BotImage = new BotImage();
        }

        public string MicrosoftAppType { get; set; }
        public string MicrosoftAppId { get; set; }
        public string MicrosoftAppPassword { get; set; }
        public string MicrosoftAppTenantId { get; set; }

        public string BaseUrl { get; set; }                
        public ApiSettings ApiSettings { get; set; }
        public BotImage BotImage { get; set; }
    }
}
