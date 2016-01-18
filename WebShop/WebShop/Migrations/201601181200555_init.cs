namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        order_Id = c.Int(),
                        product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.order_Id)
                .ForeignKey("dbo.Products", t => t.product_Id)
                .Index(t => t.order_Id)
                .Index(t => t.product_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfOrder = c.DateTime(nullable: false),
                        user_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.user_ID)
                .Index(t => t.user_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Adress = c.String(),
                        PhonNumber = c.Int(nullable: false),
                        EmailAdress = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        Type = c.String(),
                        Model = c.String(),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRows", "product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "user_ID", "dbo.Users");
            DropForeignKey("dbo.OrderRows", "order_Id", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "user_ID" });
            DropIndex("dbo.OrderRows", new[] { "product_Id" });
            DropIndex("dbo.OrderRows", new[] { "order_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRows");
        }
    }
}
