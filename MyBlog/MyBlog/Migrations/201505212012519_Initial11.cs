namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "Name");
            DropColumn("dbo.Comments", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Email", c => c.String());
            AddColumn("dbo.Comments", "Name", c => c.String());
        }
    }
}
