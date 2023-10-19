namespace TrainStation.Services.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email);
    }
}
