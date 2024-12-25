using Microsoft.AspNetCore.Mvc;

namespace WebProje.Controllers
{
	public class UrunlerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
