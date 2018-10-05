using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotApp.Models.EF;
using ExtensionMethods;
using System.Globalization;

namespace TelegramBotApp.Models.Commands
{
    public class ToDatabaseCommand : Command
    {
        
        public override string Name => "ToDatabase";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            
            try
            {
                register(message.Text);
                client.SendTextMessageAsync(chatId, "You are registered", replyToMessageId: messageId);
            }

            catch (Exception e)
            {
                client.SendTextMessageAsync(chatId, "Wrong answer format", replyToMessageId: messageId);
            }
        }
        
        public void register( string answer)
        {
            Person person = new Person();

            string[] words = answer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            person.Surname = words[0];
            person.Name = words[1];
            person.Secondname = words[2];
            person.DateOfBirth = DateTime.Parse(words[3]);

            using (PersonContext db = new PersonContext())
            {
                db.Persons.Add(person);
                db.SaveChanges();
            }
        }
    }
}

namespace ExtensionMethods
{
    using System;
    using System.Globalization;

    public static class DateTimeExtensions
    {
        public static DateTime ToDateTime(this string s,
                  string format = "ddMMyyyy", string cultureString = "tr-TR")
        {
            try
            {
                var r = DateTime.ParseExact(
                    s: s,
                    format: format,
                    provider: CultureInfo.GetCultureInfo(cultureString));
                return r;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (CultureNotFoundException)
            {
                throw; // Given Culture is not supported culture
            }
        }

        public static DateTime ToDateTime(this string s,
                    string format, CultureInfo culture)
        {
            try
            {
                var r = DateTime.ParseExact(s: s, format: format,
                                        provider: culture);
                return r;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (CultureNotFoundException)
            {
                throw; // Given Culture is not supported culture
            }

        }

    }
}