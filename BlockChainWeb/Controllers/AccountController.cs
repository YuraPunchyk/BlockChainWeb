using BlockChainWeb.Models.Person;
using BlockChainWeb.ViewModels;
using BlockChainWeb.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BlockChainWeb.Models.HellperClasses;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using BlockChainWeb.Models;
using BlockChainWeb.Models.Education;
using System.Linq;
using System;

namespace BlockChainWeb.Controllers {
	public class AccountController : Controller {
		#region Private Veriables
		private DbContext _dbContext;
		private HttpContext _context;
		private IActionContextAccessor _accessor;
		private AppConfiguration _appConfiguration;
		#endregion

		public AccountController ( AppConfiguration appConfiguration, IActionContextAccessor accessor ) {
			_dbContext = new DbContext(appConfiguration.Dbsetting.Connection);
			_context = accessor.ActionContext.HttpContext;
			_accessor = accessor;
			_appConfiguration = appConfiguration;
		}
		public IActionResult LoginForm () {
			return View();
		}

		public RedirectToRouteResult Authentication () {
			string userId = _context.Request.Cookies[Consts.ConstCookieUser];
			if(!string.IsNullOrWhiteSpace(userId)) {
				Login login = _dbContext.GetLoginById(userId);
				if(login != null) {
					if(login.IsAdmin) {
						return RedirectToRoute(new {
							controller = "Admin",
							action = "Index"
						});
					} else {
						if(login.IsStudent) {
							_dbContext.SetSesion(new Sesion() {Guid = new Guid(), IdUer = login.Id });
							return RedirectToRoute(new {
								controller = "Student",
								action = "Index"
							});
						} else {
							if(login.IsTeacher) {
								_dbContext.SetSesion(new Sesion() { Guid = new Guid(), IdUer = login.Id });
								return RedirectToRoute(new {
									controller = "Teacher",
									action = "Index"
								});
							}
						}
					}
				}
			}
			return RedirectToRoute(new {
				controller = "Account",
				action = "LoginForm"
			});
		}

		public IActionResult RegisterStudentForm () {
			return View();
		}

		public IActionResult RegisterTeacherForm () {
			RegisterTeacherViewModel model = new RegisterTeacherViewModel();
			model.Subjects = _dbContext.GetSubjects();
			return View(model);
		}

		[HttpPost]
		public RedirectToRouteResult Login ( LoginViewModel loginViewModel ) {
			var user = _dbContext.Authentication(loginViewModel.Id, loginViewModel.Password);
			if(user != null) {
				if(user.IsAdmin) {
					_context.Response.Cookies.Append(Consts.ConstCookieStatus, "1");
					_context.Response.Cookies.Append(Consts.ConstCookieUser, user.Id);
					return RedirectToRoute(new {
						controller = "Admin",
						action = "Index"
					});
				} else {
					if(user.IsStudent) {
						_context.Response.Cookies.Append(Consts.ConstCookieStatus, "2");
						_context.Response.Cookies.Append(Consts.ConstCookieUser, user.Id);
						var student = _dbContext.GetStudentById(user.Id);
						_dbContext.SetSesion(new Sesion() { Guid = new Guid(), IdUer = user.Id });
						return RedirectToRoute(new {
							controller = "Student",
							action = "Index"
						});
					} else {
						if(user.IsTeacher) {
							_context.Response.Cookies.Append(Consts.ConstCookieStatus, "3");
							_context.Response.Cookies.Append(Consts.ConstCookieUser, user.Id);
							_dbContext.SetSesion(new Sesion() { Guid = new Guid(), IdUer = user.Id });
							return RedirectToRoute(new {
								controller = "Teacher",
								action = "Index"
							});
						}
					}
				}
			}
			return RedirectToRoute(new {
				controller = "Account",
				action = "NotRegister"
			});
		}

		[HttpPost]
		public RedirectToRouteResult RegisterTeacher ( RegisterTeacherViewModel model ) {
			Login login = new Login(model.Id, model.Password, false, true, false, "");
			List<Subject> subjects = _dbContext.GetSubjects().Select(x => x).Where(x => model.SubjectsId.Contains(x.Id)).ToList();
			Teacher teacher = new Teacher(model.FullName, model.Faculty, subjects, model.Cathedra, model.Id, model.Email);
			_dbContext.SetTeacher(teacher);
			_dbContext.SetLogin(login);
			return RedirectToRoute(new {
				controller = "Admin",
				action = "RegisteredSuccessful"
			});
		}

		[HttpPost]
		public RedirectToRouteResult RegisterStudent ( RegisterStudentViewModel model ) {
			Login login = new Login(model.Id, model.Password, true, false, false, "");
			Dictionary<string, BlockChain> subjects = new Dictionary<string, BlockChain>();
			Student student = new Student(model.FullName, model.Faculty, model.Cathedra, model.Course, model.Group, model.Id, model.Email, subjects);
			_dbContext.SetStudent(student);
			_dbContext.SetLogin(login);
			return RedirectToRoute(new {
				controller = "Admin",
				action = "RegisteredSuccessful"
			});
		}

		public RedirectToRouteResult Logout () {
			_context.Response.Cookies.Append(Consts.ConstCookieUser, "");
			_context.Response.Cookies.Append(Consts.ConstCookieIpAddress, "");
			_context.Response.Cookies.Append(Consts.ConstCookieStatus, "0");
			_dbContext.DeleteSesions();
			return RedirectToRoute(new {
				controller = "Account",
				action = "LoginForm"
			});
		}
	}
}