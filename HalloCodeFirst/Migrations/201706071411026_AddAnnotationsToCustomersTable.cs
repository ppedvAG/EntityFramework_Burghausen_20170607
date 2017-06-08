namespace HalloCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationsToCustomersTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Kunden");
            RenameColumn(table: "dbo.Kunden", name: "Id", newName: "KundenId");
            RenameColumn(table: "dbo.Kunden", name: "Name2", newName: "Adresszusatz");
            AlterColumn("dbo.Kunden", "Name1", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Kunden", "Adresszusatz", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kunden", "Adresszusatz", c => c.String());
            AlterColumn("dbo.Kunden", "Name1", c => c.String());
            RenameColumn(table: "dbo.Kunden", name: "Adresszusatz", newName: "Name2");
            RenameColumn(table: "dbo.Kunden", name: "KundenId", newName: "Id");
            RenameTable(name: "dbo.Kunden", newName: "Customers");
        }
    }
}
