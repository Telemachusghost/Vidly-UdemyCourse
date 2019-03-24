namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId, BirthDate) VALUES ('Derick', 'True', 2, '1991-07-21 12:12:12')");
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId, BirthDate) VALUES ('Shanin', 'False', 1, '1991-09-18 12:12:12')");
        }
        
        public override void Down()
        {
        }
    }
}
