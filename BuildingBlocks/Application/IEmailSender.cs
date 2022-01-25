namespace BuildingBlocks.Application
{
    public interface IEmailSender
    {
        Task Send(string from, string to, string subject, string message);
    }
}
