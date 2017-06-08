namespace HalloCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConfigurationToArticlesTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Articles", newName: "Artikel");
            AlterColumn("dbo.Artikel", "Name", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artikel", "Name", c => c.String());
            RenameTable(name: "dbo.Artikel", newName: "Articles");
        }
    }
}
