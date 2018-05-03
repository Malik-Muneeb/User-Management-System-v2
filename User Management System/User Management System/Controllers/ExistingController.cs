using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_Management_System.Models;

namespace User_Management_System.Controllers
{
    public class ExistingController : Controller
    {
        //
        // GET: /Existing/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user userObj)
        {
            userDAO userObjDao = new userDAO();
            String email=userObjDao.validateUser(userObj);
            if (email!=null)
                return Redirect("/home/home?email=" + email);
            else
            {
                ViewBag.txtLogin = userObj.txtLogin;
                ViewBag.msg = "Incorrect Info";
            }
            return View();
        }

        public ActionResult Reset(String txtEmail)
        {
            int num=emailUtility.SendEmail1(txtEmail);
            ViewBag.code = num;
            ViewBag.email = txtEmail;
            return View();
        }

        public ActionResult match(String txtCode)
        {
            String code = Request["code"];
            if(txtCode==code)
            {
                String email=Request["email"];
                return Redirect("/home/home?email=" + email);
            }
            else
            {
                ViewBag.code = code;
                ViewBag.email = Request["email"];
                ViewBag.msg = "Wrong Code";
                return View("reset");
            }
        }
	}
}