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
            RenameColumn(table: "dbo.Reply", name: "Comment_CommentID", newName: "CommentId");
            RenameColumn(table: "dbo.Like", name: "LikedPost_Id", newName: "PostId");
            AddColumn("dbo.Comment", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.Reply", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Reply", "CommentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Like", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "Id");
            CreateIndex("dbo.Reply", "CommentId");
            CreateIndex("dbo.Like", "PostId");
            AddForeignKey("dbo.Comment", "Id", "dbo.Post", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reply", "CommentId", "dbo.Comment", "CommentID", cascadeDelete: true);
            AddForeignKey("dbo.Like", "PostId", "dbo.Post", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "Id", "dbo.Post");
            DropIndex("dbo.Like", new[] { "PostId" });
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Comment", new[] { "Id" });
            AlterColumn("dbo.Like", "PostId", c => c.Int());
            AlterColumn("dbo.Reply", "CommentId", c => c.Int());
            DropColumn("dbo.Reply", "CreatedUtc");
            DropColumn("dbo.Comment", "Id");
            RenameColumn(table: "dbo.Like", name: "PostId", newName: "LikedPost_Id");
            RenameColumn(table: "dbo.Reply", name: "CommentId", newName: "Comment_CommentID");
            CreateIndex("dbo.Like", "LikedPost_Id");
            CreateIndex("dbo.Reply", "Comment_CommentID");
            AddForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post", "Id");
            AddForeignKey("dbo.Reply", "Comment_CommentID", "dbo.Comment", "CommentID");
        }
    }
}
