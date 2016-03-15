namespace RecipeBuilder_Version_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        ForumID = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Forum", t => t.ForumID, cascadeDelete: true)
                .Index(t => t.ForumID);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        TopicID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Subject = c.String(),
                        Body = c.String(),
                        Date = c.DateTime(nullable: false),
                        Member_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Member_Id)
                .ForeignKey("dbo.Topic", t => t.TopicID, cascadeDelete: true)
                .Index(t => t.TopicID)
                .Index(t => t.CategoryID)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        MessageID = c.Int(nullable: false),
                        Body = c.String(),
                        Date = c.DateTime(nullable: false),
                        Member_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.AspNetUsers", t => t.Member_Id)
                .ForeignKey("dbo.Message", t => t.MessageID, cascadeDelete: true)
                .Index(t => t.MessageID)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Topic",
                c => new
                    {
                        TopicID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TopicID);
            
            CreateTable(
                "dbo.Forum",
                c => new
                    {
                        ForumID = c.Int(nullable: false, identity: true),
                        ForumName = c.String(),
                    })
                .PrimaryKey(t => t.ForumID);
            
            AddColumn("dbo.AspNetUsers", "MemberID", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateJoined", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "ForumID", "dbo.Forum");
            DropForeignKey("dbo.Message", "TopicID", "dbo.Topic");
            DropForeignKey("dbo.Comment", "MessageID", "dbo.Message");
            DropForeignKey("dbo.Message", "Member_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comment", "Member_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Message", "CategoryID", "dbo.Category");
            DropIndex("dbo.Comment", new[] { "Member_Id" });
            DropIndex("dbo.Comment", new[] { "MessageID" });
            DropIndex("dbo.Message", new[] { "Member_Id" });
            DropIndex("dbo.Message", new[] { "CategoryID" });
            DropIndex("dbo.Message", new[] { "TopicID" });
            DropIndex("dbo.Category", new[] { "ForumID" });
            DropColumn("dbo.AspNetUsers", "DateJoined");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "MemberID");
            DropTable("dbo.Forum");
            DropTable("dbo.Topic");
            DropTable("dbo.Comment");
            DropTable("dbo.Message");
            DropTable("dbo.Category");
        }
    }
}
