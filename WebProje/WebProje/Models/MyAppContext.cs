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
            optionsBuilder.UseSqlServer("server = KONTEVS\\SQLEXPRESS; DataBase = WebProjeDB; Trusted_Connection = True; TrustServerCertificate = True");
        }

    }
}
