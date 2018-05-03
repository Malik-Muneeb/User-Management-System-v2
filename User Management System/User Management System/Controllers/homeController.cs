using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_Management_System.Models;

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

        //[ActionName("newUser")]
        [HttpPost]
        public ActionResult newUser(user obj)
        {
            if (Request.Files["userImage"] != null)
            {
                var file = Request.Files["userImage"];
                string returnMsg = obj.validation();
                ViewBag.userImage = file;
                ViewBag.txtName = obj.txtName;
                ViewBag.txtLogin = obj.txtLogin;
                ViewBag.txtPassword = obj.txtPassword;
                ViewBag.txtEmail = obj.txtEmail;
                ViewBag.cmbGender = obj.cmbGender;
                ViewBag.txtAddress = obj.txtAddress;
                ViewBag.txtAge = obj.txtAge;
                ViewBag.txtCnic = obj.txtCnic;
                ViewBag.dateDob = obj.dateDob.ToString("yyyy-MM-dd");
                ViewBag.chkCricket = obj.chkCricket;
                ViewBag.chkHockey = obj.chkHockey;
                ViewBag.chkChess = obj.chkChess;
                ViewBag.msg = "";
                if (returnMsg != "true")
                    ViewBag.msg = returnMsg;
                if(file.FileName=="")
                    ViewBag.msg = "Select image and insert other fields if empty";
                if (ViewBag.msg != "")
                    return View();
                var uniqueName = "";
                userDAO userObjDao = new userDAO();
                if (userObjDao.isUserExistByEmail(obj.txtEmail))
                {
                    ViewBag.msg = "User Already Exist! Try with another email";
                    return View();
                }
                if (userObjDao.isUserExistByLogin(obj.txtLogin))
                {
                    ViewBag.msg = "User Already Exist! Try with another login";
                    return View();
                }
                var ext = System.IO.Path.GetExtension(file.FileName);
                uniqueName = Guid.NewGuid().ToString() + ext;
                var rootPath = Server.MapPath("~/UploadedFiles");
                var fileSavePath = System.IO.Path.Combine(rootPath, uniqueName);
                file.SaveAs(fileSavePath);
                obj.userImage = uniqueName;
                if (userObjDao.save(obj))
                {
                    return View();
                }
            }
            else
                ViewBag.msg = "Error in loading image";
            return View();
        }
    }
}