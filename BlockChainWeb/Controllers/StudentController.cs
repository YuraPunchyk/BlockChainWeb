using BlockChainWeb.DbContexts;
using BlockChainWeb.Models;
using BlockChainWeb.Models.HellperClasses;
using BlockChainWeb.Models.Person;
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

		public IActionResult Index ( WebModel model ) {
			Student student = _dbContext.GetStudentById(model.Id);
			model.Student = student;
			return View(model);
		}

		public IActionResult Show (WebModel model) {
			Student student = _dbContext.GetStudentById(model.Id);
			BlockChain blockChain = student.Subjects[model.Subject];
			model.Student=student;
			model.BlockChain = blockChain;
			return View(model);
		}
	}
}