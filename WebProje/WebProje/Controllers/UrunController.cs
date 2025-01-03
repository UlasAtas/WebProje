using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
	public class UrunController : Controller
	{
        private readonly MyAppContext _context;

        public UrunController(MyAppContext context)
        {
            _context = context;
        }
        public IActionResult UrunDetay()
		{
			return View();
		}

		public IActionResult UrunListe()
        {
            

            var urunler = _context.Urun;
            //.Where(u => u.AktifMi)
            //.OrderByDescending(u => u.OlusturmaTarihi).ToList();

            return View(urunler);
        }
        
        

    }
}
