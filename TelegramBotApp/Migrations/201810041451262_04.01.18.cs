namespace TelegramBotApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _040118 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Secondname", c => c.String());
            AddColumn("dbo.People", "Surname", c => c.String());
            AddColumn("dbo.People", "DateOfBirth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "DateOfBirth");
            DropColumn("dbo.People", "Surname");
            DropColumn("dbo.People", "Secondname");
        }
    }
}
