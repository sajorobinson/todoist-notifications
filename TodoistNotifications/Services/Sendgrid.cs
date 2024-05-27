// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Services
{
    class SendGrid
    {
        const string SenderName = "TodoistNotifications";
        const string ReceiverName = "Example User";
        public static async Task SendEmail(string Subject, string PlainTextContent, string HtmlContent)
        {
            var apiKey = Private.Credentials.SendGridApiToken();
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(Private.Email.GetEmailSender(), SenderName);
            var to = new EmailAddress(Private.Email.GetEmailRecipient(), ReceiverName);
            var msg = MailHelper.CreateSingleEmail(from, to, Subject, PlainTextContent, HtmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}