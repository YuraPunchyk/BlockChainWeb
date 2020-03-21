using System;
using System.Collections.Generic;
using BlockChainWeb.DbContexts;
using BlockChainWeb.Models;
using BlockChainWeb.Models.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Linq;
using BlockChainWeb.Models.Education;

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
			List<Student> students = _dbContext.GetStudentsByGroup(model.Group);
			List<Group> groups = _dbContext.GetGroups();
			Teacher teacher = _dbContext.GetTeacherById(model.Id);
			model.Subjects = teacher.Subjects;
			model.Students = students;
			model.Groups = groups;
			return View(model);
		}

		public IActionResult ShowValuation(WebModel model ) {
			List<Student> students = _dbContext.GetStudentsByGroup(model.Group);
			Subject subject = _dbContext.GetSubjectByName(model.Subject);
			model.SubjectModel = subject;
			model.Students = students;
			return View(model);
		}

		public IActionResult SetStudentsValuation ( WebModel model ) {
			Teacher teacher = _dbContext.GetTeacherById(model.Id);
			Valuation valuation = new Valuation(teacher, model.Amount, model.Description);
			Block block = new Block(DateTime.Now, null, valuation);
			string subjectName = model.Subject;
			foreach(string id in model.StudentIds) {
				Student student = _dbContext.GetStudentById(id);
				if(student.Subjects.Count > 0) {
					foreach(var subject in student.Subjects.Values) {
						if(subject.Subject == subjectName) {
							student.Subjects[subjectName].AddBlock(block);
							_dbContext.UpdateStudent(student);
						} else {
							BlockChain blockChain = new BlockChain(subjectName);
							blockChain.AddBlock(block);
							student.Subjects.Add(subjectName, blockChain);
							_dbContext.UpdateStudent(student);
						}
					}
				} else {
					BlockChain blockChain = new BlockChain(subjectName);
					blockChain.AddBlock(block);
					student.Subjects.Add(subjectName, blockChain);
					_dbContext.UpdateStudent(student);
				}
			}
			List<Student> students = _dbContext.GetStudentsByGroup(model.Group);
			List<Group> groups = _dbContext.GetGroups();
			model.Students = students;
			model.Subjects = teacher.Subjects;
			model.Groups = groups;
			return View("../Teacher/SetValuation", model);
		}

		[HttpGet]
		public ActionResult BrowserGoToBack () {
			return View("../Account/Authentication");
		}
	}
}