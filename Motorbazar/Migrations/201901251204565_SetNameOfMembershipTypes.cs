namespace Motorbazar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name1 = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name1 = 'Yearly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name1 = 'Three Yearly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name1 = 'Per Decade' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
