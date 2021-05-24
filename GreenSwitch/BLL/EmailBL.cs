using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmailBL : Base
    {
        public void SendEmail(Email email)
        {
            //MailMessage mail = new MailMessage();
            //SmtpClient client = new SmtpClient("smtp.gmail.com");

            //mail.From = new MailAddress(email.EmailFrom);
            //mail.To.Add(email.EmailTo);
            //mail.Subject = email.Subject;
            //mail.Body = email.Body;

            //client.UseDefaultCredentials = false;
            //client.Port = 587;
            //client.Credentials = new System.Net.NetworkCredential(email.EmailFrom, "GreenSwitch!12345");
            //client.EnableSsl = true;

            //client.Send(mail);
        }
    }
}
