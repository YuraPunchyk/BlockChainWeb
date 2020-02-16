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
								if(student != null) {
									return View("../Student/Index", student);
								} else {
									return BadRequest();
								}
							} else {
								if(login.IsTeacher) {
									WebModel model = GetTeacherModel(login.Id);
									if(model != null) {
										return View("../Teacher/Index", model);
									} else {
										return BadRequest();
									}
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
			RegisterTeacherViewModel model = new RegisterTeacherViewModel();
			model.Subjects = _dbContext.GetSubjects();
			return View(model);
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
						var student = _dbContext.GetStudentById(user.Id);
						WebModel model = new WebModel {
							Student = student
						};
						if(student != null) {
							return View("../Student/Index", model);
						} else {
							return BadRequest();
						}
					} else {
						if(user.IsTeacher) {
							_context.Response.Cookies.Append(Consts.ConstCookieStatus, "3");
							_context.Response.Cookies.Append(Consts.ConstCookieUser, user.Id);
							WebModel model = GetTeacherModel(user.Id);
							if(model != null) {
								return View("../Teacher/Index", model);
							} else {
								return BadRequest();
							}

						}
					}
				}
			}
			return View("NotRegister");
		}

		[HttpPost]
		public IActionResult RegisterTeacher ( RegisterTeacherViewModel model ) {
			Login login = new Login(model.Id, model.Password, false, true, false, "");
			List<Subject> subjects = _dbContext.GetSubjects().Select(x =>x).Where(x=> model.SubjectsId.Contains(x.Id)).ToList();
			Teacher teacher = new Teacher(model.FullName, model.Faculty, subjects, model.Cathedra, model.Id, model.Email);
			_dbContext.SetTeacher(teacher);
			_dbContext.SetLogin(login);
			return View("../Admin/RegisteredSuccessful");
		}

		[HttpPost]
		public IActionResult RegisterStudent ( RegisterStudentViewModel model ) {
			Login login = new Login(model.Id,model.Password,true,false,false,"");
			Dictionary<string,BlockChain> subjects = new Dictionary<string, BlockChain>();
			Student student = new Student(model.FullName, model.Faculty, model.Cathedra, model.Course, model.Group, model.Id, model.Email, subjects);
			_dbContext.SetStudent(student);
			_dbContext.SetLogin(login);
			return View("../Admin/RegisteredSuccessful");
		}

		public IActionResult Logout () {
			_context.Response.Cookies.Append(Consts.ConstCookieUser, "");
			_context.Response.Cookies.Append(Consts.ConstCookieIpAddress, "");
			_context.Response.Cookies.Append(Consts.ConstCookieStatus, "0");
			return View("../Account/LoginForm");
		}

		#region Helper Methods
		public WebModel GetTeacherModel ( string id ) {
			Teacher teacher = _dbContext.GetTeacherById(id);
			List<Group> groups = _dbContext.GetGroups();
			if(teacher != null && groups.Count > 0) {
				return new WebModel {
					Id = teacher.Id,
					Role = Role.Teacher,
					Groups = groups,
					Subjects = teacher.Subjects
				};
			}
			return null;
		}
		#endregion
	}
}