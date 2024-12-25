using Microsoft.AspNetCore.Mvc;

namespace WebProje.Controllers
{
	public class UrunController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
