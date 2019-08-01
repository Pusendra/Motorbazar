namespace Motorbazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumbersToVehicles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "NumberAvailable", c => c.Byte(nullable: false));
            AddColumn("dbo.Vehicles", "NumberInStock", c => c.Byte(nullable: false));

            Sql("UPDATE Vehicles SET NumberAvailable = NumberInStock");

        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "NumberInStock");
            DropColumn("dbo.Vehicles", "NumberAvailable");
        }
    }
}
