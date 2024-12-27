namespace WebProje.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public string ResimUrl { get; set; }
        public int StokMiktari { get; set; }
    }
}
