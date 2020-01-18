using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlockChainWeb.Models;
using Microsoft.Extensions.Configuration;

namespace BlockChainWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppConfiguration _appConfiguration;

        public HomeController(ILogger<HomeController> logger,AppConfiguration appConfiguration)
        {
            _logger = logger;
            _appConfiguration = appConfiguration;
        }

        public IActionResult Index()
        {
            return View();
        }

           
    }
}
