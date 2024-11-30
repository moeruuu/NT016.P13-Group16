using API_Server.Models;
using MailKit;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace API_Server.Service
{
    public class EmailService
    {
        private readonly EmailSender sender;
        public EmailService(IOptions<EmailSender> options) {
            this.sender = options.Value;
        }

        public async Task SendEmail(EmailRequest request)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(sender.EmailGroup16);
            email.To.Add(MailboxAddress.Parse(request.Email));
            email.Subject = request.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = request.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(sender.HostEmail, sender.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(sender.EmailGroup16, sender.PasswordGroup16);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
