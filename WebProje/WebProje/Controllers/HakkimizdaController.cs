using Microsoft.AspNetCore.Mvc;

namespace WebProje.Controllers
{
	public class HakkimizdaController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
