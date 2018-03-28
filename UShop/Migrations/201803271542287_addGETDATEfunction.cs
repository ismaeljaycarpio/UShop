namespace UShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGETDATEfunction : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false, defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
        }
    }
}
