namespace APProject.Controllers.Api
{
    using APP.Notification.Interfaces;
    using APProject.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Контроллер по отправке email писем.
    /// </summary>
    public class SendEmailController : BaseApiController
    {
        /// <summary>
        ///     Сервис по отправке писем
        /// </summary>
        public IEmailNotificationService _notification;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="notification">сервис</param>
        public SendEmailController(IEmailNotificationService notification)
        {
            _notification = notification;
        }

        /// <summary>
        ///     Отправить письмо.
        /// </summary>
        /// <param name="email">адрес получателя</param>
        /// <param name="subject">тема письма</param>
        /// <param name="message">содержимое письма</param>
        [HttpPost]
        public void Send(string email, string subject, string message)
        {
            _notification.SendEmailAsync(email, subject, message);
        }
    }
}