using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Extensions;
using WebProje.Models;

namespace WebProje.Controllers
{
	public class SepetController : Controller
	{

		private readonly MyAppContext _context;

		public SepetController(MyAppContext context)
		{
			_context = context;
		}

		
		private const string CartSessionKey = "Cart";

		

		public IActionResult Index()
		{
			var cart = HttpContext.Session.GetJson<Sepet>(CartSessionKey) ?? new Sepet();
			return View(cart);
		}

		[HttpPost]
		public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
		{
			if (HttpContext.Session.GetString("KullaniciId") == null)
			{
				return RedirectToAction("KullaniciGiris", "Kullanici");
			}

			var urun = await _context.Urun
			.FirstOrDefaultAsync(u => u.UrunId == productId);

			if (urun == null)
			{
				return NotFound();
			}

			var cart = HttpContext.Session.GetJson<Sepet>(CartSessionKey) ?? new Sepet();
			var cartItem = cart.Urunler.FirstOrDefault(item => item.UrunId == productId);

			if (cartItem != null)
			{
				cartItem.Adet += quantity;
			}
			else
			{
				cart.Urunler.Add(new SepetUrun
				{
					UrunId = urun.UrunId,
					UrunAdi = urun.UrunAdi,
					Fiyat = urun.Fiyat,
					ResimUrl = urun.ResimUrl ?? string.Empty,
					Adet = quantity
				});
			}

			HttpContext.Session.SetJson(CartSessionKey, cart);
			return RedirectToAction("UrunListe","Urun");
		}

		[HttpPost]
		public IActionResult UpdateQuantity(int productId, int quantity)
		{
			var cart = HttpContext.Session.GetJson<Sepet>(CartSessionKey);

			if (cart == null)
				return NotFound();

			var cartItem = cart.Urunler.FirstOrDefault(item => item.UrunId == productId);

			if (cartItem == null)
				return NotFound();

			if (quantity <= 0)
			{
				cart.Urunler.Remove(cartItem);
			}
			else
			{
				cartItem.Adet = quantity;
			}

			HttpContext.Session.SetJson(CartSessionKey, cart);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult RemoveFromCart(int productId)
		{
			var cart = HttpContext.Session.GetJson<Sepet>(CartSessionKey);

			if (cart == null)
				return NotFound();

			var cartItem = cart.Urunler.FirstOrDefault(item => item.UrunId == productId);

			if (cartItem != null)
			{
				cart.Urunler.Remove(cartItem);
				HttpContext.Session.SetJson(CartSessionKey, cart);
			}

			return RedirectToAction("Index");
		}

		public IActionResult ClearCart()
		{
			HttpContext.Session.Remove(CartSessionKey);
			return RedirectToAction("Index");
		}



	}
}
