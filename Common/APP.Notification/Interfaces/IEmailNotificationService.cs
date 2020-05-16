using System.Collections.Generic;
using System.Threading.Tasks;

namespace APP.Notification.Interfaces
{
    /// <summary>
    ///     Интерфейс по работе с email уведомлениями.
    /// </summary>
    public interface IEmailNotificationService
    {
        /// <summary>
        ///     Отправить письмо кокретным пользователям
        /// </summary>
        /// <param name="emails">почта конкретных пользователей</param>
        /// <param name="subject">тема письма</param>
        /// <param name="message">текст письма</param>
        /// <returns></returns>
        Task SendEmailAsync(List<string> emails, string subject, string message);

        /// <summary>
        ///     Отправить письмо пользователям из группы ...
        /// </summary>
        /// <param name="roleId">идентификатор роли</param>
        /// <param name="subject">тема письма</param>
        /// <param name="message">текст письма</param>
        /// <returns></returns>
        Task SendEmailUsersAsync(int roleId, string subject, string message);
    }
}