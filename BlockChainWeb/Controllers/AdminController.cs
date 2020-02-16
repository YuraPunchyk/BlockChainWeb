using BlockChainWeb.Models.Person;
using Microsoft.AspNetCore.Mvc;

namespace BlockChainWeb.Controllers {
	public class AdminController : Controller {
		public ActionResult Index ( Login login ) {
			return View();
		}

		public ActionResult RegisteredSuccessful () {
			return View();
		}
	}
}