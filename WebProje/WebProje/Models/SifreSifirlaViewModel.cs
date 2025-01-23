using System.ComponentModel.DataAnnotations;

namespace WebProje.Models.ViewModels
{
	public class SifreSifirlaViewModel
	{
		[Required(ErrorMessage = "Email alanı zorunludur.")]
		[EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Telefon numarası zorunludur.")]
		[RegularExpression(@"^5\d{9}$", ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
		public string TelNo { get; set; }

		[Required(ErrorMessage = "Yeni şifre zorunludur.")]
		[StringLength(100, MinimumLength = 8, ErrorMessage = "Şifre en az 8 karakter olmalıdır.")]
		public string YeniSifre { get; set; }

		[Required(ErrorMessage = "Şifre tekrar alanı zorunludur.")]
		[Compare("YeniSifre", ErrorMessage = "Şifreler eşleşmiyor.")]
		public string SifreTekrar { get; set; }
	}
}
