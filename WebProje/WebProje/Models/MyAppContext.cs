using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace WebProje.Models
{
    public class MyAppContext:DbContext
    {
        public DbSet<Kullanici> Kullanici {  get; set; }
        public DbSet<Siparis> Siparis {  get; set; }
        public DbSet<Urun> Urun {  get; set; }
       // public DbSet<Adres> Adres {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			optionsBuilder.UseSqlServer("Server=Caner\\SQLEXPRESS;Database=WebProjeDB;User Id=sa;Password=Caner12345;TrustServerCertificate=True;");

		}

	}
}
