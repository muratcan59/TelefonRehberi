namespace TelefonRehberi.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v35 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SifremiUnuttum", "KullaniciId", "dbo.Kullanici");
            DropIndex("dbo.SifremiUnuttum", new[] { "KullaniciId" });
            AddColumn("dbo.SifremiUnuttum", "Email", c => c.String());
            AlterColumn("dbo.SifremiUnuttum", "Kod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SifremiUnuttum", "Kod", c => c.String());
            DropColumn("dbo.SifremiUnuttum", "Email");
            CreateIndex("dbo.SifremiUnuttum", "KullaniciId");
            AddForeignKey("dbo.SifremiUnuttum", "KullaniciId", "dbo.Kullanici", "Id", cascadeDelete: true);
        }
    }
}
