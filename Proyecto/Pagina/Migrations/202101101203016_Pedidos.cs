namespace Pagina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pedidos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "ClienteID", c => c.String(maxLength: 128));
            AddColumn("dbo.Pedidoes", "Estado", c => c.String());
            AddColumn("dbo.AspNetUsers", "Pedido_ID", c => c.Int());
            AlterColumn("dbo.Pedidoes", "Total", c => c.Double(nullable: false));
            CreateIndex("dbo.Pedidoes", "ClienteID");
            CreateIndex("dbo.AspNetUsers", "Pedido_ID");
            AddForeignKey("dbo.Pedidoes", "ClienteID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Pedido_ID", "dbo.Pedidoes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Pedido_ID", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "ClienteID", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "Pedido_ID" });
            DropIndex("dbo.Pedidoes", new[] { "ClienteID" });
            AlterColumn("dbo.Pedidoes", "Total", c => c.String());
            DropColumn("dbo.AspNetUsers", "Pedido_ID");
            DropColumn("dbo.Pedidoes", "Estado");
            DropColumn("dbo.Pedidoes", "ClienteID");
        }
    }
}
