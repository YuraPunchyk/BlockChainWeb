using BlockChainWeb.Models.HellperClasses;
using BlockChainWeb.Models.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BlockChainWeb.Controllers {
	public class AdminController : Controller {

		private HttpContext _context;

		public AdminController ( IActionContextAccessor accessor ) {
			_context = accessor.ActionContext.HttpContext;
		}

		public ActionResult Index () {
			return View();
		}

		public ActionResult RegisteredSuccessful () {
			return View();
		}
	}
}