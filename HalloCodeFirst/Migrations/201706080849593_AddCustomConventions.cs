namespace HalloCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomConventions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kunden", "Adresszusatz", c => c.String(nullable: false, maxLength: 200, unicode: false));
            AlterColumn("dbo.Kunden", "Telephone", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kunden", "Telephone", c => c.String());
            AlterColumn("dbo.Kunden", "Adresszusatz", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
    }
}
