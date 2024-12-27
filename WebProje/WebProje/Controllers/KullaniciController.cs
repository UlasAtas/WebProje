using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
	public class KullaniciController : Controller
	{
		MyAppContext context=new MyAppContext();
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
			context.Kullanici.Add(kullanici);
			context.SaveChanges();
			return RedirectToAction();
		}

		
	}
}
