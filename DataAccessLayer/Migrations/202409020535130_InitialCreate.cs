namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.CitySuppliers", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.CitySuppliers", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.UserAddresses", "CityId", "dbo.Cities");
            DropIndex("dbo.Suppliers", new[] { "Supplier_Id" });
            DropIndex("dbo.Suppliers", new[] { "Product_Id" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.UserAddresses", new[] { "CityId" });
            DropIndex("dbo.CitySuppliers", new[] { "City_Id" });
            DropIndex("dbo.CitySuppliers", new[] { "Supplier_Id" });
            AddColumn("dbo.UserAddresses", "City", c => c.String());
            AlterColumn("dbo.Users", "Role", c => c.String());
            CreateIndex("dbo.Stocks", "ProductId");
            AddForeignKey("dbo.Stocks", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "SupplierId");
            DropColumn("dbo.UserAddresses", "CityId");
           
        }
        
        public override void Down()
        {
            
            AddColumn("dbo.UserAddresses", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "SupplierId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            AlterColumn("dbo.Users", "Role", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.UserAddresses", "City");
            CreateIndex("dbo.CitySuppliers", "Supplier_Id");
            CreateIndex("dbo.CitySuppliers", "City_Id");
            CreateIndex("dbo.UserAddresses", "CityId");
            CreateIndex("dbo.Cities", "CountryId");
            CreateIndex("dbo.Suppliers", "Product_Id");
            CreateIndex("dbo.Suppliers", "Supplier_Id");
            AddForeignKey("dbo.UserAddresses", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Suppliers", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Suppliers", "Supplier_Id", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.CitySuppliers", "Supplier_Id", "dbo.Suppliers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CitySuppliers", "City_Id", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
