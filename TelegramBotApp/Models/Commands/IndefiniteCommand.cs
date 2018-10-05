using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotApp.Models.Commands
{
    public class IndefiniteCommand : Command
    {
        public override string Name => "indefinite";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            client.SendTextMessageAsync(chatId, "Indefinite сommand", replyToMessageId: messageId);
        }
    }
}