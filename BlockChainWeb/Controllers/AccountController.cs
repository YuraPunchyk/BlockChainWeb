using System;
using System.Linq;
using BlockChainWeb.Models.Person;
using BlockChainWeb.ViewModels;
using BlockChainWeb.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BlockChainWeb.Models.HellperClasses;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;

namespace BlockChainWeb.Controllers {
	public class AccountController : Controller {
		private DbContext _dbContext;
		private HttpContext _context;
		private IActionContextAccessor _accessor;
		private AppConfiguration _appConfiguration;

		public AccountController ( AppConfiguration appConfiguration, IActionContextAccessor accessor ) {
			_dbContext = new DbContext(appConfiguration.Dbsetting.Connection);
			_context = accessor.ActionContext.HttpContext;
			_accessor = accessor;
			_appConfiguration = appConfiguration;
		}
		[Route("/Account/LoginForm")]
		public IActionResult LoginForm () {
			return View();
		}

		public IActionResult Authentication () {
			string userId = _context.Request.Cookies[Consts.ConstCookieUser];
			string userIpAdress = _context.Request.Cookies[Consts.ConstCookieIpAddress];
			_context.Response.Cookies.Append(Consts.ConstCookieIpAddress, _context.Connection.RemoteIpAddress.ToString());

			if(!string.IsNullOrWhiteSpace(userIpAdress)) {
				if(!string.IsNullOrWhiteSpace(userId)) {
					Login login = _dbContext.GetLoginById(userId);
					if(login != null) {
						if(login.IsAdmin) {
							return View("../Admin/Index");
						} else {
							if(login.IsStudent) {
								var student = _dbContext.GetStudentById(login.Id);
								return View("../Student/Index", student);
							} else {
								if(login.IsTeacher) {
									return View("../Teacher/Index", GetTeacherViews(login.Id));
								}
							}
						}
					}
				}
			}

			return View("LoginForm");
		}

		public IActionResult RegisterStudentForm () {
			return View();
		}

		public IActionResult RegisterTeacherForm () {
			return View();
		}

		[HttpPost]
		public IActionResult Login ( LoginViewModel loginViewModel ) {
			var user = _dbContext.Authentication(loginViewModel.Id, loginViewModel.Password);
			if(user != null) {
				if(user.IsAdmin) {
					_context.Response.Cookies.Append(Consts.ConstCookieStatus, "1");
					_context.Response.Cookies.Append(Consts.ConstCookieUser, user.Id);
					return View("../Admin/Index");
				} else {
					if(user.IsStudent) {
						_context.Response.Cookies.Append(Consts.ConstCookieStatus, "2");
						_context.Response.Cookies.Append(Consts.ConstCookieUser, user.Id);
						return View("../Student/Index", _dbContext.GetStudentById(user.Id));
					} else {
						if(user.IsTeacher) {
							_context.Response.Cookies.Append(Consts.ConstCookieStatus, "2");
							_context.Response.Cookies.Append(Consts.ConstCookieUser, user.Id);
							return View("../Teacher/Index", GetTeacherViews(user.Id));
						}
					}
				}
			}
			return View("NotRegister");
		}

		[HttpPost]
		public IActionResult RegisterTeacher ( RegisterTeacherViewModel registerTeacherViewModel ) {
			return RedirectToAction("Admin", "Admin");
		}

		[HttpPost]
		public IActionResult RegisterStudent ( RegisterStudentViewModel registerStudentViewModel ) {
			return RedirectToAction("Admin", "Admin");
		}

		#region Helper Methods
		public TeacherViews GetTeacherViews ( string id ) {
			Teacher teacher = _dbContext.GetTeacherById(id);
			List<int> groups = _dbContext.GetGroups();
			return new TeacherViews {
				Teacher = teacher,
				Groups = groups
			};
		}
		#endregion
	}
}