namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemebershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name='Pay as you go' Where Id=1");
            Sql("Update MembershipTypes SET Name='Monthly' Where Id=2");
            Sql("Update MembershipTypes SET Name='Quarterly' Where Id=3");
            Sql("Update MembershipTypes SET Name='Half Yearly' Where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
