using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace VortexFileClient.Data
{
    internal class EmailMessanger
    {
        private readonly string code;

        private readonly string email;

        private readonly string name;

        private readonly string password;

        public EmailMessanger(string email, string name, string password)
        {
            code = String.Empty;
            Random rnd = new Random();
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                code += ALF[rnd.Next(ALF.Length)];

            this.email = email;
            this.name = name;
            this.password = password;
        }

        public bool CheckCode(string code)
        {
            return this.code.ToLower() == code.ToLower();
        }

        public async Task SendEmailCodeAsync(string email, string subject)
        {
            MailAddress fromAddress = new MailAddress(this.email, name);
            MailAddress toAddress = new MailAddress(email);
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = $"Код восстановления пароля - {code}";
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
            smtp.Credentials = new NetworkCredential(this.email, password);
            smtp.EnableSsl = true;
            try
            {
                await smtp.SendMailAsync(message);
            }
            catch (Exception) { }
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            MailAddress fromAddress = new MailAddress(this.email, name);
            MailAddress toAddress = new MailAddress(email);
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = body;
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
            smtp.Credentials = new NetworkCredential(this.email, password);
            smtp.EnableSsl = true;
            try
            {
                await smtp.SendMailAsync(message);
            }
            catch (Exception) { }
        }
    }
}
