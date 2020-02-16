using System;
using BlockChainWeb.DbContexts;
using BlockChainWeb.Models;
using BlockChainWeb.Models.HellperClasses;
using BlockChainWeb.Models.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BlockChainWeb.Controllers {
	public class TeacherController : Controller {
		#region Private Veriables
		private HttpContext _context;
		private DbContext _dbContext;
		#endregion

		public TeacherController ( AppConfiguration appConfiguration, IActionContextAccessor accessor ) {
			_context = accessor.ActionContext.HttpContext;
			_dbContext = new DbContext(appConfiguration.Dbsetting.Connection);
		}
		public IActionResult Index ( WebModel model ) {
			return View(model);
		}

		public IActionResult SetValuation ( WebModel model ) {
			return View(model);
		}

		public IActionResult SetStudentsValuation ( WebModel model ) {
			Teacher teacher = _dbContext.GetTeacherById(model.Id);
			Valuation valuation = new Valuation(teacher, model.Amount, model.Description);
			Block block = new Block(DateTime.Now, null, valuation);
			foreach(string id in model.StudentIds) {
				Student student = _dbContext.GetStudentById(id);
				foreach(var subject in student.Subjects) {
					if(subject.Subject == model.Subject) {
						subject.AddBlock(block);
						_dbContext.UpdateStudent(student);
					}
				}
			}
			return View("SetValuation");
		}

		public IActionResult Logout () {
			_context.Response.Cookies.Append(Consts.ConstCookieUser, "");
			_context.Response.Cookies.Append(Consts.ConstCookieIpAddress, "");
			_context.Response.Cookies.Append(Consts.ConstCookieStatus, "0");
			return View("../Account/LoginForm");
		}
	}
}