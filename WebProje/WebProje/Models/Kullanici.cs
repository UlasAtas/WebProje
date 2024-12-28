using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; } = "";
        public string Soyad { get; set; } = "";
        public string Email { get; set; } = "";
        public string Sifre { get; set; } = "";
        public string Rol { get; set; } = "User"; // Admin veya Kullanici
        public long TelNo { get; set; } 

        public List<Siparis> Siparisler { get; set; }
    }
}
