using Microsoft.AspNetCore.Mvc;

namespace BlockChainWeb.Controllers {
	public class AccessController : Controller {
		public IActionResult Index () {
			return View();
		}
	}
}