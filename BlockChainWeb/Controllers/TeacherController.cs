using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockChainWeb.DbContexts;
using BlockChainWeb.Models.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BlockChainWeb.Controllers {
	public class TeacherController : Controller {

		private HttpContext _context;
		private List<Student> _students;
		private DbContext _dbContext;
		public TeacherController ( AppConfiguration appConfiguration , IActionContextAccessor accessor ) {
			_context = accessor.ActionContext.HttpContext;
			_dbContext = new DbContext(appConfiguration.Dbsetting.Connection);
		}
		public IActionResult Index () {
			return View();
		}
	}
}