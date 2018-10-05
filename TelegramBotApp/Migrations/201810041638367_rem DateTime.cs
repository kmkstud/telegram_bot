namespace TelegramBotApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remDateTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "DateOfBirth", c => c.Int(nullable: false));
        }
    }
}
