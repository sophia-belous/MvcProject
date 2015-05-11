namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Body = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.UserProfiles", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_UserId", "dbo.UserProfiles");
            DropIndex("dbo.Posts", new[] { "User_UserId" });
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Posts");
        }
    }
}
