namespace TelefonRehberi.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v34 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SifremiUnuttum",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciId = c.Int(nullable: false),
                        Kod = c.String(),
                        KayitTarihi = c.DateTime(nullable: false),
                        SilindiMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId, cascadeDelete: true)
                .Index(t => t.KullaniciId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SifremiUnuttum", "KullaniciId", "dbo.Kullanici");
            DropIndex("dbo.SifremiUnuttum", new[] { "KullaniciId" });
            DropTable("dbo.SifremiUnuttum");
        }
    }
}
