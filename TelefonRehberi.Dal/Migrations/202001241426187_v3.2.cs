namespace TelefonRehberi.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v32 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kullanici", "AdSoyad", c => c.String(nullable: false, maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kullanici", "AdSoyad", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
