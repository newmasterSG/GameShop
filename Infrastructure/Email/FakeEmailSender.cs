using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Email
{
    public class FakeEmailSender : EmailSender
    {
        private readonly ILogger<FakeEmailSender> _logger;

        public FakeEmailSender(ILogger<FakeEmailSender> logger)
        {
            _logger = logger;
        }
        public override Task SendEmailAsync(string to, string from, string subject, string body, bool htmlBody)
        {
            _logger.LogInformation("Not actually sending an email to {to} from {from} with subject {subject}", to, from, subject);
            return Task.CompletedTask;
        }
    }
}
