using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
	public class SepetUrun
	{		
		public int UrunId { get; set; }
		public string UrunAdi { get; set; }
		public decimal Fiyat { get; set; }
		public int Adet { get; set; }
		public string ResimUrl { get; set; }
		public decimal Toplam => Fiyat * Adet;
	}
}
