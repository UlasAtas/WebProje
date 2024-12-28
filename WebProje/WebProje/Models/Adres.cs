using WebProje.Models;

namespace WebProje.Models
{
    public class Adres
    {
        public int AdresId { get; set; }
        public int KullaniciId { get; set; }
        public string AdresSatiri { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string PostaKodu { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}