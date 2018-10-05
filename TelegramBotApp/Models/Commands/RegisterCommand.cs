using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotApp.Models.Commands
{
    public class RegisterCommand : Command
    {
        public override string Name => "register";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            
            client.SendTextMessageAsync(chatId, "Send your data in this format: Фамилия Имя Отчество день/месяц/год", replyToMessageId: messageId);

        }
    }
}