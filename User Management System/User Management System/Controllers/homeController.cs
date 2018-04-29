using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace User_Management_System.Controllers
{
    public class homeController : Controller
    {
        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult newUser()
        {
            return View();
        }
	}
}