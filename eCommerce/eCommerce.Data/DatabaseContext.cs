using eCommerce.Entities;
using Microsoft.EntityFrameworkCore;


namespace eCommerce.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Urun> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Slider> Sliders { get; set; }

        //Veri tabanı bağlantısı için
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=SEFACIFTCI\MSSQLSERVER3; database=eCommerce; Integrated Security=True; MultipleActiveResultSets=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }


        // fluent api kolon tanımlama (buradaki yapı dikkate alınarak db olusturulur) admin tanımlaması yaptık.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marka>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Adi = "Admin"
            });
            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id = 1,
                Adi = "Admin",
                EklenmeTarihi = DateTime.Now,
                Email = "admin@eCommerce",
                KullaniciAdi = "admin",
                Sifre = "12345",
                RolId = 1,
                Soyadi = "admin",
                TelefonNo = "012345"
            });
            base.OnModelCreating(modelBuilder);
        }




    }
}
