namespace HalloCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConfigurationToOrdersTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Orders", newName: "Aufträge");
            RenameColumn(table: "dbo.Aufträge", name: "Description", newName: "Auftragstext");
            AlterColumn("dbo.Aufträge", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Aufträge", "Auftragstext", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aufträge", "Auftragstext", c => c.String());
            AlterColumn("dbo.Aufträge", "Date", c => c.DateTime(nullable: false));
            RenameColumn(table: "dbo.Aufträge", name: "Auftragstext", newName: "Description");
            RenameTable(name: "dbo.Aufträge", newName: "Orders");
        }
    }
}
