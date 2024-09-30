using KcbBotSemanticKernel.Bot.Common;
using KcbBotSemanticKernel.Bot.Helper;
using KcbBotSemanticKernel.Bot.Models.Chat;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace KcbBotSemanticKernel.Bot.Service
{
    public class ChatService
    {
        private readonly ApiHelper _apiHelper;

        public ChatService(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public ResponseMessage GetChatResponse(string question)
        {
            string response = _apiHelper.ChatAsync(question).Result;
            var jsonObject = JObject.Parse(response);

            string answer = (jsonObject["variables"]
            .FirstOrDefault(v => v["key"].ToString() == "answer")?["value"]).ToString();

            var chatId = (jsonObject["variables"]
            .FirstOrDefault(v => v["key"].ToString() == "chatId")?["value"]).ToString();

            State.ChatId = chatId;

            return new ResponseMessage() { 
                ChatId = chatId,
                Answer = answer
            };
        }
    }
}
