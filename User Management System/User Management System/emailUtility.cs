using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Net.Mail;
using System.Configuration;

namespace User_Management_System
{
    public class emailUtility
    {
        public static int num{ get; set; }

        
        public static int SendEmail1(String toEmail)
        {
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                MailAddress to = new MailAddress(toEmail);
                mail.To.Add(to);
                MailAddress from = new MailAddress("ead.csf15@gmail.com", "Admin");
                mail.From = from;
                mail.Subject = "Hello Testing";
                Random rnd = new Random();
                num = rnd.Next(1,100000);
                mail.Body = num.ToString(); 
                var sc = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new System.Net.NetworkCredential("ead.csf15@gmail.com", "EAD_csf15m"),
                    EnableSsl = true
                };

                sc.Send(mail);
                return num;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}




