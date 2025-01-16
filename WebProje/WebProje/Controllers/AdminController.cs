using Microsoft.AspNetCore.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyAppContext _context;

        public AdminController(MyAppContext context)
        {
            _context = context;
        }

        // Admin girişini kontrol eden bir attribute oluşturalım
        private bool IsAdmin()
        {
            var kullaniciRol = HttpContext.Session.GetString("KullaniciRol");
            return kullaniciRol == "Admin";
        }

        // Admin Panel Ana Sayfa
        public IActionResult Index()
        {
            if (!IsAdmin())
                return RedirectToAction("KullaniciGiris", "Kullanici");

            return View();
        }

        // Ürün Listesi
        public IActionResult UrunYonetimi()
        {
            if (!IsAdmin())
                return RedirectToAction("KullaniciGiris", "Kullanici");

            var urunler = _context.Urun.ToList();
            return View(urunler);
        }

        // Yeni Ürün Ekleme - GET
        public IActionResult UrunEkle()
        {
            if (!IsAdmin())
                return RedirectToAction("KullaniciGiris", "Kullanici");

            return View();
        }

        // Yeni Ürün Ekleme - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UrunEkle(Urun urun)
        {
            if (!IsAdmin())
                return RedirectToAction("KullaniciGiris", "Kullanici");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(urun);
                    await _context.SaveChangesAsync();
                    TempData["Basarili"] = "Ürün başarıyla eklendi.";
                    return RedirectToAction(nameof(UrunYonetimi));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ürün eklenirken bir hata oluştu: " + ex.Message);
                }
            }
            return View(urun);
        }

        // Ürün Silme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UrunSil(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("KullaniciGiris", "Kullanici");

            var urun = await _context.Urun.FindAsync(id);
            if (urun != null)
            {
                try
                {
                    _context.Urun.Remove(urun);
                    await _context.SaveChangesAsync();
                    TempData["Basarili"] = "Ürün başarıyla silindi.";
                }
                catch (Exception ex)
                {
                    TempData["Hata"] = "Ürün silinirken bir hata oluştu: " + ex.Message;
                }
            }
            return RedirectToAction(nameof(UrunYonetimi));
        }
    }
}