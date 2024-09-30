using AdaptiveCards;
using KcbBotSemanticKernel.Bot.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KcbBotSemanticKernel.Bot.Helper
{
    public class CardHelper
    {
        private readonly ConfigHelper _configHelper;

        public CardHelper(ConfigHelper configHelper)
        {
            _configHelper = configHelper;
        }

        public AdaptiveCard CreateGreetingCard(string text)
        {
            string baseUrl = _configHelper.GetConfig().BaseUrl;
            string cardJson = JsonHelper.ReadCardJson(Metadata.WelcomeCard);
            cardJson = cardJson
                .Replace("{name}", "USER")
                .Replace("{imageUrl}", _configHelper.GetConfig().BotImage.WelcomeImageUrl)
                .Replace("{dynamicText}", text)
                .Replace("{BASE-URL}", baseUrl);
            var card = AdaptiveCard.FromJson(cardJson).Card;
            return card;
        }

        public AdaptiveCard CreateResponseCard(string text)
        {
            string baseUrl = _configHelper.GetConfig().BaseUrl;
            string cardJson = JsonHelper.ReadCardJson(Metadata.ResponseCard);
            cardJson = cardJson
                .Replace("{name}", "USER")
                .Replace("{imageUrl}", _configHelper.GetConfig().BotImage.WelcomeImageUrl)
                .Replace("{response}", text)
                .Replace("{BASE-URL}", baseUrl);
            var card = AdaptiveCard.FromJson(cardJson).Card;
            return card;
        }

        public AdaptiveCard CreateMapCard()
        {
            double dhakaLatitude = 23.8103;
            double dhakaLongitude = 90.4125;

            string baseUrl = _configHelper.GetConfig().BaseUrl;
            string cardJson = JsonHelper.ReadCardJson(Metadata.MapCard);
            cardJson = cardJson
                .Replace("{name}", "USER")
                .Replace("{imageUrl}", _configHelper.GetConfig().BotImage.WelcomeImageUrl)
                .Replace("{latitude}", dhakaLatitude.ToString())
                .Replace("{longitude}", dhakaLongitude.ToString())
                .Replace("{BASE-URL}", baseUrl);
            var card = AdaptiveCard.FromJson(cardJson).Card;
            return card;
        }
    }
}