namespace WebProje.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; } // Admin veya Kullanici
        public List<Siparis> Siparisler { get; set; }
    }
}
