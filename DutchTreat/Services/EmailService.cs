using DutchTreat.Contracts;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Services
{
    public class EmailService : IMailService
    {
        private readonly ILogger<EmailService> _logger;
        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }
        public void SendMessage(string to, string subject, string body)
        {
            _logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");
        }
    }
}