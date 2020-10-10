using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
//using System.Net.Mail;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace cocktails.Services
{
    public class EmailSender : IEmailSender
    {
        // Our private configuration variables
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;
        
        // Get our parameterized configuration
        public EmailSender(string host, int port, bool enableSSL, string userName, string password) {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.userName = userName;
            this.password = password;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(subject, message, email);
        }

        public Task Execute(string subject, string message, string email)
        {
            var msg = new MimeKit.MimeMessage();
            msg.From.Add(new MailboxAddress("cocktails", this.userName));
            msg.To.Add(MailboxAddress.Parse(email));
            msg.Subject = subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = message;
            msg.Body = builder.ToMessageBody();
            
            var smtp = new SmtpClient();
            smtp.Connect(this.host,this.port, MailKit.Security.SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(this.userName, this.password);
            return smtp.SendAsync(msg);

        }
    }
}