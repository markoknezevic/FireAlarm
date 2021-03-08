using System;
using System.Net.Mail;

namespace FireAlarm.API.Helpers
{
    public class MailSender
    {
        private Configuration.Configuration _configuration;

        public MailSender(Configuration.Configuration configuration)
        {
            _configuration = configuration;
        }
        
        
        public bool SendEmail(string clientMail, string sensorName, double? temperatureValue)
        {
            bool response;
            
            SmtpClient smtpclient = new SmtpClient();
            MailMessage mail = new MailMessage();
            
            MailAddress fromaddress = new MailAddress(_configuration.MailConfiguration.SenderMail);
            
            smtpclient.Host = "smtp.gmail.com";
            
            smtpclient.Port = 587;
            smtpclient.EnableSsl = true;
            mail.From = fromaddress;
            
            mail.To.Add(clientMail);

            mail.IsBodyHtml = true;
            
            mail.Subject = ($"{sensorName} Fire Alarm Alert");
            mail.Body = $"<H2>Fire Alarm. Measured temperature {temperatureValue} C</H2>";
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpclient.Credentials = new System.Net.NetworkCredential(_configuration.MailConfiguration.SenderMail, _configuration.MailConfiguration.SenderMailPassword);
            try
            {
                smtpclient.Send(mail);
                response = true;
            }
            catch
            {
                response = false;
            }

            return response;

        }

        
    }
}