using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly MyAppContext _context;

        public KullaniciController(MyAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }
        // GET: Kullanici/KullaniciGiris
        public IActionResult KullaniciGiris()
        {
            // Eğer kullanıcı zaten giriş yapmışsa ana sayfaya yönlendir
            //if (HttpContext.Session.GetString("Email") != null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View();
        }

        // POST: Kullanici/KullaniciGiris
        [HttpPost]
        public IActionResult KullaniciGiris(string email, string sifre)
        {
            try
            {
                // Email ve şifre boş mu kontrol et
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sifre))
                {
                    ModelState.AddModelError("", "Email ve şifre alanları zorunludur.");
                    return View();
                }

                // Veritabanında kullanıcıyı ara
                var kullanici = _context.Kullanici
                    .FirstOrDefault(k => k.Email == email && k.Sifre == sifre);

                // Kullanıcı bulunamadıysa
                if (kullanici == null)
                {
                    ModelState.AddModelError("", "Geçersiz email veya şifre!");
                    return View();
                }

                // Session'a kullanıcı bilgilerini kaydet
                HttpContext.Session.SetInt32("KullaniciId", kullanici.KullaniciId);
                HttpContext.Session.SetString("Email", kullanici.Email);
                HttpContext.Session.SetString("Ad", kullanici.Ad);
                HttpContext.Session.SetString("Soyad", kullanici.Soyad);
                

                // Eğer admin ise admin paneline yönlendir
                //if (kullanici.AdminMi)
                //{
                //    HttpContext.Session.SetString("AdminMi", "true");
                //    return RedirectToAction("AdminPanel", "Admin");
                //}

                // Normal kullanıcı ise ana sayfaya yönlendir
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                ModelState.AddModelError("", "Giriş işlemi sırasında bir hata oluştu: " + ex.Message);
                return View();
            }
        }

        // Çıkış işlemi için yeni bir action ekleyelim
        public IActionResult Cikis()
        {
            // Tüm session'ları temizle
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        //public IActionResult KullaniciGiris()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult KullaniciGiris(string email, string sifre)
        //{
        //    var Kullanici = _context.Kullanici.FirstOrDefault(u => u.Email == email &&
        //    u.Sifre == sifre);
        //    if (Kullanici != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //         new Claim(ClaimTypes.Name, Kullanici.Email),
        //         new Claim(ClaimTypes.Role, Kullanici.Rol)
        //        };
        //        var identity = new ClaimsIdentity(claims, "CookieAuth");
        //        var principal = new ClaimsPrincipal(identity);
        //        HttpContext.SignInAsync("CookieAuth", principal);

        //        return RedirectToAction("Index", "Home");
        //    }
        //    ViewBag.Error = "Kullanıcı adı veya parola hatalı.";
        //    return View();
        //}


        public IActionResult KullaniciKayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KullaniciKayit(Kullanici kullanici)
        {
            _context.Kullanici.Add(kullanici);
            _context.SaveChanges();
            return RedirectToAction();
        }


    }
}
