using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User_Management_System.Models
{
    public class user
    {
        public String name { get; set; }
        public String login { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public String gender { get; set; }
        public String address { get; set; }
        public int age { get; set; }
        public String nic { get; set; }
        public DateTime dob { get; set; }
        public bool isCricket { get; set; }
        public bool isHockey { get; set; }
        public bool isChess { get; set; }
        public String imageName { get; set; }

    }
}