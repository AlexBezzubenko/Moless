namespace MoreLess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Category_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            AddColumn("dbo.Bids", "user_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Lots", "Category_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Bids", "user_Id");
            CreateIndex("dbo.Lots", "Category_Id");
            AddForeignKey("dbo.Bids", "user_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lots", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Bids", "AuctionId");
            DropColumn("dbo.Bids", "Username");
            DropColumn("dbo.Lots", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lots", "Category", c => c.String(nullable: false));
            AddColumn("dbo.Bids", "Username", c => c.String());
            AddColumn("dbo.Bids", "AuctionId", c => c.Long(nullable: false));
            DropForeignKey("dbo.Lots", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Bids", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "Category_Id" });
            DropIndex("dbo.Lots", new[] { "Category_Id" });
            DropIndex("dbo.Bids", new[] { "user_Id" });
            DropColumn("dbo.Lots", "Category_Id");
            DropColumn("dbo.Bids", "user_Id");
            DropTable("dbo.Categories");
        }
    }
}
