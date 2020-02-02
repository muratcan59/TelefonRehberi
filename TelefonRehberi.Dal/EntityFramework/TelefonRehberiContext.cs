namespace TelefonRehberi.Dal.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using TelefonRehberi.Model;

    public class TelefonRehberiContext : DbContext
    {
        // Your context has been configured to use a 'TelefonRehberiContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TelefonRehberi.Dal.EntityFramework.TelefonRehberiContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TelefonRehberiContext' 
        // connection string in the application configuration file.
        public TelefonRehberiContext()
            : base("name=TelefonRehberiContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TelefonRehberiContext>(new CreateDatabaseIfNotExists<TelefonRehberiContext>()); modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }



        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Rol> Roller { get; set; }

        public virtual DbSet<Calisan> Calisanlar { get; set; }
        public virtual DbSet<Departman> Departmanlar { get; set; }
        public virtual DbSet<Yonetici> Yoneticiler { get; set; }
        public virtual DbSet<SifremiUnuttum> SifremiUnuttumlar { get; set; }
    }


}