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
        public DbSet<Siparis> Siparis {  get; set; }
        public DbSet<Urun> Urun {  get; set; }
       // public DbSet<Adres> Adres {  get; set; }

	}
}
