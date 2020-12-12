namespace Pagina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gemas", "Producto_ID", c => c.Int());
            AddColumn("dbo.Productoes", "Gema_ID", c => c.Int());
            CreateIndex("dbo.Gemas", "Producto_ID");
            CreateIndex("dbo.Productoes", "Gema_ID");
            AddForeignKey("dbo.Gemas", "Producto_ID", "dbo.Productoes", "ID");
            AddForeignKey("dbo.Productoes", "Gema_ID", "dbo.Gemas", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "Gema_ID", "dbo.Gemas");
            DropForeignKey("dbo.Gemas", "Producto_ID", "dbo.Productoes");
            DropIndex("dbo.Productoes", new[] { "Gema_ID" });
            DropIndex("dbo.Gemas", new[] { "Producto_ID" });
            DropColumn("dbo.Productoes", "Gema_ID");
            DropColumn("dbo.Gemas", "Producto_ID");
        }
    }
}
