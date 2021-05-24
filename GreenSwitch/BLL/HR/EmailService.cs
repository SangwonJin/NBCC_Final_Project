using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

    public class EmailService
    {
        public bool SendEmail(Email emailMessage)
        {
            if (IsValid(emailMessage))
            {
                try
                {
                    MailMessage mm = new MailMessage(emailMessage.From, emailMessage.To, emailMessage.Subject, emailMessage.Body);
                    if (emailMessage.CC != null && emailMessage.CC.Count > 0)
                    {
                        foreach (string address in emailMessage.CC)
                        {
                            mm.CC.Add(address);
                        }
                    }
               
                SmtpClient sc = new SmtpClient("localhost");
                sc.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                sc.UseDefaultCredentials = false;
                sc.Send(mm);
                }
                catch (Exception e)
                {
                    throw e;
                    
                
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool IsValid(Email emailMessage)
        {
            if (emailMessage.From == null || emailMessage.From == "" || emailMessage.To == null ||
                emailMessage.To == "" || emailMessage.Subject == null || emailMessage.Subject == "" ||
                emailMessage.Body == null || emailMessage.Body == "")
            {
                return false;
            }
            return true;
        }
    }

