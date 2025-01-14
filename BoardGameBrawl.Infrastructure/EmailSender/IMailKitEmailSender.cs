namespace BoardGameBrawl.Infrastructure.EmailSender
{
    public interface IMailKitEmailSender
    {
        public Task SendEmailAsync(string to, string subject, string message);
    }
}
