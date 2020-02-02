namespace TelefonRehberi.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v36 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SifremiUnuttum", "KullaniciId");
            AddForeignKey("dbo.SifremiUnuttum", "KullaniciId", "dbo.Kullanici", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SifremiUnuttum", "KullaniciId", "dbo.Kullanici");
            DropIndex("dbo.SifremiUnuttum", new[] { "KullaniciId" });
        }
    }
}
