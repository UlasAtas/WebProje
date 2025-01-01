using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Kullanici
    {
		[Key]
		public int KullaniciId { get; set; }

		[Required(ErrorMessage = "Ad alanı zorunludur.")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Ad 2-50 karakter arasında olmalıdır.")]
		public required string Ad { get; set; }

		[Required(ErrorMessage = "Soyad alanı zorunludur.")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Soyad 2-50 karakter arasında olmalıdır.")]
		public required string Soyad { get; set; }

		[Required(ErrorMessage = "Email alanı zorunludur.")]
		[EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
		[StringLength(100)]
		public required string Email { get; set; }

		[Required(ErrorMessage = "Şifre alanı zorunludur.")]
		[StringLength(100, MinimumLength = 8, ErrorMessage = "Şifre en az 8 karakter uzunluğunda olmalıdır.")]
		public required string Sifre { get; set; } 

		[Required]
		public string Rol { get; set; } = "User"; // Admin veya Kullanici

		[Required(ErrorMessage = "Telefon numarası zorunludur.")]
		[Range(5000000000, 5999999999, ErrorMessage = "Geçerli bir telefon numarası giriniz (5xx xxx xx xx formatında).")]
		[RegularExpression(@"^\d{11}$")]
		public required long TelNo { get; set; }

		public virtual ICollection<Siparis>? Siparisler { get; set; }
		public virtual ICollection<Adres>? Adresler { get; set; }
	}
}
