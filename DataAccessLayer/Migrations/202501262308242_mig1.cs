namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "MemberID", c => c.Int());
            AddColumn("dbo.Sessions", "FirmID", c => c.Int());
            CreateIndex("dbo.Sessions", "MemberID");
            CreateIndex("dbo.Sessions", "FirmID");
            AddForeignKey("dbo.Sessions", "FirmID", "dbo.Firms", "FirmID");
            AddForeignKey("dbo.Sessions", "MemberID", "dbo.Members", "MemberID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "MemberID", "dbo.Members");
            DropForeignKey("dbo.Sessions", "FirmID", "dbo.Firms");
            DropIndex("dbo.Sessions", new[] { "FirmID" });
            DropIndex("dbo.Sessions", new[] { "MemberID" });
            DropColumn("dbo.Sessions", "FirmID");
            DropColumn("dbo.Sessions", "MemberID");
        }
    }
}
