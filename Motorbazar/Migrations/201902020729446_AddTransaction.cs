namespace Motorbazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateBought = c.DateTime(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Vehicle_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Vehicle_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Transactions", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "Vehicle_Id" });
            DropIndex("dbo.Transactions", new[] { "Customer_Id" });
            DropTable("dbo.Transactions");
        }
    }
}
