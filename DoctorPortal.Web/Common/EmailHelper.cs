using System;
using System.Net.Mail;
using System.Threading.Tasks;
using DoctorPortal.Web.Areas.Admin.Models;

namespace DoctorPortal.Web.Common
{
    public class EmailHelper
    {
        public static bool SendMail(string to, string subject, string bodyTemplate, bool isHtml = false, string bcc = "", string ccMail = "", string attachmentFileName = "")
        {
            var email = ConfigItems.SmtpEmail;
            var password = ConfigItems.SmtpPassword;
            var portNumber = Convert.ToInt32(ConfigItems.PortNumber);
            var hostName = ConfigItems.HostName;

            var mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(email);
            mail.Subject = subject;
            mail.Body = bodyTemplate;
            mail.IsBodyHtml = true;

            if (!string.IsNullOrEmpty(ccMail))
                mail.CC.Add(ccMail);

            var smtp = new SmtpClient
            {
                Host = hostName,
                Port = portNumber,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential(email, password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            try
            {
                smtp.Send(mail);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }


        public static void SendAsyncEmail(string to, string subject, string body, bool isHtml = false, string bcc = "",
            string cc = "", string attachmentFileName = "")
        {
            var task = new Task(() => SendMail(to, subject, body, isHtml, bcc, cc, attachmentFileName));
            task.Start();
        }
    }
}