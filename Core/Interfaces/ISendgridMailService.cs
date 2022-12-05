namespace ApiSalud.Core.Interfaces
{
    public interface ISendgridMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);

    }
}
