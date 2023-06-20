using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.Helpers
{
    public class EmaillHelper
    {
        public void SendConfirmationEmail(string email, string token, string name, string surname)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.ethereal.email", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("jade.price42@ethereal.email", "WJ8Yj6pVzkeCRWNJkr");
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("jade.price42@ethereal.email");
                mailMessage.To.Add(email);
                mailMessage.Subject = "Confirmation emmail";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = $"confirim your email <a href='http://localhost:5199/auth/ConfirmEmail?token={token}&email={email}'> Mail </a> ";
                smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
    }
}
