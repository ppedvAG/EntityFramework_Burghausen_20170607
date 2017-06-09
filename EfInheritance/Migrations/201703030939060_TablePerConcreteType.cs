namespace EfInheritance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablePerConcreteType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clocks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Desks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Material = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Desks");
            DropTable("dbo.Clocks");
        }
    }
}
