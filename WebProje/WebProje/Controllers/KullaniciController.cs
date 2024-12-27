using Microsoft.AspNetCore.Mvc;

namespace WebProje.Controllers
{
	public class KullaniciController : Controller
	{
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

		
	}
}
