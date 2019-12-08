namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ReaderCards", "ReaderId");
            AddForeignKey("dbo.ReaderCards", "ReaderId", "dbo.Readers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReaderCards", "ReaderId", "dbo.Readers");
            DropIndex("dbo.ReaderCards", new[] { "ReaderId" });
        }
    }
}
