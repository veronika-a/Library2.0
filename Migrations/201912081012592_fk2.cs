namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AuthorCards", "Authorid");
            CreateIndex("dbo.AuthorCards", "Bookid");
            CreateIndex("dbo.Chapters", "BookId");
            CreateIndex("dbo.ReaderCards", "BookId");
            AddForeignKey("dbo.AuthorCards", "Authorid", "dbo.Authors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AuthorCards", "Bookid", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Chapters", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReaderCards", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReaderCards", "BookId", "dbo.Books");
            DropForeignKey("dbo.Chapters", "BookId", "dbo.Books");
            DropForeignKey("dbo.AuthorCards", "Bookid", "dbo.Books");
            DropForeignKey("dbo.AuthorCards", "Authorid", "dbo.Authors");
            DropIndex("dbo.ReaderCards", new[] { "BookId" });
            DropIndex("dbo.Chapters", new[] { "BookId" });
            DropIndex("dbo.AuthorCards", new[] { "Bookid" });
            DropIndex("dbo.AuthorCards", new[] { "Authorid" });
        }
    }
}
