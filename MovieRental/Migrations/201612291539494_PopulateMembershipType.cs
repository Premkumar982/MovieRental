namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipTypes (Id,SignupFee, DurationinMonths,DiscountRate) Values (1, 0, 0, 0)");
            Sql("Insert into MembershipTypes (Id,SignupFee, DurationinMonths,DiscountRate) Values (2, 10, 1, 10)");
            Sql("Insert into MembershipTypes (Id,SignupFee, DurationinMonths,DiscountRate) Values (3, 30, 3, 15)");
            Sql("Insert into MembershipTypes (Id,SignupFee, DurationinMonths,DiscountRate) Values (4, 50, 6, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
