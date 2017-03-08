namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToMembershipTyoe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Description");
        }
    }
}
