namespace Pagina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pedidoes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedidoes", "ProductoID", "dbo.Productoes");
            AddColumn("dbo.Productoes", "Pedido_ID", c => c.Int());
            AddColumn("dbo.Pedidoes", "Producto_ID", c => c.Int());
            CreateIndex("dbo.Productoes", "Pedido_ID");
            CreateIndex("dbo.Pedidoes", "Producto_ID");
            AddForeignKey("dbo.Productoes", "Pedido_ID", "dbo.Pedidoes", "ID");
            AddForeignKey("dbo.Pedidoes", "Producto_ID", "dbo.Productoes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidoes", "Producto_ID", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "Pedido_ID", "dbo.Pedidoes");
            DropIndex("dbo.Pedidoes", new[] { "Producto_ID" });
            DropIndex("dbo.Productoes", new[] { "Pedido_ID" });
            DropColumn("dbo.Pedidoes", "Producto_ID");
            DropColumn("dbo.Productoes", "Pedido_ID");
            AddForeignKey("dbo.Pedidoes", "ProductoID", "dbo.Productoes", "ID", cascadeDelete: true);
        }
    }
}
