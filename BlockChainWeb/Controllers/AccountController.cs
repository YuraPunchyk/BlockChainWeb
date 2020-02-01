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

namespace BlockChainWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly AdminController _adminController = new AdminController();
        private Teacher Teacher { get; set; }
        private Student Student { get; set; }
        private Admin Admin { get; set; }
        
        private DbContext _dbContext;
        private IHttpContextAccessor _accessor;
        
        public AccountController(IHttpContextAccessor accessor,AppConfiguration appConfiguration)
        {
            _accessor = accessor;
            _dbContext = new DbContext(appConfiguration.Dbsetting.Connection);
        }
        public ActionResult LoginForm() {
            return View();
        }

        public ActionResult RegisterStudentForm() {
            return View();
        }
        
        public ActionResult RegisterTeacherForm() {
            return View();
        }

        [HttpPost]
        public void Login(LoginViewModel loginViewModel) {
            var user = _dbContext.Authentication(loginViewModel.Id, loginViewModel.Password);
            if(user!=null)
            {
                if(user.IsStudent)
                {
                    var student = _dbContext.GetStudentById(user.Id);
                }
            }
        }

        [HttpPost]
        public ActionResult RegisterTeacher(RegisterTeacherViewModel registerTeacherViewModel) {
            return RedirectToAction("Admin", "Admin");
        }

        [HttpPost]
        public ActionResult RegisterStudent(RegisterStudentViewModel registerStudentViewModel) {
            return RedirectToAction("Admin", "Admin");
        }
    }
}