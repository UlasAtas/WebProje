namespace WebProje.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public decimal Fiyat { get; set; } 
        public string Aciklama { get; set; } = string.Empty;
        public string ResimUrl { get; set; } = string.Empty;
        public int StokMiktari { get; set; }
    }
}
