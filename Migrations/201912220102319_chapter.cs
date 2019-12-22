namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chapter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chapters", "BookId", "dbo.Books");
            DropIndex("dbo.Chapters", new[] { "BookId" });
            DropTable("dbo.Chapters");
        }
        
        public override void Down()
        {
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
            
            CreateIndex("dbo.Chapters", "BookId");
            AddForeignKey("dbo.Chapters", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
