namespace Motorbazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationInYears,DiscountRate) VALUES(1,0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationInYears,DiscountRate) VALUES(2,10,1,10)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationInYears,DiscountRate) VALUES(3,20,3,15)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFee,DurationInYears,DiscountRate) VALUES(4,50,10,25)");
        }
        
        public override void Down()
        {
        }
    }
}
