using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotApp.Models.EF;

namespace TelegramBotApp.Models.Commands
{
    public class GetInformationCommand : Command
    {
        public override string Name => "getinformation";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            var currentPerson = get(message.Text);

            if (currentPerson != null)
            {
                client.SendTextMessageAsync(chatId, string.Format("Ваше ФИО: {0} {1} {2}, дата рождения: {3}", currentPerson.Surname, currentPerson.Name, currentPerson.Secondname, currentPerson.DateOfBirth.Date), replyToMessageId: messageId);
            }
            else
            {
                client.SendTextMessageAsync(chatId, "You are not registered", replyToMessageId: messageId);
            }

        }

        public Person get(string answer)
        {
            using (PersonContext db = new PersonContext())
            {
                var persons = db.Persons.FirstOrDefault(p => p.Name == "Madina");
                return persons;
            }
        }
    }
}