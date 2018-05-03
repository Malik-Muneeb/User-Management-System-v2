using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_Management_System.Models;

namespace User_Management_System.Controllers
{
    public class adminController : Controller
    {
        //
        // GET: /admin/
        public ActionResult Login()
        {
            return View();
        }

       // [ActionName("Login")]
        [HttpPost]
        public ActionResult Login(admin adminObj)
        {
            adminDAO adminObjDao=new adminDAO();
            if (adminObjDao.validateAdmin(adminObj))
                return Redirect("/admin/home");
            else
            {
                ViewBag.txtLogin = adminObj.txtLogin;
                ViewBag.msg = "Incorrect Info";
            }
            return View();
        }

        public ActionResult home()
        {
            userDAO userObjDao = new userDAO();
            List<user> userList = userObjDao.getAllUsers();
            ViewBag.userList = userList;
            return View();
        }
	}
}