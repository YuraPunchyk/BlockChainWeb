using System;
using System.Linq;
using BlockChainWeb.Models.Person;
using BlockChainWeb.ViewModels;
using BlockChainWeb.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BlockChainWeb.Models.HellperClasses;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BlockChainWeb.Controllers {
	public class AccountController : Controller {
		private DbContext _dbContext;
		private HttpContext _context;

		public AccountController ( AppConfiguration appConfiguration, IActionContextAccessor context ) {
			_dbContext = new DbContext(appConfiguration.Dbsetting.Connection);
			_context = context.ActionContext.HttpContext;
		}
		[Route("/Account/LoginForm")]
		public ActionResult LoginForm () {
			return View();
		}

		public ActionResult Authentication () {
			string userId = _context.Request.Cookies[Consts.ConstCookieUser];
			string userIpAdress = _context.Request.Cookies[Consts.ConstCookieIpAddress];
			_context.Response.Cookies.Append(Consts.ConstCookieIpAddress, _context.Connection.RemoteIpAddress.ToString());
			
			if(!string.IsNullOrWhiteSpace(userIpAdress)) {
				if(!string.IsNullOrWhiteSpace(userId)) {
					Login login = _dbContext.GetLoginById(userId);
					if(login!=null) {
						if(login.IsAdmin) {
							return View("../Admin/Index", login);
						} else {
							if(login.IsStudent) {
								return View("../Student/Index", login);
							} else {
								if(login.IsTeacher) {
									return View("../Teacher/Index", login);
								}
							}
						}
					}
				}
			}

			return View("LoginForm");
		}

		public ActionResult RegisterStudentForm () {
			return View();
		}

		public ActionResult RegisterTeacherForm () {
			return View();
		}

		[HttpPost]
		public ActionResult Login ( LoginViewModel loginViewModel ) {
			var user = _dbContext.Authentication(loginViewModel.Id, loginViewModel.Password);
			if(user != null) {
				if(user.IsAdmin) {
					_context.Response.Cookies.Append(Consts.ConstCookieUser, user.Id);
					return View("../Admin/Index", user);
				} else {
					if(user.IsStudent) {
						_context.Response.Cookies.Append(Consts.ConstCookieUser, user.Id);
						return View("../Student/Index", user);
					} else {
						if(user.IsTeacher) {
							return View("../Teacher/Index", user);
						}
					}
				}
			}
			return View("NotRegister");
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