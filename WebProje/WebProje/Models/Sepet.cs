using System.Xml.Serialization;

namespace WebProje.Models
{
	public class Sepet
	{
		
		public List<SepetUrun> Urunler { get; set; } = new List<SepetUrun>();
		public decimal TotalAmount => Urunler.Sum(item => item.Toplam);

	}
}
