using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

		public IActionResult KullaniciGiris()
		{
			return View();
		}


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
