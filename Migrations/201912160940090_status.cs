namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReaderCards", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReaderCards", "Status");
        }
    }
}
