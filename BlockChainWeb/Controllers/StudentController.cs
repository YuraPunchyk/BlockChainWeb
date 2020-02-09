
using BlockChainWeb.DbContexts;
using BlockChainWeb.Models.HellperClasses;
using BlockChainWeb.Models.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BlockChainWeb.Controllers {
	public class StudentController : Controller {
		private Student _student { get; set; }
		private DbContext _dbContext;
		private HttpContext _context;
		public StudentController ( AppConfiguration appConfiguration, IActionContextAccessor accessor ) {
			_dbContext = new DbContext(appConfiguration.Dbsetting.Connection);
			_context = accessor.ActionContext.HttpContext;
		}
		public ActionResult Index (Login login) {
			_student = _dbContext.GetStudentById(login.Id);
			if(_student != null) {
				return View();
			} else {
				return BadRequest();
			}
		}
		public ActionResult Logout () {
			_context.Response.Cookies.Append(Consts.ConstCookieUser, "");
			_context.Response.Cookies.Append(Consts.ConstCookieIpAddress, "");
			return View("../Account/LoginForm");
		}
	}
}