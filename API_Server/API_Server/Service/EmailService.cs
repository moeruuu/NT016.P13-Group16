using API_Server.Models;
using MailKit;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Utils;
using MailKit.Net.Smtp;
using MailKit.Net.Imap;
using MailKit.Security;
using MailKit.Search;
using Org.BouncyCastle.Crypto.Macs;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System;
using Org.BouncyCastle.Tls;
using API_Server.Data;
using API_Server.DTOs;

namespace API_Server.Service
{
    public class EmailService
    {

        private readonly EmailSender sender;
        //private readonly UserService userService;
        public EmailService(IOptions<EmailSender> options)
        {
            this.sender = options.Value;
        }

        public async Task SendEmail(EmailRequest request)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(sender.EmailGroup16);
                email.To.Add(MailboxAddress.Parse(request.Email));
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(sender.HostEmail, sender.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(sender.EmailGroup16, sender.PasswordGroup16);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task SendContactEmail(EmailRequest request, UserService userService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.EmailPassword))
                {
                    var user = await userService.GetUserByEmailAsync(request.Email);
                    if (user == null || string.IsNullOrEmpty(user.HashedEmailPassword))
                        throw new Exception("Email password not found for this user.");

                    throw new Exception("Plaintext password is required but not provided.");
                }
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(request.Email));
                email.Sender = MailboxAddress.Parse(request.Email);
                email.To.Add(MailboxAddress.Parse(sender.EmailGroup16));
                email.Subject = $"[New contact from {request.Name}] {request.Subject}";
                var htmlContent = $@"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <style>
                    * {{margin: 0; padding: 0; box-sizing: border-box;}}
                    body {{ font-family: Arial, sans-serif; background-color: #6ccccc; margin: 0; padding: 0; }}
                    .email-container {{ max-width: 600px; margin: 0 auto; background-color: #ffffff; border-radius: 8px; text-align: center; }}
                    .header {{ background-color: #6ccccc; padding: 15px; display: flex; flex-direction: column; align-items: center; justify-content: center; text-align: center; height: 120px;}}
                    .header h2 {{ font-size: 18px; color: #ffffff}}
                    .content {{ padding: 20px; color: #333333; text-align: left;}}
                    .content h1 {{ font-size: 22px; color: #0072bc; }}
                    .content h2 {{ font-size: 18px; color: #0072bc; }}
                    .content p {{ font-size: 16px; line-height: 1.6; }}
                    .footer {{ padding: 10px; background-color: #f4f4f4; font-size: 14px; color: #666666; text-align: center; }}
                </style>
                </head>
                <body>
                    <div class='email-container'>
                        <div class='header'>
                        <img src='https://i.imgur.com/DjYrvRL.png' alt='UITFLIX Logo' width='80; height: auto;'>
                        <h2>NT106.P13</h2>
                        </div>
                        <div class='content'>
                            <h1>New contact from: {request.Name}</h1>
                            <p><strong>Email:</strong> {request.Email}</p>
                            <p><strong>Subject:</strong> {request.Subject}</p>
                            <p><strong>Content:</strong></p>
                            <p>{request.Body}</p>
                        </div>
                        <div class='footer'>
                    UITFLIX - NT106.P13
                         </div>
                    </div>
                </body>
                </html>";
                var builder = new BodyBuilder
                {
                    HtmlBody = htmlContent
                };
                if (!string.IsNullOrEmpty(request.AttachmentPath) && File.Exists(request.AttachmentPath))
                    builder.Attachments.Add(request.AttachmentPath);
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(sender.HostEmail, sender.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(request.Email, request.EmailPassword);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch (SmtpCommandException ex)
            {
                throw new Exception($"SMTP command error: {ex.Message}, StatusCode: {ex.StatusCode}");
            }
            catch (SmtpProtocolException ex)
            {
                throw new Exception($"SMTP protocol error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
       
        public async Task<List<EmailDTOs>> GetEmails()
        {
            try
            {
                using (var client = new ImapClient())
                {
                    await client.ConnectAsync("imap.gmail.com", 993, true);
                    await client.AuthenticateAsync($"{sender.EmailGroup16}", $"{sender.PasswordGroup16}");

                    var inbox = client.Inbox;
                    await inbox.OpenAsync(FolderAccess.ReadOnly);

                    var emails = new List<EmailDTOs>();
                    foreach (var uid in await inbox.SearchAsync(SearchQuery.All))
                    {
                        var message = await inbox.GetMessageAsync(uid);

                        emails.Add(new EmailDTOs
                        {
                            Date = message.Date.DateTime,
                            From = message.From.ToString(),
                            Subject = message.Subject,
                            Body = message.HtmlBody ?? message.TextBody
                        });
                    }

                    await client.DisconnectAsync(true);
                    return emails;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

