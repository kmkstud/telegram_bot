namespace TelegramBotApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "DateOfBirth");
        }
    }
}
