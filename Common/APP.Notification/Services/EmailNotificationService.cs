namespace APP.Notification.Services
{
    using System.Threading.Tasks;
    using APP.Notification.Interfaces;
    using MailKit.Net.Smtp;
    using MimeKit;
    using MimeKit.Text;

    /// <summary>
    ///     Сервис по отправке писем на e-mail
    /// </summary>
    public class EmailNotificationService : IEmailNotificationService
    {
        /// <inheritdoc />
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "pavel88800@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", "pavel88800@yandex.ru"));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(TextFormat.Html)
            {
                Text =
                    $"<!DOCTYPE html ><html xmlns=\"\"><head> <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /> <meta name=\"viewport\" content=\"width=device-width\"/> <!-- For development, pass document through inliner --> <link rel=\"stylesheet\" href=\"css/simple.css\"> <style type=\"text/css\"> /* Your custom styles go here */ </style></head><body><table class=\"body-wrap\"> <tr> <td class=\"container\"> <!-- Message start --> <table> <tr> <td align=\"center\" class=\"masthead\">  </td> </tr> <tr> <td class=\"content\"> <h2>Здравствуйте!</h2> <p>{message}</p> <table> <tr> <td align=\"center\"> <p> <a href=\"#\" class=\"button\">Share the Awesomeness</a> </p> </td> </tr> </table>  <p><em>– Mr. Pen</em></p> </td> </tr> </table> </td> </tr> <tr> <td class=\"container\"> <!-- Message start --> <table> <tr> <td class=\"content footer\" align=\"center\">  </td> </tr> </table> </td> </tr></table></body></html>"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("pavel88800@yandex.ru", "es15102006es");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}