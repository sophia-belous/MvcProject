namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Likes", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Likes", "UserId");
            AddForeignKey("dbo.Likes", "UserId", "dbo.UserProfile", "UserId");
            DropColumn("dbo.Comments", "DateTime");
            DropColumn("dbo.Posts", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "DateTime", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Likes", "UserId", "dbo.UserProfile");
            DropIndex("dbo.Likes", new[] { "UserId" });
            DropColumn("dbo.Likes", "UserId");
            DropColumn("dbo.Posts", "Date");
            DropColumn("dbo.Comments", "Date");
        }
    }
}
