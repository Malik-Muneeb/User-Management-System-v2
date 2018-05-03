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

        public ActionResult home()
        {
            String email = Convert.ToString(Request.QueryString["email"]);
            userDAO userObjDao = new userDAO();
            user userObj = userObjDao.getUserByEmail(email);
            ViewBag.txtName = userObj.txtName;
            //String applicationBasePath=System.IO.Path.GetDirectoryName()
            ViewBag.userImage = userObj.userImage;
            ViewBag.txtEmail = email;
            return View();
        }

        public ActionResult newUser()
        {
            String email = "";
            email = Convert.ToString(Request.QueryString["email"]);
            if (email != "")
            {
                userDAO userObjDao = new userDAO();
                user userObj = userObjDao.getUserByEmail(email);
                ViewBag.txtId = userObj.txtId;
                ViewBag.userImage = userObj.userImage;
                ViewBag.txtName = userObj.txtName;
                ViewBag.txtLogin = userObj.txtLogin;
                ViewBag.txtPassword = userObj.txtPassword;
                ViewBag.txtEmail = userObj.txtEmail;
                ViewBag.cmbGender = userObj.cmbGender;
                ViewBag.txtAddress = userObj.txtAddress;
                ViewBag.txtAge = userObj.txtAge;
                ViewBag.txtCnic = userObj.txtCnic;
                ViewBag.dateDob = userObj.dateDob.ToString("yyyy-MM-dd");
                ViewBag.chkCricket = userObj.chkCricket;
                ViewBag.chkHockey = userObj.chkHockey;
                ViewBag.chkChess = userObj.chkChess;
                return View();
            }
            return View();
        }

        //[ActionName("newUser")]
        [HttpPost]
        public ActionResult newUser(user obj)
        {
            if (obj.txtId > 0)
            {
                var file = Request.Files["userImage"];
                
                string returnMsg = obj.validation();
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
                if (ViewBag.msg != "")
                    return View();
                var uniqueName = "";
                userDAO userObjDao = new userDAO();
                if (file.FileName == "")
                {
                    ViewBag.userImage = Request["imageName"];
                    obj.userImage = Request["imageName"];
                }
                else
                {
                    ViewBag.userImage = file.FileName;
                    var ext = System.IO.Path.GetExtension(file.FileName);
                    uniqueName = Guid.NewGuid().ToString() + ext;
                    var rootPath = Server.MapPath("~/UploadedFiles");
                    var fileSavePath = System.IO.Path.Combine(rootPath, uniqueName);
                    file.SaveAs(fileSavePath);
                    obj.userImage = uniqueName;
                }
                if (userObjDao.save(obj))
                {
                    return Redirect("/home/home?email=" + ViewBag.txtEmail);
                }
            }
            else
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
                    if (file.FileName == "")
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
                        return Redirect("/home/home?email=" + ViewBag.txtEmail);
                    }
                }
                else
                    ViewBag.msg = "Error in loading image";
                return View();
            }
            return View();
        }
    }
}