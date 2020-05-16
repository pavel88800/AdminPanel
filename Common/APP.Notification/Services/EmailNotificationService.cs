using System;
using System.Collections.Generic;

namespace APP.Notification.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using APP.DB;
    using APP.Notification.Interfaces;
    using MailKit.Net.Smtp;
    using MimeKit;
    using MimeKit.Text;

    /// <summary>
    ///     Сервис по отправке писем на e-mail
    /// </summary>
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly PanelContext _context;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="context">Контекст БД.</param>
        public EmailNotificationService(PanelContext context)
        {
            _context = context;
        }

        /// <inheritdoc cref="" />
        public async Task SendEmailAsync(List<string> emails, string subject, string message)
        {
            if (emails.Count > 0)
            {
                SendMessage(emails, subject, message);
            }
        }

        /// <inheritdoc cref="" />
        public async Task SendEmailUsersAsync(int roleId, string subject, string message)
        {
            var usersEmail = _context.Users
                .Where(x => x.Role.Id == roleId &&  x.Status)
                .Select(x => x.Email)
                .ToList();

            if (usersEmail.Count == 0)
                throw new ApplicationException("Пользователей в этой группе не найдено. Сообщение отправлять некому.");

            SendMessage(usersEmail, subject, message);
        }

        private async void SendMessage(List<string> emails, string subject, string message) 
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "pavel88800@yandex.ru"));

            foreach (var email in emails)
                emailMessage.To.Add(new MailboxAddress("", email));

            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = "<h1> Здравствуйте! </h1>" +
                       $"<p>{message}</p>" +
                       "<em>- Администрация сайта</em>"
            };

            using var client = new SmtpClient();

            await client.ConnectAsync("smtp.yandex.ru", 25, false);
            await client.AuthenticateAsync("pavel88800@yandex.ru", "es15102006es");
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }
    }
}