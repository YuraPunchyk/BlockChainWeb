﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlockChainWeb.Controllers {
	public class TeacherController : Controller {
		public IActionResult Index () {
			return View();
		}
	}
}