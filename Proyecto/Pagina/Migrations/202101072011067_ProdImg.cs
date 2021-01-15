namespace Pagina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProdImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "Imagen", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "Imagen");
        }
    }
}
