using Microsoft.AspNetCore.Mvc;
using WebProje.Models;
using Microsoft.EntityFrameworkCore;

namespace WebProje.Controllers
{
	public class KullaniciController : Controller
	{
		private readonly MyAppContext context;

		public KullaniciController(MyAppContext context)
		{
			this.context = context;
		}

	
		[HttpGet]
		public IActionResult KullaniciKayit()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> KullaniciKayit([Bind("Ad,Soyad,Email,Sifre,SifreTekrar,TelNo")] Kullanici kullanici)
		{
			if (ModelState.IsValid)
			{
				// Email kontrolü
				var mevcutKullanici = await context.Kullanici
					.FirstOrDefaultAsync(k => k.Email == kullanici.Email);

				if (mevcutKullanici != null)
				{
					ModelState.AddModelError("Email", "Bu email adresi zaten kayıtlı.");
					return View(kullanici);
				}

				// Telefon numarası kontrolü
				mevcutKullanici = await context.Kullanici
					.FirstOrDefaultAsync(k => k.TelNo == kullanici.TelNo);

				if (mevcutKullanici != null)
				{
					ModelState.AddModelError("TelNo", "Bu telefon numarası zaten kayıtlı.");
					return View(kullanici);
				}

				// Varsayılan rol ataması
				kullanici.Rol = "Kullanici";

				try
				{
					context.Add(kullanici);
					await context.SaveChangesAsync();

					TempData["Basarili"] = "Hesabınız başarıyla oluşturuldu. Lütfen giriş yapın.";
					return RedirectToAction(nameof(KullaniciGiris));
				}
				catch (Exception hata)
				{
					ModelState.AddModelError("", "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyin.");
				}
			}

			return View(kullanici);
		}

		// Giriş içim
		[HttpGet]
		public IActionResult KullaniciGiris()
		{
			return View();
		}

		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> KullaniciGiris(string email, string sifre)
		{
			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sifre))
			{
				ModelState.AddModelError("", "Lütfen e-posta ve şifre alanlarını doldurunuz.");
				return View();
			}
			var kullanici = await context.Kullanici
				.FirstOrDefaultAsync(k => k.Email == email && k.Sifre == sifre);
			if (kullanici == null)
			{
				ModelState.AddModelError("", "Geçersiz email veya şifre.");
				return View();
			}
			// Oturum bilgilerini kaydet
			HttpContext.Session.SetString("KullaniciId", kullanici.KullaniciId.ToString());
			HttpContext.Session.SetString("KullaniciRol", kullanici.Rol);
			HttpContext.Session.SetString("KullaniciAdi", $"{kullanici.Ad} {kullanici.Soyad}");
			TempData["WelcomeMessage"] = $"Hoş geldiniz, {kullanici.Ad}!";
			return RedirectToAction("Index", "Home");
		}
		// Kullanıcı çıkış işlemi
		public IActionResult OturumKapat()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
		}
	}

}