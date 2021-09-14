namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Authorid = c.Int(nullable: false),
                        Bookid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Authorid, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Bookid, cascadeDelete: true)
                .Index(t => t.Authorid)
                .Index(t => t.Bookid);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        DateBorn = c.DateTime(),
                        DateDied = c.DateTime(),
                        Nationality = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Ganre = c.String(),
                        About = c.String(),
                        Publisher = c.String(),
                        PublicationDate = c.Int(),
                        CoverArtist = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Double(nullable: false),
                        Title = c.String(),
                        FirstPage = c.Int(nullable: false),
                        LastPage = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.ReaderCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOrdered = c.DateTime(),
                        DateTook = c.DateTime(),
                        DateReturn = c.DateTime(),
                        ReaderId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Readers", t => t.ReaderId, cascadeDelete: true)
                .Index(t => t.ReaderId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Date = c.DateTime(),
                        Gender = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReaderCards", "ReaderId", "dbo.Readers");
            DropForeignKey("dbo.ReaderCards", "BookId", "dbo.Books");
            DropForeignKey("dbo.Chapters", "BookId", "dbo.Books");
            DropForeignKey("dbo.AuthorCards", "Bookid", "dbo.Books");
            DropForeignKey("dbo.AuthorCards", "Authorid", "dbo.Authors");
            DropIndex("dbo.ReaderCards", new[] { "BookId" });
            DropIndex("dbo.ReaderCards", new[] { "ReaderId" });
            DropIndex("dbo.Chapters", new[] { "BookId" });
            DropIndex("dbo.AuthorCards", new[] { "Bookid" });
            DropIndex("dbo.AuthorCards", new[] { "Authorid" });
            DropTable("dbo.Readers");
            DropTable("dbo.ReaderCards");
            DropTable("dbo.Chapters");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.AuthorCards");
        }
    }
}
