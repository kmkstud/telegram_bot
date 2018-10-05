
using System.Data.Entity;


namespace TelegramBotApp.Models.EF
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}