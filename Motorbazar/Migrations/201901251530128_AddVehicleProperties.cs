namespace Motorbazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Model", c => c.String());
            AddColumn("dbo.Vehicles", "YearOfRelease", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicles", "Price", c => c.Short(nullable: false));
            AddColumn("dbo.Vehicles", "Mileage", c => c.Short(nullable: false));
            AddColumn("dbo.Vehicles", "AdditionalInformation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "AdditionalInformation");
            DropColumn("dbo.Vehicles", "Mileage");
            DropColumn("dbo.Vehicles", "Price");
            DropColumn("dbo.Vehicles", "YearOfRelease");
            DropColumn("dbo.Vehicles", "Model");
        }
    }
}
