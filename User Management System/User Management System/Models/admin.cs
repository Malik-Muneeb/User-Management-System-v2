using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User_Management_System.Models
{
    public class admin
    {
        public int adminId { get; set; }
        public string adminName { get; set; }
        public string txtLogin { get; set; }
        public string txtPassword { get; set; }
    }
}