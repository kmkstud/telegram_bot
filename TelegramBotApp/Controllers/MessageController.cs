using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using TelegramBotApp.Models;

namespace TelegramBotApp.Controllers
{

    public class MessageController : ApiController
    {
        
        [Route(@"api/message/update")] //webhook uri part
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message  = update.Message;
            var client   = await Bot.Get();
            var l = Bot.lastCommand;


            //foreach (var command in commands)
            //{
            //    if (command.Contains(message.Text))
            //    {
            //        command.Execute(message, client);
            //        break;
            //    }
            //    else registration.register(db, message.Text);
            //}

            var command = commands.FirstOrDefault(x => x.Contains(message.Text));
            if (command != null)
            {
                command.Execute(message, client);
                Bot.lastCommand = command;
            }
            else if (Bot.lastCommand.Contains("/register"))
            {
                command = commands.FirstOrDefault(x => x.Contains("ToDatabase"));
                command.Execute(message, client);
                Bot.lastCommand = null;
            }
            else 
            {
                command = commands.FirstOrDefault(x => x.Contains("/indefinite"));
                command.Execute(message, client);
                Bot.lastCommand = command;
            }

            return Ok();
        }

    }
}
