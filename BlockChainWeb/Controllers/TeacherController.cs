using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockChainWeb.DbContexts;
using BlockChainWeb.Models.Person;
using BlockChainWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BlockChainWeb.Controllers {
	public class TeacherController : Controller {

		private HttpContext _context;
		private DbContext _dbContext;
		public TeacherController ( AppConfiguration appConfiguration , IActionContextAccessor accessor ) {
			_context = accessor.ActionContext.HttpContext;
			_dbContext = new DbContext(appConfiguration.Dbsetting.Connection);
		}
		public IActionResult Index (TeacherViews teacherViews) {
			return View(teacherViews);
		}

		public IActionResult SetValuation(TeacherViews model ) {
			return View(model);
		}

		public IActionResult SetStudentsValuation (SetValuationViews model) {
			return View("SetValuation");
		}

	}
}