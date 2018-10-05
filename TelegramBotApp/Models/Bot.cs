using System.Collections.Generic;
using System.Threading.Tasks;

using Telegram.Bot;
using TelegramBotApp.Models.Commands;

namespace TelegramBotApp.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;
        public static Command lastCommand;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> Get()
        {
            if(client != null)
            {
                return client;
            }

            commandsList = new List<Command>();
            commandsList.Add(new HelloCommand());
            commandsList.Add(new RegisterCommand());
            commandsList.Add(new ToDatabaseCommand());
            commandsList.Add(new GetInformationCommand());
            commandsList.Add(new DeleteCommand());
            commandsList.Add(new IndefiniteCommand());

            lastCommand = new HelloCommand();

            client = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url, "api/message/update");
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}