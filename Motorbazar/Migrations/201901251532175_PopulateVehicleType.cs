namespace Motorbazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateVehicleType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO VehicleTypes (Id, Name) VALUES (1, 'Hatchback')");
            Sql("INSERT INTO VehicleTypes (Id, Name) VALUES (2, 'Pickup')");
            Sql("INSERT INTO VehicleTypes (Id, Name) VALUES (3, 'Compact')");
            Sql("INSERT INTO VehicleTypes (Id, Name) VALUES (4, 'Sportcoupe')");
            Sql("INSERT INTO VehicleTypes (Id, Name) VALUES (5, 'Van')");
            Sql("INSERT INTO VehicleTypes (Id, Name) VALUES (6, 'Crossover')");
        }
        
        public override void Down()
        {
        }
    }
}
