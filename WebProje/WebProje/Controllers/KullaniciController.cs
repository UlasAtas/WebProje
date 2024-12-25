using Microsoft.AspNetCore.Mvc;

namespace WebProje.Controllers
{
	public class KullaniciController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
