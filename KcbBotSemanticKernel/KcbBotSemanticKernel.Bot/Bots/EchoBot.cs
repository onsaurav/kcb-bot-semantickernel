// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.22.0

using AdaptiveCards;
using KcbBotSemanticKernel.Bot.Common;
using KcbBotSemanticKernel.Bot.Helper;
using KcbBotSemanticKernel.Bot.Models.Chat;
using KcbBotSemanticKernel.Bot.Service;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KcbBotSemanticKernel.Bot.Bots
{
    public class EchoBot : ActivityHandler
    {
        public readonly CardHelper _cardHelper;
        public readonly ChatService _chatService;

        public EchoBot(CardHelper cardHelper, ChatService chatService)
        {
            _cardHelper = cardHelper;
            _chatService = chatService;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            //await turnContext.SendActivityAsync(MessageFactory.Text(respMessage.Answer, respMessage.Answer), cancellationToken);

            var userText = $"{turnContext.Activity.Text}";
            ResponseMessage respMessage = GetTestResponse(userText); //_chatService.GetChatResponse(userText);

            var card = _cardHelper.CreateResponseCard(respMessage.Answer);
            var activity = MessageFactory.Attachment(new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            });
            await turnContext.SendActivityAsync(activity, cancellationToken);
        }

        private ResponseMessage GetTestResponse(string userText)
        {
            return new ResponseMessage()
            {
                ChatId = Guid.Empty.ToString(),
                Answer = userText
            };
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    //await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);

                    var card = _cardHelper.CreateGreetingCard(Metadata.WelcomeNote);
                    var activity = MessageFactory.Attachment(new Attachment
                    {
                        ContentType = AdaptiveCard.ContentType,
                        Content = card
                    });
                    await turnContext.SendActivityAsync(activity, cancellationToken);
                }
            }
        }
    }
}
