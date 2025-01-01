using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Urun
    {
		[Key]
		public int UrunId { get; set; }

		[Required]
		[StringLength(100)]
		public required string UrunAdi { get; set; }

		[StringLength(500)]
		public string? Aciklama { get; set; }

		[Required]
		[Range(0, double.MaxValue)]
		public decimal Fiyat { get; set; }

		public string? ResimUrl { get; set; }

		[Required]
		[Range(0, int.MaxValue)] 
		public int StokMiktari { get; set; }

		public bool AktifMi { get; set; }

		public virtual ICollection<Siparis>? Siparisler { get; set; }

	}
}
