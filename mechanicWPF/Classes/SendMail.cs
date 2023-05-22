using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows;

namespace mechanicWPF.Classes
{
    internal class SendMail
    {
        public void sendMail(string body, string to, string subject)
        {
            using (MailMessage mail = new MailMessage("minecraft3598@gmail.com", to, subject, body))
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials= false;
                smtp.Credentials = new NetworkCredential("minecraft3598@gmail.com", "rnkkljofwsaalwrb");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            
        }
    }
}
