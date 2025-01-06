using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace WebProje.Models
{
    public class MyAppContext:DbContext
    {		

		public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
		{
		}

		public DbSet<Kullanici> Kullanici {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tablo adını açıkça belirtelim
            modelBuilder.Entity<Kullanici>().ToTable("Kullanici");
        }
        public DbSet<Siparis> Siparis {  get; set; }
        public DbSet<Urun> Urun {  get; set; }
        public DbSet<Adres> Adres { get; set; }
       // public DbSet<Adres> Adres {  get; set; }

	}
}
