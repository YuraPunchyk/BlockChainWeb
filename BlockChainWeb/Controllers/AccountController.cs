using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockChainWeb.Models;
using BlockChainWeb.Models.Person;
using BlockChainWeb.ViewModels;
using BlockChainWeb.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BlockChainWeb.Controllers {
	public class AccountController : Controller {
		private DbContext _dbContext;
		private HttpContext _context;

		public AccountController ( AppConfiguration appConfiguration, HttpContext context ) {
			_dbContext = new DbContext(appConfiguration.Dbsetting.Connection);
			_context = context;
		}
		[Route("/Account/LoginForm")]
		public ActionResult LoginForm () {
			return View();
		}

		public ActionResult Authentication () {
			return View();
		}

		public ActionResult RegisterStudentForm () {
			return View();
		}

		public ActionResult RegisterTeacherForm () {
			return View();
		}

		[HttpPost]
		public void Login ( LoginViewModel loginViewModel ) {
			var user = _dbContext.Authentication(loginViewModel.Id, loginViewModel.Password);
			if(user != null) {
				if(user.IsStudent) {
					var student = _dbContext.GetStudentById(user.Id);
				}
			}
		}

		[HttpPost]
		public ActionResult RegisterTeacher ( RegisterTeacherViewModel registerTeacherViewModel ) {
			return RedirectToAction("Admin", "Admin");
		}

		[HttpPost]
		public ActionResult RegisterStudent ( RegisterStudentViewModel registerStudentViewModel ) {
			return RedirectToAction("Admin", "Admin");
		}
	}
}