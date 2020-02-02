namespace TelefonRehberi.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v30 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departman",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        KayitTarihi = c.DateTime(nullable: false),
                        SilindiMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kullanici",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(nullable: false, maxLength: 50),
                        Tel = c.String(),
                        Email = c.String(nullable: false),
                        Sifre = c.String(nullable: false),
                        KayitTarihi = c.DateTime(nullable: false),
                        SilindiMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        KayitTarihi = c.DateTime(nullable: false),
                        SilindiMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Yonetici",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CalisanId = c.Int(nullable: false),
                        KayitTarihi = c.DateTime(nullable: false),
                        SilindiMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Calisan", t => t.CalisanId, cascadeDelete: true)
                .Index(t => t.CalisanId);
            
            CreateTable(
                "dbo.Calisan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(nullable: false),
                        Tel = c.String(),
                        DepartmanId = c.Int(),
                        YoneticiId = c.Int(),
                        KayitTarihi = c.DateTime(nullable: false),
                        SilindiMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departman", t => t.DepartmanId)
                .ForeignKey("dbo.Calisan", t => t.YoneticiId)
                .Index(t => t.DepartmanId)
                .Index(t => t.YoneticiId);
            
            CreateTable(
                "dbo.RolKullanici",
                c => new
                    {
                        Rol_Id = c.Int(nullable: false),
                        Kullanici_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rol_Id, t.Kullanici_Id })
                .ForeignKey("dbo.Rol", t => t.Rol_Id, cascadeDelete: true)
                .ForeignKey("dbo.Kullanici", t => t.Kullanici_Id, cascadeDelete: true)
                .Index(t => t.Rol_Id)
                .Index(t => t.Kullanici_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yonetici", "CalisanId", "dbo.Calisan");
            DropForeignKey("dbo.Calisan", "YoneticiId", "dbo.Calisan");
            DropForeignKey("dbo.Calisan", "DepartmanId", "dbo.Departman");
            DropForeignKey("dbo.RolKullanici", "Kullanici_Id", "dbo.Kullanici");
            DropForeignKey("dbo.RolKullanici", "Rol_Id", "dbo.Rol");
            DropIndex("dbo.RolKullanici", new[] { "Kullanici_Id" });
            DropIndex("dbo.RolKullanici", new[] { "Rol_Id" });
            DropIndex("dbo.Calisan", new[] { "YoneticiId" });
            DropIndex("dbo.Calisan", new[] { "DepartmanId" });
            DropIndex("dbo.Yonetici", new[] { "CalisanId" });
            DropTable("dbo.RolKullanici");
            DropTable("dbo.Calisan");
            DropTable("dbo.Yonetici");
            DropTable("dbo.Rol");
            DropTable("dbo.Kullanici");
            DropTable("dbo.Departman");
        }
    }
}
