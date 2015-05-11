namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            RenameColumn(table: "dbo.Comments", name: "Post_PostId", newName: "PostId");
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Post_PostId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Post_PostId);
            
            AlterColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "PostId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_TagId", "dbo.Tags");
            DropIndex("dbo.TagPosts", new[] { "Post_PostId" });
            DropIndex("dbo.TagPosts", new[] { "Tag_TagId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            AlterColumn("dbo.Comments", "PostId", c => c.Int());
            DropTable("dbo.TagPosts");
            RenameColumn(table: "dbo.Comments", name: "PostId", newName: "Post_PostId");
            CreateIndex("dbo.Comments", "Post_PostId");
            AddForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts", "PostId");
        }
    }
}
