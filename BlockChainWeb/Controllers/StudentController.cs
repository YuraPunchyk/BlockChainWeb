using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockChainWeb.Models.Person;
using Microsoft.AspNetCore.Mvc;

namespace BlockChainWeb.Controllers
{
    public class StudentController : Controller
    {
        private Student _student { get; set; }
        public StudentController(Student student)
        {
            _student = student;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}