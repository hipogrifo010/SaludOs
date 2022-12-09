using ApiSalud.Core.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ApiSalud.Core.Services;

public class SendGridMailService : ISendgridMailService
{
    private readonly IConfiguration _configuration;

    public SendGridMailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string content)
    {
        var apiKey = _configuration["SendGridAPIKey"];
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("grifo010@gmail.com", "Alkemy Api Rest Disney");
        var to = new EmailAddress(toEmail);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
        var response = await client.SendEmailAsync(msg);
    }
}