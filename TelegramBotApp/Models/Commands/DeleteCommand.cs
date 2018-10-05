using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotApp.Models.EF;

namespace TelegramBotApp.Models.Commands
{
    public class DeleteCommand : Command
    {

        public override string Name => "delete";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            if (delete(message.Text, chatId))
            {
                client.SendTextMessageAsync(chatId, "Your registration has been deleted", replyToMessageId: messageId);
            }
            else
            {
                client.SendTextMessageAsync(chatId, "Your are not registered", replyToMessageId: messageId);
            }
        }

        public bool delete(string answer, long chatId)
        {
            using (PersonContext db = new PersonContext())
            {
                var cause = db.Persons.FirstOrDefault(m => m.TelegramId == chatId);
                if (cause == null)
                {
                    return false;
                }

                db.Persons.Remove(cause);
                db.SaveChangesAsync();
                return true;
            }
        }
    }
}