namespace Pagina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Payment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PaymentMethod", c => c.String());
            AddColumn("dbo.AspNetUsers", "PaymentName", c => c.String());
            AddColumn("dbo.AspNetUsers", "PaymentExpDate", c => c.String());
            AddColumn("dbo.AspNetUsers", "PaymentCCV", c => c.String());
            AddColumn("dbo.AspNetUsers", "PaymentNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "PaymentSave", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ZipCode");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "PaymentSave");
            DropColumn("dbo.AspNetUsers", "PaymentNumber");
            DropColumn("dbo.AspNetUsers", "PaymentCCV");
            DropColumn("dbo.AspNetUsers", "PaymentExpDate");
            DropColumn("dbo.AspNetUsers", "PaymentName");
            DropColumn("dbo.AspNetUsers", "PaymentMethod");
        }
    }
}
