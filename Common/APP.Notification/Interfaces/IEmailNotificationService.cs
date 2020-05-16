using System.Threading.Tasks;

namespace APP.Notification.Interfaces
{
    /// <summary>
    ///     Интерфейс по работе с email уведомлениями.
    /// </summary>
    public interface IEmailNotificationService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}