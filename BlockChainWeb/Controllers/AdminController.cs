﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlockChainWeb.Controllers {
	public class AdminController : Controller {
		public ActionResult Admin () {
			return View();
		}
	}
}