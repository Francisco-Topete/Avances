namespace Pagina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gemas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductoID = c.Int(nullable: false),
                        Total = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Productoes", t => t.ProductoID, cascadeDelete: true)
                .Index(t => t.ProductoID);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        TipoID = c.Int(nullable: false),
                        GemaID = c.Int(nullable: false),
                        Precio = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gemas", t => t.GemaID, cascadeDelete: true)
                .ForeignKey("dbo.Tipoes", t => t.TipoID, cascadeDelete: true)
                .Index(t => t.TipoID)
                .Index(t => t.GemaID);
            
            CreateTable(
                "dbo.Tipoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidoes", "ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "TipoID", "dbo.Tipoes");
            DropForeignKey("dbo.Productoes", "GemaID", "dbo.Gemas");
            DropIndex("dbo.Productoes", new[] { "GemaID" });
            DropIndex("dbo.Productoes", new[] { "TipoID" });
            DropIndex("dbo.Pedidoes", new[] { "ProductoID" });
            DropTable("dbo.Tipoes");
            DropTable("dbo.Productoes");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Gemas");
        }
    }
}
