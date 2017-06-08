namespace HalloCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerOrdersRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aufträge", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Aufträge", "CustomerId");
            AddForeignKey("dbo.Aufträge", "CustomerId", "dbo.Kunden", "KundenId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aufträge", "CustomerId", "dbo.Kunden");
            DropIndex("dbo.Aufträge", new[] { "CustomerId" });
            DropColumn("dbo.Aufträge", "CustomerId");
        }
    }
}
