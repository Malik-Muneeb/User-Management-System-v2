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
            var uniqueName = "";
            var file = Request.Files["userImage"];
            if(Request.Files["userImage"]!=null)
            {
                 file = Request.Files["userImage"];
                if(file.FileName!="")
                {
                    string returnMsg=obj.validation();
                    if ( returnMsg != "true")
                    {
                        ViewBag.userImage = file;
                        ViewBag.txtName = obj.txtName;
                        ViewBag.txtLogin = obj.txtLogin;
                        ViewBag.txtPassword = obj.txtPassword;
                        ViewBag.txtEmail = obj.txtEmail;
                        ViewBag.cmbGender = obj.cmbGender;
                        ViewBag.txtAddress = obj.txtAddress;
                        ViewBag.txtAge = obj.txtAge;
                        ViewBag.txtCnic = obj.txtCnic;
                        ViewBag.dateDob = obj.dateDob;
                        ViewBag.msg = returnMsg;
                    }
                    else
                    {
                        var ext = System.IO.Path.GetExtension(file.FileName);
                        uniqueName = Guid.NewGuid().ToString() + ext;
                        var rootPath = Server.MapPath("~/UploadedFiles");
                        var fileSavePath = System.IO.Path.Combine(rootPath, uniqueName);
                        file.SaveAs(fileSavePath);
                        obj.userImage = uniqueName;
                        userDAO userObjDao = new userDAO();
                        if (userObjDao.save(obj))
                        {
                            return View();
                        }
                    }
                }
            }
            return View();
        }
	}
}