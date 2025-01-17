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


		public async Task<IActionResult> UrunListe()
		{
			var urun = await _context.Urun
				.Where(p => p.AktifMi)
				//.OrderByDescending(p => p.CreatedDate)
				.ToListAsync();

			return View(urun);
		}


		[HttpPost]
		public async Task<IActionResult> BuyNow(int id)
		{
			var urun = await _context.Urun.FindAsync(id);
			if (urun == null)
			{
				return NotFound();
			}

			
			return RedirectToAction("Checkout", "Order", new { productId = id });
		}

		public async Task<IActionResult> UrunDetay(int id)
		{
			var urun = await _context.Urun
				.FirstOrDefaultAsync(u => u.UrunId == id && u.AktifMi);

			if (urun == null)
			{
				return NotFound();
			}

			return View(urun);
		}
	}

}

