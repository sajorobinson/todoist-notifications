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
            string apiKey = Private.Credentials.SendGridApiToken();
            SendGridClient client = new SendGridClient(apiKey);
            EmailAddress from = new EmailAddress(Private.Email.GetEmailSender(), SenderName);
            EmailAddress to = new EmailAddress(Private.Email.GetEmailRecipient(), ReceiverName);
            SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, Subject, PlainTextContent, HtmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}