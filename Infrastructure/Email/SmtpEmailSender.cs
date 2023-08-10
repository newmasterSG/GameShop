using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly ILogger<SmtpEmailSender> _logger;
        private readonly SmtpClient _smtpClient;
        private readonly IConfiguration _config;
        public SmtpEmailSender(ILogger<SmtpEmailSender> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            var smtpSettings = config.GetSection("Smtp");
            _smtpClient = new SmtpClient()
            {
                Host = smtpSettings["Host"],
                Port = int.Parse(smtpSettings["Port"]),
                Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]),
                EnableSsl = true,
            };
        }

        public async Task SendEmailAsync(string to, string from, string subject, string body, bool htmlBody)
        {
            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(from ?? _config.GetSection("Smtp")["Username"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = htmlBody,
                };
                message.To.Add(new MailAddress(to));
                await _smtpClient.SendMailAsync(message);
                _logger.LogWarning("Sending email to {to} from {from} with subject {subject}.", to, from, subject);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
