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

				var mevcutKullanici = await context.Kullanici
					.FirstOrDefaultAsync(k => k.Email == kullanici.Email);

				if (mevcutKullanici != null)
				{
					ModelState.AddModelError("Email", "Bu email adresi zaten kayıtlı.");
					return View(kullanici);
				}


				mevcutKullanici = await context.Kullanici
					.FirstOrDefaultAsync(k => k.TelNo == kullanici.TelNo);

				if (mevcutKullanici != null)
				{
					ModelState.AddModelError("TelNo", "Bu telefon numarası zaten kayıtlı.");
					return View(kullanici);
				}


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

			HttpContext.Session.SetString("KullaniciId", kullanici.KullaniciId.ToString());
			HttpContext.Session.SetString("KullaniciRol", kullanici.Rol);
			HttpContext.Session.SetString("KullaniciAdi", $"{kullanici.Ad} {kullanici.Soyad}");
			TempData["Mesaj"] = $"Hoş geldiniz, {kullanici.Ad}!";
			return RedirectToAction("Index", "Home");
		}

		public IActionResult OturumKapat()
		{
			HttpContext.Session.Clear();
			TempData["Mesaj"] = "Başarıyla çıkış yaptınız.";
			return RedirectToAction("Index", "Home");
		}


		//aAYARLAR
		
		public async Task<IActionResult> Ayarlar()
		{
			if (!HttpContext.Session.TryGetValue("KullaniciId", out byte[] kullaniciIdBytes))
			{
				return RedirectToAction("KullaniciGiris");
			}

			int kullaniciId = int.Parse(System.Text.Encoding.UTF8.GetString(kullaniciIdBytes));


			var kullanici = await context.Kullanici
				.Include(k => k.Adres)  
				.FirstOrDefaultAsync(k => k.KullaniciId == kullaniciId);

			if (kullanici == null)
			{
				return RedirectToAction("KullaniciGiris");
			}

			return View(kullanici);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Ayarlar(Kullanici model)
		{
			try
			{
				var kullanici = await context.Kullanici
					.Include(k => k.Adres)
					.FirstOrDefaultAsync(k => k.KullaniciId == model.KullaniciId);

				if (kullanici == null)
				{
					TempData["Hata"] = "Kullanıcı bulunamadı.";
					return View(model);
				}

				if (string.IsNullOrEmpty(model.Ad) || string.IsNullOrEmpty(model.Soyad) ||
					string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.TelNo))
				{
					TempData["Hata"] = "Lütfen tüm alanları doldurun.";
					return View(model);
				}

				kullanici.Ad = model.Ad;
				kullanici.Soyad = model.Soyad;
				kullanici.Email = model.Email;
				kullanici.TelNo = model.TelNo;

				context.Update(kullanici); 


				if (model.Adres != null)
				{
					if (kullanici.Adres == null)
					{
						var yeniAdres = new Adres
						{
							KullaniciId = kullanici.KullaniciId,
							AdresSatiri = model.Adres.AdresSatiri,
							Il = model.Adres.Il,
							Ilce = model.Adres.Ilce,
							PostaKodu = model.Adres.PostaKodu
						};
						context.Adres.Add(yeniAdres); 
					}
					else
					{
						kullanici.Adres.AdresSatiri = model.Adres.AdresSatiri;
						kullanici.Adres.Il = model.Adres.Il;
						kullanici.Adres.Ilce = model.Adres.Ilce;
						kullanici.Adres.PostaKodu = model.Adres.PostaKodu;
						context.Update(kullanici.Adres);
					}
				}

				await context.SaveChangesAsync();
				TempData["Mesaj"] = "Bilgileriniz başarıyla güncellendi.";
				return RedirectToAction(nameof(Ayarlar));
			}
			catch (Exception ex)
			{
				TempData["Hata"] = "Güncelleme sırasında bir hata oluştu: " + ex.Message;
				return View(model);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AdresGuncelle(Adres adres)
		{
			try
			{
				var kullanici = await context.Kullanici
					.Include(k => k.Adres)
					.FirstOrDefaultAsync(k => k.KullaniciId == adres.KullaniciId);

				if (kullanici == null)
				{
					TempData["Hata"] = "Kullanıcı bulunamadı.";
					return RedirectToAction(nameof(Ayarlar));
				}

				if (kullanici.Adres == null)
				{
					var yeniAdres = new Adres
					{
						KullaniciId = kullanici.KullaniciId,
						AdresSatiri = adres.AdresSatiri,
						Il = adres.Il,
						Ilce = adres.Ilce,
						PostaKodu = adres.PostaKodu
					};
					context.Adres.Add(yeniAdres);
				}
				else
				{			
					kullanici.Adres.AdresSatiri = adres.AdresSatiri;
					kullanici.Adres.Il = adres.Il;
					kullanici.Adres.Ilce = adres.Ilce;
					kullanici.Adres.PostaKodu = adres.PostaKodu;
					context.Update(kullanici.Adres);
				}

				await context.SaveChangesAsync();
				TempData["Mesaj"] = "Adres bilgileri başarıyla güncellendi.";
				return RedirectToAction(nameof(Ayarlar));
			}
			catch (Exception ex)
			{
				TempData["Hata"] = "Adres güncellenirken bir hata oluştu: " + ex.Message;
				return RedirectToAction(nameof(Ayarlar));
			}
		}
	}

}



