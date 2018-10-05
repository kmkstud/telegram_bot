namespace TelegramBotApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtelId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "TelegramId", c => c.Long(nullable: false));
            DropColumn("dbo.People", "chatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "chatId", c => c.Int(nullable: false));
            DropColumn("dbo.People", "TelegramId");
        }
    }
}
