namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixProductStockRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AddressName = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        CityId = c.Int(nullable: false),
                        PostalCode = c.String(),
                        Telephone = c.Int(nullable: false),
                        MobilePhone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CityId);
            
            AddColumn("dbo.Cities", "CityName", c => c.String());
            DropColumn("dbo.Cities", "City_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "City_Name", c => c.String());
            AddColumn("dbo.Stocks", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserAddresses", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAddresses", "CityId", "dbo.Cities");
            DropIndex("dbo.UserAddresses", new[] { "CityId" });
            DropIndex("dbo.UserAddresses", new[] { "UserId" });
            DropColumn("dbo.Cities", "CityName");
            DropTable("dbo.UserAddresses");

        }
    }
}
