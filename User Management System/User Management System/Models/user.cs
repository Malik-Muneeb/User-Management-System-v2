using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User_Management_System.Models
{
    public class user
    {
        public String txtName { get; set; }
        public String txtLogin { get; set; }
        public String txtPassword { get; set; }
        public String txtEmail { get; set; }
        public String cmbGender { get; set; }
        public String txtAddress { get; set; }
        public int txtAge { get; set; }
        public String txtCnic { get; set; }
        public DateTime dateDob { get; set; }
        public bool chkCricket { get; set; }
        public bool chkHockey { get; set; }
        public bool chkChess { get; set; }
        public String userImage { get; set; }

        public String validation()
        {
            if (this.txtName == null)
                return "Must Enter Name";
            if (this.txtLogin == null)
                return "Must Enter Login";
            if (this.txtPassword == null)
                return "Must Enter Password";
            if (this.txtEmail == null)
                return "Must Enter Email";
            if (this.txtAddress == null)
                return "Must Enter Address";
            if (this.txtEmail == null)
                return "Must Enter Email";
            if (this.txtCnic == null)
                return "Must Enter CNIC";
            return "true";
        }

    }
}