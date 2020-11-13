namespace SleepyBook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reply", "Comment_CommentID", "dbo.Comment");
            DropForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post");
            DropIndex("dbo.Reply", new[] { "Comment_CommentID" });
            DropIndex("dbo.Like", new[] { "LikedPost_Id" });
            RenameColumn(table: "dbo.Reply", name: "Comment_CommentID", newName: "CommentId");
            DropPrimaryKey("dbo.Like");
            AddColumn("dbo.Comment", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.Reply", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Reply", "CommentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Like", "LikeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Like", "LikedPost_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Like", "LikeId");
            CreateIndex("dbo.Comment", "Id");
            CreateIndex("dbo.Reply", "CommentId");
            CreateIndex("dbo.Like", "LikedPost_Id");
            AddForeignKey("dbo.Comment", "Id", "dbo.Post", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reply", "CommentId", "dbo.Comment", "CommentID", cascadeDelete: true);
            AddForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "Id", "dbo.Post");
            DropIndex("dbo.Like", new[] { "LikedPost_Id" });
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Comment", new[] { "Id" });
            DropPrimaryKey("dbo.Like");
            AlterColumn("dbo.Like", "LikedPost_Id", c => c.Int());
            AlterColumn("dbo.Like", "LikeID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Reply", "CommentId", c => c.Int());
            DropColumn("dbo.Reply", "CreatedUtc");
            DropColumn("dbo.Comment", "Id");
            AddPrimaryKey("dbo.Like", "LikeID");
            RenameColumn(table: "dbo.Reply", name: "CommentId", newName: "Comment_CommentID");
            CreateIndex("dbo.Like", "LikedPost_Id");
            CreateIndex("dbo.Reply", "Comment_CommentID");
            AddForeignKey("dbo.Like", "LikedPost_Id", "dbo.Post", "Id");
            AddForeignKey("dbo.Reply", "Comment_CommentID", "dbo.Comment", "CommentID");
        }
    }
}
