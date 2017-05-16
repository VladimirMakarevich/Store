namespace Store.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigrationfortest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "MyProperty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "MyProperty");
        }
    }
}
