using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using WebFile.Models;

namespace CML
{
    public class SendMail : IEmailSender<mailModel>
    {
        public static string sendMail(mailModel Model)
        {

            string smtpUID = "tareqislam42@gmail.com";
            string smtpPass = ConfigurationManager.AppSettings["smtpSenderPass"];
            string EmailTo = ConfigurationManager.AppSettings["EmailTo"];

            string strRes = Sender(toList: EmailTo,
               from: smtpUID,
               ccList: null,
               email: Model.Email,
               body: Model.Message);



            return strRes;
        }
        
        public static string Sender(string toList, string from, string ccList, string email, string body)
        {
            string smtpUID = ConfigurationManager.AppSettings["smtpSenderUID"];
            string smtpPass = ConfigurationManager.AppSettings["smtpSenderPass"];
            string EmailTo = ConfigurationManager.AppSettings["EmailTo"];
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress(from);
                message.From = fromAddress;
                message.To.Add(toList);
                if (ccList != null && ccList != string.Empty)
                    message.CC.Add(ccList);
                message.Subject = email;
                message.IsBodyHtml = true;
                message.Body = body;
                smtpClient.Host = "smtp.mailtrap.io";
                smtpClient.Port = 2525;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;

                smtpClient.Credentials = new System.Net.NetworkCredential(smtpUID, smtpPass);

                smtpClient.Send(message);
              return  msg = "alert('Your message successfuly sent!!!')";
            }
            catch (Exception ex)
            {
               return msg = "alert('Your message not sent!!!')";
            }
          
        }
    }
}
