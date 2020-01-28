using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockChainWeb.Models;
using BlockChainWeb.Models.Person;
using BlockChainWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlockChainWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly AdminController _adminController = new AdminController();
        private Teacher Teacher { get; set; }
        private Student Student { get; set; }
        private Admin Admin { get; set; }

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
        public ActionResult Login(LoginViewModel loginViewModel) {
            return RedirectToAction("Admin", "Admin");
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