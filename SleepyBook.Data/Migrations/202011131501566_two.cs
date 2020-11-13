namespace SleepyBook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class two : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reply", "Comment_CommentID", "dbo.Comment");
            DropForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post");
            DropIndex("dbo.Reply", new[] { "Comment_CommentID" });
            DropIndex("dbo.Like", new[] { "LikedPost_Id" });
            DropPrimaryKey("dbo.Like");
            AddColumn("dbo.Reply", "CommentId", c => c.Int(nullable: false));
            AddColumn("dbo.Reply", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Like", "LikeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Like", "LikedPost_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Like", "LikeId");
            CreateIndex("dbo.Like", "LikedPost_Id");
            AddForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post", "Id", cascadeDelete: true);
            DropColumn("dbo.Reply", "Comment_CommentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reply", "Comment_CommentID", c => c.Int());
            DropForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post");
            DropIndex("dbo.Like", new[] { "LikedPost_Id" });
            DropPrimaryKey("dbo.Like");
            AlterColumn("dbo.Like", "LikedPost_Id", c => c.Int());
            AlterColumn("dbo.Like", "LikeID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Reply", "CreatedUtc");
            DropColumn("dbo.Reply", "CommentId");
            AddPrimaryKey("dbo.Like", "LikeID");
            CreateIndex("dbo.Like", "LikedPost_Id");
            CreateIndex("dbo.Reply", "Comment_CommentID");
            AddForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post", "Id");
            AddForeignKey("dbo.Reply", "Comment_CommentID", "dbo.Comment", "CommentID");
        }
    }
}
