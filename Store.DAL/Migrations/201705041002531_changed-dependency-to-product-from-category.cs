namespace Store.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddependencytoproductfromcategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "ProductId", "dbo.Products");
            DropIndex("dbo.Categories", new[] { "ProductId" });
            DropPrimaryKey("dbo.Categories");
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.CategoryId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CategoryId);
            
            AddColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "Id");
            DropColumn("dbo.Categories", "ProductId");
            DropColumn("dbo.Products", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductCategories", new[] { "Category_Id" });
            DropIndex("dbo.ProductCategories", new[] { "Product_Id" });
            DropPrimaryKey("dbo.Categories");
            DropColumn("dbo.Categories", "Id");
            DropTable("dbo.ProductCategories");
            AddPrimaryKey("dbo.Categories", "ProductId");
            CreateIndex("dbo.Categories", "ProductId");
            AddForeignKey("dbo.Categories", "ProductId", "dbo.Products", "Id");
        }
    }
}
