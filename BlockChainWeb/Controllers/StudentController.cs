using BlockChainWeb.DbContexts;
using BlockChainWeb.Models.HellperClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BlockChainWeb.Controllers {
	public class StudentController : Controller {
		#region Private Veriables
		private DbContext _dbContext;
		private HttpContext _context;
		#endregion

		public StudentController ( AppConfiguration appConfiguration, IActionContextAccessor accessor ) {
			_dbContext = new DbContext(appConfiguration.Dbsetting.Connection);
			_context = accessor.ActionContext.HttpContext;
		}

		public IActionResult Index () {
			return View();
		}

		public IActionResult Logout () {
			_context.Response.Cookies.Append(Consts.ConstCookieUser, "");
			_context.Response.Cookies.Append(Consts.ConstCookieIpAddress, "");
			_context.Response.Cookies.Append(Consts.ConstCookieStatus, "0");
			return View("../Account/LoginForm");
		}
	}
}