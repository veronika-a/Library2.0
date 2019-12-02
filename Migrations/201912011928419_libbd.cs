namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class libbd : DbMigration
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
                .PrimaryKey(t => t.Id);
            
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
                        Location = c.String(),
                        Edition = c.String(),
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
            DropTable("dbo.Readers");
            DropTable("dbo.ReaderCards");
            DropTable("dbo.Chapters");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.AuthorCards");
        }
    }
}
