namespace TelegramBotApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addchatId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "chatId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "chatId");
        }
    }
}
