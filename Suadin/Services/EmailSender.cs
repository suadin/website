using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Suadin.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;

        public EmailSender(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(configuration["Smtp:User"], "suadin.de");
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;

            var client = new SmtpClient(configuration["Smtp:Host"]);
            client.Port = int.Parse(configuration["Smtp:Port"]);
            client.Credentials = new System.Net.NetworkCredential(configuration["Smtp:User"], configuration["Smtp:Password"]);
            client.EnableSsl = true;
            client.SendCompleted += (s, e) => {
                client.Dispose();
                mail.Dispose();
            };

            await client.SendMailAsync(mail);
        }
    }
}