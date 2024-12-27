namespace WebProje.Models
{
    public class Siparis
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public string SiparisDurumu { get; set; } = string.Empty;
        public string Aciklama { get; set; } = string.Empty ;
        public string Font {  get; set; } = string.Empty;
        /* Ödeme bilgileri:
        public string OdemeYontemi { get; set; }
        public string OdemeDurumu { get; set; }
        public string IslemNo { get; set; }
        */
    }
}
