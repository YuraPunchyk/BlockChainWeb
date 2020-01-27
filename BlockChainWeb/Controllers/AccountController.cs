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
        private Teacher Teacher { get; set; }
        private Student Student { get; set; }
        private Admin Admin { get; set; }

        public ActionResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel){
            return View();
        }

        [HttpPost]
        public ActionResult RegisterTeacher(RegisterTeacherViewModel registerTeacherViewModel){
            return View();
        }

        [HttpPost]
        public ActionResult RegisterStudent(RegisterStudentViewModel registerStudentViewModel)
        {
            return View();
        }
    }
}