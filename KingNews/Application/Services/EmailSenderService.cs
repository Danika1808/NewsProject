using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class SenderOptions
    {
        public const string EmailBlock = "Email";
        public string SourceEmail { get; set; }
        public string SourcePassword { get; set; }
        public int Port { get; set; }
        public int UseSSL { get; set; }
    }
    public class EmailSenderService
    {
        private readonly SenderOptions _secrets;

        public EmailSenderService(IConfiguration configuration)
        {
            _secrets = new SenderOptions();
            configuration.GetSection(SenderOptions.EmailBlock).Bind(_secrets);

        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("KingNews", _secrets.SourceEmail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.mail.ru", _secrets.Port, _secrets.UseSSL == 1);
            await client.AuthenticateAsync(_secrets.SourceEmail, _secrets.SourcePassword);
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }
    }
}
