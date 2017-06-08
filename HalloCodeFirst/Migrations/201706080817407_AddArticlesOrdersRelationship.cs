namespace HalloCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticlesOrdersRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtikelAuftraege",
                c => new
                    {
                        Artikelnummer = c.Int(nullable: false),
                        Auftragsnummer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artikelnummer, t.Auftragsnummer })
                .ForeignKey("dbo.Artikel", t => t.Artikelnummer, cascadeDelete: true)
                .ForeignKey("dbo.Aufträge", t => t.Auftragsnummer, cascadeDelete: true)
                .Index(t => t.Artikelnummer)
                .Index(t => t.Auftragsnummer);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtikelAuftraege", "Auftragsnummer", "dbo.Aufträge");
            DropForeignKey("dbo.ArtikelAuftraege", "Artikelnummer", "dbo.Artikel");
            DropIndex("dbo.ArtikelAuftraege", new[] { "Auftragsnummer" });
            DropIndex("dbo.ArtikelAuftraege", new[] { "Artikelnummer" });
            DropTable("dbo.ArtikelAuftraege");
        }
    }
}
